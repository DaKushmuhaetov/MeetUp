using System.Threading;
using System.Threading.Tasks;

namespace MeetUp.Domain.Authentication
{
    public interface IAccessTokenFactory
    {
        Task<AccessToken> Create(User user, CancellationToken cancellationToken);
    }
}
