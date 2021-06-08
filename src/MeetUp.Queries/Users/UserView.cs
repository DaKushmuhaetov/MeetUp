using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetUp.Queries.Users
{
    public sealed class UserView 
    {
        public Guid Id { get; }
        public string Login { get; private set; }
        public int Level { get; private set; }
        public string FirstName { get; private set; }
        public string MiddleName { get; private set; }
        public string LastName { get; private set; }
        public string Hobby { get; private set; }
        public DateTime DateOfBirth { get; private set; }
    }
}
