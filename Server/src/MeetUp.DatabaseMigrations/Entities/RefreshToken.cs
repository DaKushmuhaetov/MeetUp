using System;

namespace MeetUp.DatabaseMigrations.Entities
{
    internal sealed class RefreshToken
    {
        public string RefreshTokenId { get; set; }
        public Guid UserId { get; set; }
        public DateTime Expire { get; set; }
    }
}
