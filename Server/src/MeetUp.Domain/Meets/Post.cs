using System;

namespace MeetUp.Domain.Meets
{
    public class Post
    {
        public Guid Id { get; }
        public string Body { get; private set; }
        public DateTime DateCreate { get; private set; }
        public Guid Creator { get; private set; }

        private Post() { }
        public Post(Guid id, string body, DateTime dateCreate, Guid creator)
        {
            Id = id;
            Body = body;
            DateCreate = dateCreate;
            Creator = creator;
        }
    }
}
