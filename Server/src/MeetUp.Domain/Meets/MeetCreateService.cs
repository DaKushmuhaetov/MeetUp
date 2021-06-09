using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MeetUp.Domain.Meets
{
    public class MeetCreateService
    {
        public async Task<Meet> CreateMeet(Guid positionId, string nameMeet, string description, DateTime dateOfStart, List<Guid> tags, Guid creator, List<string> images, Guid postId, CancellationToken cancellationToken)
        {
            var members = new List<Guid>();
            members.Add(creator);

            return new Meet(new Guid(), positionId, description, nameMeet, members, dateOfStart, tags, creator, images, postId);
        }

        public async Task<Position> CreatePosition(string lat, string ing)
        {
            return new Position(new Guid(), lat, ing);
        }

        public async Task<Post> CreatePost(string bodyPost, Guid creatorId)
        {
            return new Post(new Guid(), bodyPost, DateTime.Now, creatorId);
        }

        public async Task<Tag> CreateTag(string name)
        {
            return new Tag(new Guid(), name);
        }
    }
}
