using System;
using System.Collections.Generic;
using System.Text;

namespace MeetUp.Queries.Samples
{
    public sealed class SampleListQuery : PageQuery<SampleListItemView>
    {
        public Guid OwnerId { get; }

        public SampleListQuery(Guid ownerId, int offset, int limit) : base(offset, limit)
        {
            OwnerId = ownerId;
        }
    }
}
