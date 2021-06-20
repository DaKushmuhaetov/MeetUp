using MeetUp.Domain.Registration;
using Microsoft.EntityFrameworkCore;

namespace MeetUp.Domain.Infrustructure.Registration
{
    public sealed class RegistrationDbContext : DbContext
    {
        public RegistrationDbContext(DbContextOptions<RegistrationDbContext> options) : base(options) { }

        internal DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(builder =>
            {
                builder.ToTable("User");

                builder.HasKey(o => o.Id);
                builder.Property(o => o.Id)
                    .HasColumnName("Id")
                    .ValueGeneratedNever()
                    .IsRequired();

                builder.Property(o => o.Email)
                    .HasMaxLength(512)
                    .IsRequired();

                builder.Property(o => o.Level)
                    .IsRequired();

                builder.Property(o => o.Login)
                   .HasMaxLength(512)
                   .IsRequired();

                builder.Property(o => o.AuthType)
                    .IsRequired();

                builder.Property(o => o.NumberPhone)
                   .HasMaxLength(12);

                builder.Property(o => o.DateCreate)
                    .IsRequired();

                builder.Property(o => o.DateLastEdit)
                   .IsRequired();

                builder.Property(o => o.PasswordHash)
                    .HasMaxLength(1024)
                    .IsRequired();

                builder.HasKey(o => o.IdAttribute);
                builder.Property(o => o.IdAttribute)
                    .HasColumnName("IdAttribute")
                    .ValueGeneratedNever()
                    .IsRequired();

            });

            modelBuilder.Entity<UserAttribute>(builder =>
            {
                builder.ToTable("UserAttribute");

                builder.HasKey(o => o.Id);
                builder.Property(o => o.Id)
                    .HasColumnName("Id")
                    .ValueGeneratedNever()
                    .IsRequired();

                builder.Property(o => o.FirstName)
                    .HasMaxLength(124)
                    .IsRequired();

                builder.Property(o => o.MiddleName)
                   .HasMaxLength(124)
                   .IsRequired();

                builder.Property(o => o.LastName)
                   .HasMaxLength(124);

                builder.Property(o => o.DateOfBirth)
                    .IsRequired();
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
