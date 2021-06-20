using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeetUp.WebApi.Models.Posts
{
    public class CreatePostBinding
    {
        public Guid Id { get; set; }
        public string Body { get; set; }
        public DateTime DateCreate { get; set; }
        public Guid Creator { get; set; }
    }
}
