using System;

namespace MeetUp.DatabaseMigrations.Entities
{
    public class Tag
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
    }
}
