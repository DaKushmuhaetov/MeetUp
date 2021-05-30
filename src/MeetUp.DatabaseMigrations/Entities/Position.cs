using System;

namespace MeetUp.DatabaseMigrations.Entities
{
    public class Position
    {
        public Guid Id { get; private set; }
        public string Lat { get; private set; }
        public string Ing { get; private set; }
    }
}
