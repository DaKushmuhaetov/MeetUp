using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetUp.Queries.Meets
{
    public sealed class MeetView
    {
        public Guid Id { get; set; }
        public Guid PositionId { get;set; }
        public string Name { get; set; }
        public List<Guid> Members { get; set; }
        public DateTime DateOfStart { get; set; }
        public List<Guid> Tags { get; set; }
        public Guid CreatorId { get; set; }
        public List<string> Images { get; set; }
        public Guid PostId { get; set; }
    }
}
