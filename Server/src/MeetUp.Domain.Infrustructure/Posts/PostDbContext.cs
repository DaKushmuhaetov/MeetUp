using MeetUp.Domain.Posts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetUp.Domain.Infrustructure.Posts
{
    public class PostDbContext : DbContext
    {
        public PostDbContext(DbContextOptions<PostDbContext> options) : base(options) { }
        
        internal DbSet<Post> Posts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
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

            base.OnModelCreating(modelBuilder);
        }
    }
}
