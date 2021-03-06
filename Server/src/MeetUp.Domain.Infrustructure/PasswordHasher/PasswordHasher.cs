using Microsoft.AspNetCore.Identity;

namespace MeetUp.Domain.Infrustructure.PasswordHasher
{
    public sealed class PasswordHasher : Domain.Authentication.IPasswordHasher,
                                         Domain.Registration.IPasswordHasher
    {
        private sealed class User { }

        private readonly IPasswordHasher<User> _hasher = new PasswordHasher<User>();

        public bool VerifyHashedPassword(string hashedPassword, string providedPassword)
        {
            var result = _hasher.VerifyHashedPassword(new User(), hashedPassword, providedPassword);
            return result == PasswordVerificationResult.Success ||
                   result == PasswordVerificationResult.SuccessRehashNeeded;
        }

        public string HashPassword(string password)
        {
            return _hasher.HashPassword(new User(), password);
        }
    }
}
