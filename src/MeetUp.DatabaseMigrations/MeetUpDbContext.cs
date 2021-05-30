using MeetUp.DatabaseMigrations.Entities;
using Microsoft.EntityFrameworkCore;

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

                builder.Property(o => o.Members);

                builder.Property(o => o.DateOfStart)
                    .IsRequired();

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

                builder.Property(o => o.Likes);

                builder.Property(o => o.Reposts);

                builder.Property(o => o.CreatorId)
                    .HasColumnName("CreatorId")
                    .ValueGeneratedNever()
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
        }
    }
}
