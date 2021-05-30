using MeetUp.Domain.Meets;
using MeetUp.WebApi.Models.Meets;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        /// <response code="400">Invalid registration parameters format</response>
        /// <response code="409">User with that email already registered</response>
        [HttpPost("/createMeet")]
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

            var meet = await meetCreateService.CreateMeet(position.Id, binding.Name, binding.Description,
                binding.DateOfstart, binding.Tags, binding.CreatorId,
                binding.Images, post.Id, cancellationToken);

            try
            {
                await meetRepository.Save(meet);
                return NoContent();
            }
            catch (DbUpdateException exception)
               when (((Npgsql.PostgresException)exception.InnerException)?.SqlState == "23505")
            {
                return Conflict();
            }
        }
    }
}
