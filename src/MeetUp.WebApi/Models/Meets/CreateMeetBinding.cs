using System;
using System.Collections.Generic;

namespace MeetUp.WebApi.Models.Meets
{
    public class CreateMeetBinding
    {
        public string Lat { get; set; }
        public string Ing { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateOfstart { get; set; }
        public List<Guid> Tags { get; set; }
        public Guid CreatorId { get; set; }
        public List<string> Images { get; set; }
    }
}
