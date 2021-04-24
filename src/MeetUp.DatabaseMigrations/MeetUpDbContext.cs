using MeetUp.DatabaseMigrations.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MeetUp.DatabaseMigrations
{
    public sealed class MeetUpDbContext : DbContext
    {
        public MeetUpDbContext(DbContextOptions<MeetUpDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(builder =>
            {
                builder.ToTable("User");

                builder.HasKey(o => o.Id);
                builder.Property(o => o.Id)
                    .ValueGeneratedNever()
                    .IsRequired();

                builder.Property(o => o.Email)
                    .HasMaxLength(512)
                    .IsRequired();

                builder.HasIndex(o => o.Email)
                    .IsUnique();

                builder.Property(o => o.DateCreate)
                    .IsRequired();

                builder.Property(o => o.DateLastEdit)
                    .IsRequired();

                builder.Property(o => o.PasswordHash)
                   .HasMaxLength(1024)
                   .IsRequired();

                builder.Property(o => o.Level)
                    .IsRequired();

                builder.Property(o => o.Login)
                    .HasMaxLength(36)
                    .IsRequired();

                builder.Property(o => o.NumberPhone);

                builder.Property(o => o.IdAttribute)
                    .IsRequired();

            });
        }
    }
}
