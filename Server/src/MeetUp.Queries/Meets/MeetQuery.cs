using MeetUp.Shared.CQRS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetUp.Queries.Meets
{
    public sealed class MeetQuery : IQuery<MeetView>
    {
        public Guid Id { get; }

        public MeetQuery(Guid id)
        {
            Id = id;
        }
    }
}
