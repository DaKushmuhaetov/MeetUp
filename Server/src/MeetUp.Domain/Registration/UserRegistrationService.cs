using System;
using System.Threading;
using System.Threading.Tasks;

namespace MeetUp.Domain.Registration
{
    public sealed class UserRegistrationService
    {
        private readonly IPasswordHasher _passwordHasher;

        public UserRegistrationService(IPasswordHasher passwordHasher)
        {
            _passwordHasher = passwordHasher;
        }

        public async Task<User> CreateUser(string email, string login, string password, int level, string numberPhone, DateTime dateCreate, DateTime dateLastEdit, string firstName, string lastName, string middleName, string hobby, DateTime dateOfBirth,AuthType authType, CancellationToken cancellationToken)
        {
            var hash = _passwordHasher.HashPassword(password);

            UserAttribute userAttribute = new UserAttribute(new Guid(), firstName, middleName, lastName, hobby, dateOfBirth);

            return new User(Guid.NewGuid(), login, hash, level, numberPhone, email, authType , userAttribute.Id, dateCreate, dateLastEdit);
        }

    }
}
