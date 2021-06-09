using MeetUp.Queries.Meets;
using MeetUp.Shared.CQRS;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MeetUp.Queries.Infrustructure.Meets
{
    public sealed class MeetQueryHandler : IQueryHandler<MeetQuery, MeetView>
    {
        private readonly MeetDbContext _context;

        public MeetQueryHandler(MeetDbContext context)
        {
            _context = context;
        }

        public async Task<MeetView> Handle(MeetQuery query, CancellationToken cancellationToken)
        {
            var meet = await _context.Meets
                .AsNoTracking()
                .Where(o => o.Id == query.Id)
                .Select(o => new MeetView
                {
                    Id = o.Id,
                    DateOfStart = o.DateOfStart,
                    CreatorId = o.CreatorId,
                    Images = o.Images,
                    Members = o.Members,
                    Name = o.Name,
                    PositionId = o.PositionId,
                    PostId = o.PostId,
                    Tags = o.Tags
                })
                .SingleOrDefaultAsync();

            return meet;
        }
    }
}
