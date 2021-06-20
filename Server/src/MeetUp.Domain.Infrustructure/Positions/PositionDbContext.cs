using MeetUp.Domain.Positions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetUp.Domain.Infrustructure.Positions
{
    public class PositionDbContext : DbContext
    {
        public PositionDbContext(DbContextOptions<PositionDbContext> options) : base(options) { }

        internal DbSet<Position> Positions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Position>(builder =>
            {
                builder.ToTable("Position");

                builder.HasKey(o => o.Id);
                builder.Property(o => o.Id)
                    .HasColumnName("Id")
                    .ValueGeneratedNever()
                    .IsRequired();

                builder.Property(o => o.Lat)
                    .HasMaxLength(36)
                    .IsRequired();

                builder.Property(o => o.Ing)
                    .HasMaxLength(36)
                    .IsRequired();
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
