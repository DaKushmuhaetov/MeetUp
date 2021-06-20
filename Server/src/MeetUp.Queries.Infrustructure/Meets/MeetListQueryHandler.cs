using MeetUp.Queries.Meets;
using MeetUp.Shared.CQRS;
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

        MeetListQueryHandler(MeetDbContext context)
        {
            context = _context;
        }

        public async Task<Page<MeetListItemView>> Handle(MeetListQuery query, CancellationToken cancellationToken)
        {
            IQueryable<Meet> items;

            if (query.CreatorId != null)
            {
                items = _context.Meets.Where(o => o.CreatorId == query.CreatorId);
            }
            if(query.Tags != null)
            {
                items = _context.Meets.Where(o => o.Tags.Any(k => query.Tags.Contains(k)));
            }
            else
            {
                items = _context.Meets;
            }

            return new Page<MeetListItemView>
            {
                Limit = query.Limit,
                Offset = query.Offset,
                Total = items.Count(),
                Items = (IEnumerable<MeetListItemView>)items
                    .Skip(query.Offset)
                    .Take(query.Limit)
            };
        }
    }
}
