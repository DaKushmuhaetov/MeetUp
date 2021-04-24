using System;
using System.Collections.Generic;
using System.Text;

namespace MeetUp.Domain.Authentication
{
    public sealed class User
    {
        public Guid Id { get; private set; }
        public string Login { get; private set; }
        public AuthType AuthType { get; private set; }
        public string PasswordHash { get; private set; }

        private User() { }
    }
}
