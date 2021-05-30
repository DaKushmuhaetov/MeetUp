using MeetUp.Domain.Authentication;
using Microsoft.EntityFrameworkCore;

namespace MeetUp.Domain.Infrustructure.Authentication
{
    public sealed class AuthenticationDbContext : DbContext
    {
        public AuthenticationDbContext(DbContextOptions<AuthenticationDbContext> options) : base(options) { }

        internal DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(builder =>
            {
                builder.ToTable("User");

                builder.HasKey(o => o.Id);
                builder.Property(o => o.Id)
                    .HasColumnName("UserId")
                    .ValueGeneratedNever()
                    .IsRequired();

                builder.Property(o => o.Email)
                    .HasMaxLength(512)
                    .IsRequired();

                builder.Property(o => o.Login)
                   .HasMaxLength(512)
                   .IsRequired();

                builder.Property(o => o.NumberPhone)
                   .HasMaxLength(10)
                   .IsRequired();

                builder.Property(o => o.PasswordHash)
                    .HasMaxLength(1024)
                    .IsRequired();
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
