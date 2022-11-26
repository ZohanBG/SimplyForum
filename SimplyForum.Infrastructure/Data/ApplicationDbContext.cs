using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using SimplyForum.Infrastructure.Data.Models;

namespace SimplyForum.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; } = null!;


        public DbSet<Community> Communities { get; set; } = null!;


        public DbSet<Post> Posts { get; set; } = null!;


        public DbSet<Comment> Comments { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Post>(p =>
            {
                p.HasOne(p => p.Community)
                .WithMany(p => p.Posts)
                .HasForeignKey(p => p.CommunityId)
                .OnDelete(DeleteBehavior.NoAction);
            });

            builder.Entity<Comment>(c =>
            {
                c.HasOne(c => c.Post)
                .WithMany(c => c.Comments)
                .HasForeignKey(c => c.PostId)
                .OnDelete(DeleteBehavior.NoAction);
            });

            base.OnModelCreating(builder);
        }
    }
}