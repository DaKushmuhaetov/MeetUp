using MeetUp.Domain.Meets;
using MeetUp.Queries.Meets;
using MeetUp.Queries.Users;
using MeetUp.Shared.CQRS;
using MeetUp.WebApi.Models.Meets;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MeetUp.WebApi.Controllers
{
    [ApiController]
    public class MeetController : ControllerBase
    {
        /// <summary>
        /// Create meet
        /// </summary>
        /// <param name="binding">Meet model</param>
        /// <response code="204">Successfully</response>
        [Authorize(Policy = "user")]
        [HttpPost("/Meet")]
        [ProducesResponseType(204)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        [ProducesResponseType(typeof(ProblemDetails), 409)]
        [ProducesResponseType(typeof(ProblemDetails), 412)]
        public async Task<IActionResult> CreateMeet(
            CancellationToken cancellationToken,
            [FromBody] CreateMeetBinding binding,
            [FromServices] IMeetRepository meetRepository,
            [FromServices] MeetCreateService meetCreateService)
        {
            var position = await meetCreateService.CreatePosition(binding.Lat, binding.Ing);
            var post = await meetCreateService.CreatePost(binding.Name + "\n" + binding.Description, binding.CreatorId);

            var members = new List<Guid>();
            members.Add(binding.CreatorId);

            var meet = new Meet(
                id: binding.Id,
                positionId: position.Id,
                name: binding.Name,
                description: binding.Description,
                members: members,
                dateOfStart: binding.DateOfstart,
                tags: binding.Tags,
                creator: binding.CreatorId,
                images: binding.Images,
                postId: post.Id);

            try
            {
                await meetRepository.Save(meet, cancellationToken);
                return Ok(meet);
            }
            catch (DbUpdateException exception)
               when (((Npgsql.PostgresException)exception.InnerException)?.SqlState == "23505")
            {
                return Conflict();
            }
        }

        /// <summary>
        /// Get meet
        /// </summary>
        /// <param name="id">Meet Id</param>
        /// <response code="204">Successfully</response>
        [Authorize(Policy = "user")]
        [HttpGet("/meet/{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        public async Task<IActionResult> GetMeet(
            CancellationToken cancellationToken,
            [FromRoute] Guid id,
            [FromServices] IQueryProcessor queryProcessor)
        {
            var meet = await queryProcessor.Process(new MeetQuery(id), cancellationToken);

            if(meet == null)
                return NotFound();
            
            return Ok(meet);
        }

        /// <summary>
        /// Get meets
        /// </summary>
        /// <response code="204">Successfully</response>
        [Authorize(Policy = "user")]
        [HttpGet("/meets")]
        [ProducesResponseType(204)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        public async Task<IActionResult> GetMeets(
            CancellationToken cancellationToken,
            [FromQuery] GetMeetsBinding binding,
            [FromServices] IQueryProcessor queryProcessor)
        {
            var users = await queryProcessor.Process(new MeetListQuery(binding.CreatorId, binding.Tags, binding.Offset, binding.Limit), cancellationToken);

            if (users == null)
                return NotFound();

            return Ok(users);
        }
    }
}
