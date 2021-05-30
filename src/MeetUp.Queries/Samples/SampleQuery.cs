using MeetUp.Shared.CQRS;
using System;

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
