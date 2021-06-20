using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetUp.Domain.Posts
{
    public sealed class PostCreateService
    {
        public async Task<Post> CreatePost(string bodyPost, Guid creatorId)
        {
            return new Post(new Guid(), bodyPost, DateTime.Now, creatorId);
        }
    }
}
