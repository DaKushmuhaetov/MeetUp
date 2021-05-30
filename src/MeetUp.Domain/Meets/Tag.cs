using System;

namespace MeetUp.Domain.Meets
{
    public class Tag
    {
        public Guid Id { get; }
        public string Name { get; private set; }

        private Tag() { }
        public Tag(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
