using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetUp.Queries.Infrustructure.Meets
{
    public sealed class Meet
    {
        public Guid Id { get; private set; }
        public Guid PositionId { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public List<Guid> Members { get; private set; }
        public DateTime DateOfStart { get; private set; }
        public List<Guid> Tags { get; private set; }
        public Guid CreatorId { get; private set; }
        public List<string> Images { get; private set; }
        public Guid PostId { get; private set; }
    }
}
