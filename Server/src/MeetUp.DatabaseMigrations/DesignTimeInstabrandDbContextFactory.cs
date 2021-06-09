using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetUp.DatabaseMigrations
{
    public sealed class DesignTimeStreamingDbContextFactory : IDesignTimeDbContextFactory<MeetUpDbContext>
    {
        public MeetUpDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<MeetUpDbContext>();
            optionsBuilder.UseNpgsql("migrations");
            return new MeetUpDbContext(optionsBuilder.Options);
        }
    }
}
