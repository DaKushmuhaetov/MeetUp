using MeetUp.Domain.Posts;
using MeetUp.WebApi.Models.Posts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MeetUp.WebApi.Controllers
{
    [ApiController]
    public class PostController : ControllerBase
    {
        /// <summary>
        /// Create post
        /// </summary>
        /// <param name="binding">Post model</param>
        /// <response code="204">Successfully</response>
        [HttpPost("/Post")]
        [ProducesResponseType(204)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        [ProducesResponseType(typeof(ProblemDetails), 409)]
        [ProducesResponseType(typeof(ProblemDetails), 412)]
        public async Task<IActionResult> CreateMeet(
            CancellationToken cancellationToken,
            [FromBody] CreatePostBinding binding,
            [FromServices] IPostRepository postRepository,
            [FromServices] PostCreateService postCreateService)
        {

            var post = new Post(
                new Guid(),
                binding.Body,
                DateTime.Now,
                new Guid()
                );

            try
            {
                await postRepository.Save(post, cancellationToken);
                return Ok(post);
            }
            catch (DbUpdateException exception)
               when (((Npgsql.PostgresException)exception.InnerException)?.SqlState == "23505")
            {
                return Conflict();
            }
        }
    }
}
