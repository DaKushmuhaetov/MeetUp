using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetUp.Domain.Infrustructure.RefreshTokenStore
{
    internal sealed class RefreshToken
    {
        public string Id { get; }

        public Guid UserId { get; }

        public DateTime Expire { get; private set; }

        public RefreshToken(string id, Guid userId, TimeSpan expiresIn)
        {
            Id = id ?? throw new ArgumentNullException(nameof(id));
            UserId = userId;
            Expire = DateTime.UtcNow.Add(expiresIn);
        }

        private RefreshToken() { }

        public void Terminate()
        {
            Expire = DateTime.UtcNow;
        }
    }
}
