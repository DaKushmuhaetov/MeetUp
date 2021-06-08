using MeetUp.Shared.CQRS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetUp.Queries.Posts
{
    public sealed class PostQuery : IQuery<PostView>
    {
        public Guid Id { get; }

        public PostQuery(Guid id)
        {
            Id = id;
        }
    }
}
