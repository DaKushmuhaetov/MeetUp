using System;
using System.Collections.Generic;

namespace MeetUp.DatabaseMigrations.Entities
{
    public sealed class User
    {
        public Guid Id { get; }
        public string Login { get; private set; }
        public string PasswordHash { get; private set; }
        public int Level { get; private set; }
        public string NumberPhone { get; private set; }
        public string Email { get; private set; }
        public Guid IdAttribute { get; }
        public DateTime DateCreate { get; private set; }
        public DateTime DateLastEdit { get; private set; }
        public List<Guid> LikePosts { get; private set; }
        public List<Guid> RepostPosts { get; private set; }
    }
}
