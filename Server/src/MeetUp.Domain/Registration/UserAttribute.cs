using System;

namespace MeetUp.Domain.Registration
{
    public sealed class UserAttribute
    {
        public Guid Id { get; }
        public string FirstName { get; private set; }
        public string MiddleName { get; private set; }
        public string LastName { get; private set; }
        public string Hobby { get; private set; }
        public DateTime DateOfBirth { get; private set; }

        private UserAttribute() { }
        public UserAttribute(Guid id, string firstName, string middleName, string lastName, string hobby, DateTime dateOfBirth)
        {
            Id = id;
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
            Hobby = hobby;
            DateOfBirth = dateOfBirth;
        }
    }
}
