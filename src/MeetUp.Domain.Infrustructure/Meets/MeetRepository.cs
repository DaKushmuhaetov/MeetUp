using MeetUp.Domain.Meets;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MeetUp.Domain.Infrustructure.Meets
{
    public class MeetRepository
    {
        private readonly MeetDbContext _context;

        public MeetRepository(MeetDbContext context)
        {
            _context = context;
        }
        public async Task<List<Meet>> FindByName(string name, CancellationToken cancellationToken)
        {
            return await _context.Meets.Where(o => o.Name == name).ToListAsync(cancellationToken);
        }

        public async Task<Tag> FindTag(string name, CancellationToken cancellationToken)
        {
            return await _context.Tags.SingleOrDefaultAsync(o => o.Name == name);
        }

        public async Task<List<Meet>> FindByTag(string nameTag, CancellationToken cancellationToken)
        {
            var tag = _context.Tags.SingleOrDefaultAsync(o => o.Name == nameTag);
            return await _context.Meets.Where(o => o.Tags.Contains(tag.Result.Id)).ToListAsync(cancellationToken);
        }

        public async Task Save(Meet meet)
        {
            if (_context.Entry(meet).State == EntityState.Detached)
                _context.Meets.Add(meet);

            await _context.SaveChangesAsync();
        }
    }
}
