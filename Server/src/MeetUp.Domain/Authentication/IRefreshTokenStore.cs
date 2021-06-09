using System;
using System.Threading;
using System.Threading.Tasks;

namespace MeetUp.Domain.Authentication
{
    public interface IRefreshTokenStore
    {
        Task<string> Add(Guid userId, CancellationToken cancellationToken);
        Task<RefreshToken> Reissue(string refreshToken, CancellationToken cancellationToken);
    }
}
