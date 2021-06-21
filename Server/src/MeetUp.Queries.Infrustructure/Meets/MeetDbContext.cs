using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MeetUp.Queries.Infrustructure.Meets
{
    public sealed class MeetDbContext : DbContext
    {
        public MeetDbContext(DbContextOptions<MeetDbContext> options) : base(options) { }

        internal DbSet<Meet> Meets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Meet>(builder =>
            {
                builder.ToTable("Meet");

                builder.HasKey(o => o.Id);
                builder.Property(o => o.Id)
                    .HasColumnName("Id")
                    .ValueGeneratedNever()
                    .IsRequired();

                builder.Property(o => o.PositionId)
                    .HasColumnName("PositionId")
                    .ValueGeneratedNever()
                    .IsRequired();

                builder.Property(o => o.Name)
                    .HasMaxLength(512)
                    .IsRequired();

                builder.Property(o => o.Members)
                     .HasConversion(
                         _ => JsonSerializer.Serialize(_, null),
                         _ => JsonSerializer.Deserialize<List<Guid>>(_, null))
                     .IsRequired(false);

                builder.Property(o => o.DateOfStart)
                    .IsRequired();

                builder.Property(o => o.Description);

                builder.Property(o => o.Tags);

                builder.Property(o => o.CreatorId)
                    .HasColumnName("CreatorId")
                    .ValueGeneratedNever()
                    .IsRequired();

                builder.Property(o => o.Images);

                builder.Property(o => o.PostId)
                    .HasColumnName("PostId")
                    .ValueGeneratedNever()
                    .IsRequired();
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
