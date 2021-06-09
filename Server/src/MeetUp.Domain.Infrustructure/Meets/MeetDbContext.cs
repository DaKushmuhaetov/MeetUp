using MeetUp.Domain.Meets;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text.Json;

namespace MeetUp.Domain.Infrustructure.Meets
{
    public class MeetDbContext : DbContext
    {
        public MeetDbContext(DbContextOptions<MeetDbContext> options) : base(options) { }

        internal DbSet<Meet> Meets { get; set; }
        internal DbSet<Post> Posts { get; set; }
        internal DbSet<Tag> Tags { get; set; }
        internal DbSet<Position> Positions { get; set; }

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

                builder.Property(o => o.Description)
                    .HasMaxLength(2024);

                builder.Property(o => o.Members)
                    .HasConversion(
                        _ => JsonSerializer.Serialize(_, null),
                        _ => JsonSerializer.Deserialize<List<Guid>>(_, null))
                    .IsRequired(false);

                builder.Property(o => o.DateOfStart)
                    .IsRequired();

                builder.Property(o => o.Tags)
                    .IsRequired(false);

                builder.Property(o => o.CreatorId)
                    .HasColumnName("CreatorId")
                    .ValueGeneratedNever()
                    .IsRequired();

                builder.Property(o => o.Images)
                    .IsRequired(false);

                builder.Property(o => o.PostId)
                    .HasColumnName("PostId")
                    .ValueGeneratedNever()
                    .IsRequired();
            });

            modelBuilder.Entity<Post>(builder =>
            {
                builder.ToTable("Post");

                builder.HasKey(o => o.Id);
                builder.Property(o => o.Id)
                    .HasColumnName("Id")
                    .ValueGeneratedNever()
                    .IsRequired();

                builder.Property(o => o.Body)
                    .IsRequired();

                builder.Property(o => o.DateCreate)
                    .IsRequired();
            });

            modelBuilder.Entity<Tag>(builder =>
            {
                builder.ToTable("Tag");

                builder.HasKey(o => o.Id);
                builder.Property(o => o.Id)
                    .HasColumnName("Id")
                    .ValueGeneratedNever()
                    .IsRequired();

                builder.Property(o => o.Name)
                    .HasMaxLength(112)
                    .IsRequired();

            });

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

