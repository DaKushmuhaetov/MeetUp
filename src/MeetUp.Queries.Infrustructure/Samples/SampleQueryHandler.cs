using MeetUp.Queries.Samples;
using MeetUp.Shared.CQRS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MeetUp.Queries.Infrustructure.Samples
{
    public sealed class SampleQueryHandler : IQueryHandler<SampleQuery, SampleView>
    {
        public async Task<SampleView> Handle(SampleQuery query, CancellationToken cancellationToken)
        {
            return new SampleView
            {
                Id = new Guid("180a5b1c-9877-4a3d-9737-6928a756ea55"),
                Title = "Test title"
            };
        }
    }
}
