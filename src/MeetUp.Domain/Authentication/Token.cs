using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetUp.Domain.Authentication
{
    public sealed class Token
    {
        public string AccessToken { get; }
        public TimeSpan ExpiresIn { get; }
        public string RefreshToken { get; }

        public Token(string accessToken, TimeSpan expiresIn, string refreshToken)
        {
            AccessToken = accessToken ?? throw new ArgumentNullException(nameof(accessToken));
            ExpiresIn = expiresIn;
            RefreshToken = refreshToken;
        }
    }
}
