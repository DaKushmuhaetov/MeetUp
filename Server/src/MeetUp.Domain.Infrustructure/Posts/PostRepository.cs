using MeetUp.Domain.Posts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MeetUp.Domain.Infrustructure.Posts
{
    public class PostRepository : IPostRepository
    {
        private readonly PostDbContext _context;

        public PostRepository(PostDbContext context)
        {
            _context = context;
        }

        public async Task<List<Post>> FindPostByCreator(Guid id, CancellationToken cancellationToken)
        {
            return await _context.Posts.Where(o => o.Id == id).ToListAsync();
        }

        public async Task Save(Post post, CancellationToken cancellationToken)
        {
            if (_context.Entry(post).State == EntityState.Detached)
                _context.Posts.Add(post);

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
