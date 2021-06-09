namespace MeetUp.Domain.Authentication
{
    public interface IPasswordHasher
    {
        bool VerifyHashedPassword(string hashedPassword, string providedPassword);
    }
}
