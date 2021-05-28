using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetUp.Domain.Authentication
{
    public sealed class RefreshToken
    {
        public string Value { get; }
        public Guid UserId { get; }

        public RefreshToken(string value, Guid userId)
        {
            Value = value ?? throw new ArgumentNullException(nameof(value));
            UserId = userId;
        }
    }
}
