using System;

namespace MeetUp.Domain.Authentication
{
    public class AccessToken
    {
        public string Value { get; }
        public TimeSpan ExpiresIn { get; }

        public AccessToken(string value, TimeSpan expiresIn)
        {
            Value = value ?? throw new ArgumentNullException(nameof(value));
            ExpiresIn = expiresIn;
        }
    }
}
