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
    public class MeetListQueryHandler : IQueryHandler<MeetListQuery, Page<MeetListItemView>>
    {
        private readonly MeetDbContext _context;

        public MeetListQueryHandler(MeetDbContext context)
        {
            _context = context;
        }

        public async Task<Page<MeetListItemView>> Handle(MeetListQuery query, CancellationToken cancellationToken)
        {
            IQueryable<Meet> items = _context.Meets.AsNoTracking();

            if (query.CreatorId != null)
            {
                items = items.Where(o => o.CreatorId == query.CreatorId);
            }
            if(query.Tags != null)
            {
                items = items.Where(o => o.Tags.Any(k => query.Tags.Contains(k)));
            }
            else
            {
                items = _context.Meets;
            }
            var response = items.Select(o => new MeetListItemView
            {
                CreatorId = o.CreatorId,
                DateOfStart = o.DateOfStart,
                Id = o.Id,
                Images = o.Images,
                Members = o.Members,
                Name = o.Name,
                PositionId = o.PositionId,
                PostId = o.PostId,
                Tags = o.Tags
            });

            return new Page<MeetListItemView>
            {
                Limit = query.Limit,
                Offset = query.Offset,
                Total = await response.CountAsync(cancellationToken),
                Items = await response
                    .Skip(query.Offset)
                    .Take(query.Limit)
                    .ToListAsync(cancellationToken)
            };
        }
    }
}
