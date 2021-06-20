using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetUp.Queries.Meets
{
    public class MeetListQuery : PageQuery<MeetListItemView>
    {
        public Guid? CreatorId { get; }
        public IEnumerable<Guid?> Tags { get; }

        public MeetListQuery(Guid? сreatorId, IEnumerable<Guid?> tags, int offset, int limit) : base(offset, limit)
        {
            CreatorId = сreatorId;
            Tags = tags;
        }
    }
}
