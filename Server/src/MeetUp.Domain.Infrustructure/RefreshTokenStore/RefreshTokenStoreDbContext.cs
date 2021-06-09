using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetUp.Domain.Infrustructure.RefreshTokenStore
{
    public sealed class RefreshTokenStoreDbContext : DbContext
    {
        public RefreshTokenStoreDbContext(DbContextOptions<RefreshTokenStoreDbContext> options) : base(options) { }

        internal DbSet<RefreshToken> RefreshTokens { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RefreshToken>(builder =>
            {
                builder.ToTable("RefreshToken");

                builder.HasKey(o => o.Id);
                builder.Property(o => o.Id)
                    .HasColumnName("RefreshTokenId")
                    .HasMaxLength(64)
                    .ValueGeneratedNever();

                builder.Property(o => o.UserId)
                    .IsRequired();
                builder.Property(o => o.Expire)
                    .IsRequired();
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
