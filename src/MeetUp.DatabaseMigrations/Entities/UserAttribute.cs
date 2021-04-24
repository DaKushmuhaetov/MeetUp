using System;
using System.Collections.Generic;
using System.Text;

namespace MeetUp.DatabaseMigrations.Entities
{
    public sealed class UserAttribute
    {
        public Guid Id { get; }
        public string FirstName { get; private set; }
        public string MiddleName { get; private set; }
        public string LastName { get; private set; }
        public string Hobby { get; private set; }
        public DateTime DateOfBirth { get; private set; }
    }
}
