using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
