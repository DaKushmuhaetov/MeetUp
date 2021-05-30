using System;

namespace MeetUp.WebApi.Models.Registration
{
    public sealed class RegistrationBinding
    {
        /// <summary>
        /// User email
        /// </summary>
        public string Email { get; set; }
        public string Login { get; set; }
        public string NumberPhone { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Hobby { get; set; }
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// User password
        /// </summary>
        public string Password { get; set; }

    }
}
