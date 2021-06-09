using MeetUp.Shared.CQRS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetUp.Queries.Users
{
    public sealed class UserQuery : IQuery<UserView>
    {
        public Guid Id { get; }

        public UserQuery(Guid id)
        {
            Id = id;
        }
    }
}
