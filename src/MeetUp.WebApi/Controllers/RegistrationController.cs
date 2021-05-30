using MeetUp.Domain.Registration;
using MeetUp.WebApi.Models.Registration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MeetUp.WebApi.Controllers
{
    [ApiController]
    public class RegistrationController : ControllerBase
    {

        /// <summary>
        /// Register user
        /// </summary>
        /// <param name="binding">Registration model</param>
        /// <response code="204">Successfully</response>
        /// <response code="400">Invalid registration parameters format</response>
        /// <response code="409">User with that email already registered</response>
        [HttpPost("/registrations")]
        [ProducesResponseType(204)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        [ProducesResponseType(typeof(ProblemDetails), 409)]
        [ProducesResponseType(typeof(ProblemDetails), 412)]
        public async Task<IActionResult> Registration(
            CancellationToken cancellationToken,
            [FromBody] RegistrationBinding binding,
            [FromServices] IUserRepository userRepository,
            [FromServices] UserRegistrationService registrationService)
        {
            var user = await userRepository.FindByLogin(binding.Login, cancellationToken);
            if (user != null)
            {
                return Conflict();
            }
            user = await registrationService.CreateUser(binding.Email,
                binding.Login, binding.Password, 1, binding.NumberPhone,
                DateTime.Now, DateTime.Now, binding.FirstName, binding.LastName,
                binding.MiddleName, binding.Hobby, binding.DateOfBirth, cancellationToken);

            try
            {
                await userRepository.Save(user);

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
