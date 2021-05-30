using System;
using System.Collections.Generic;

namespace MeetUp.DatabaseMigrations.Entities
{
    public class Meet
    {
        public Guid Id { get; private set; }
        public Guid PositionId { get; private set; }
        public string Name { get; private set; }
        public List<Guid> Members { get; private set; }
        public DateTime DateOfStart { get; private set; }
        public List<Guid> Tags { get; private set; }
        public Guid CreatorId { get; private set; }
        public List<string> Images { get; private set; }
        public Guid PostId { get; private set; }
    }
}
