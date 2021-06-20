using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MeetUp.Domain.Meets
{
    public interface IMeetRepository
    {
        Task<List<Meet>> FindByName(string name, CancellationToken cancellationToken);
        Task<List<Meet>> FindByTag(string nameTag, CancellationToken cancellationToken);
        Task<Tag> FindTag(string name, CancellationToken cancellationToken);
        Task Save(Meet meet, CancellationToken cancellationToken);
    }
}
