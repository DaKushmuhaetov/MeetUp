using System;
using System.Collections.Generic;

namespace MeetUp.DatabaseMigrations.Entities
{
    public class Post
    {
        public Guid Id { get; private set; }
        public string Body { get; private set; }
        public DateTime DateCreate { get; private set; }
        public List<Guid> Likes { get; private set; }
        public List<Guid> Reposts { get; private set; }
        public Guid CreatorId { get; private set; }
    }
}
