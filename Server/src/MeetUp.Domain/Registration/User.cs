using System;

namespace MeetUp.Domain.Registration
{
    public sealed class User
    {
        public Guid Id { get; }
        public string Login { get; private set; }
        public string PasswordHash { get; private set; }
        public int Level { get; private set; }
        public string NumberPhone { get; private set; }
        public string Email { get; private set; }
        public AuthType AuthType { get; private set; }
        public Guid IdAttribute { get; }
        public DateTime DateCreate { get; private set; }
        public DateTime DateLastEdit { get; private set; }

        private User() { }
        public User(Guid id, string login, string password, int level, string numberPhone, string email,AuthType authType, Guid idAttrubite, DateTime dateCreate, DateTime dateLastEdit)
        {
            Id = id;
            Login = login;
            PasswordHash = password;
            Level = level;
            NumberPhone = numberPhone;
            Email = email;
            AuthType = authType;
            IdAttribute = idAttrubite;
            DateCreate = dateCreate;
            DateLastEdit = dateLastEdit;
        }
    }
}
