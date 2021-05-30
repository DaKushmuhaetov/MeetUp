using System;
using System.Collections.Generic;

namespace MeetUp.Domain.Meets
{
    public class Meet
    {
        public Guid Id { get; }
        public Guid PositionId { get; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public List<Guid> Members { get; private set; }
        public DateTime DateOfStart { get; private set; }
        public List<Guid> Tags { get; private set; }
        public Guid CreatorId { get; private set; }
        public List<string> Images { get; private set; }
        public Guid PostId { get; }

        private Meet() { }
        public Meet(Guid id, Guid positionId, string name, string description, List<Guid> members, DateTime dateOfStart, List<Guid> tags, Guid creator, List<string> images, Guid postId)
        {
            Id = id;
            PositionId = positionId;
            Name = name;
            Members = members;
            DateOfStart = dateOfStart;
            Tags = tags;
            CreatorId = creator;
            Images = images;
            PostId = postId;
        }
    }
}
