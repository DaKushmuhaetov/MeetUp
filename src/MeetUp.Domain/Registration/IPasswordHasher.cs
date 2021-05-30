namespace MeetUp.Domain.Registration
{
    public interface IPasswordHasher
    {
        string HashPassword(string password);
    }
}
