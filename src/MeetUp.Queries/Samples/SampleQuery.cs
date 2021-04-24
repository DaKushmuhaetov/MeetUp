using MeetUp.Shared.CQRS;
using System;
using System.Collections.Generic;
using System.Text;

namespace MeetUp.Queries.Samples
{
    public sealed class SampleQuery : IQuery<SampleView>
    {
        public Guid Id { get; }

        public SampleQuery(Guid id)
        {
            Id = id;
        }
    }
}
