using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MeetUp.Domain.Posts
{
    public interface IPostRepository
    {
        Task<List<Post>> FindPostByCreator(Guid id, CancellationToken cancellationToken);
        Task Save(Post post, CancellationToken cancellationToken);
    }
}
