using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetUp.Domain.Positions
{
    public sealed class Position
    {
        public Guid Id { get; }
        public string Lat { get; private set; }
        public string Ing { get; private set; }

        private Position() { }
        public Position(Guid id, string lat, string ing)
        {
            Id = id;
            Lat = lat;
            Ing = ing;
        }
    }
}
