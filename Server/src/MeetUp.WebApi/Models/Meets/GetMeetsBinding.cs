using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeetUp.WebApi.Models.Meets
{
    public class GetMeetsBinding
    {
        public Guid? CreatorId { get; set; }
        public IEnumerable<Guid?> Tags { get; set; }
        public int Offset { get; set; }
        public int Limit { get; set; }
    }
}
