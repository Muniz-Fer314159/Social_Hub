namespace Backend.Data;

using Backend.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

public class AppDbContext : IdentityDbContext<ApplicationUser>
{
    public AppDbContext(DbContextOptions<AppDbContext> options): base(options){ }
        public DbSet<Post> Posts {get; set;}
        public DbSet<Comment> Comments {get; set;}
        public DbSet<Like> Likes {get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        //Configure relationships from model like
        modelBuilder.Entity<Like>()
            .HasKey(l => new { l.PostId, l.UserId });

        modelBuilder.Entity<Like>()
            .HasOne (l => l.Post)
            .WithMany (p => p.Likes)
            .HasForeignKey (l => l.PostId);

        modelBuilder.Entity<Like>()
            .HasOne (l => l.User)
            .WithMany (u => u.Likes)
            .HasForeignKey (l => l.UserId);

        //Configure relationships from model comment
        modelBuilder.Entity<Comment>()
            .HasOne(c => c.User)
            .WithMany (u => u.Comments)
            .HasForeignKey (c => c.UserId)
            .OnDelete (DeleteBehavior.Cascade);

        modelBuilder.Entity<Comment>()
            .HasOne(c => c.Post)
            .WithMany (p => p.Comments)
            .HasForeignKey (c => c.PostId)
            .OnDelete (DeleteBehavior.Cascade);

        //Configure relationships from model post
        modelBuilder.Entity<Post>()
            .HasOne(p => p.User)
            .WithMany (u => u.Posts)
            .HasForeignKey (p => p.UserId)
            .OnDelete (DeleteBehavior.Cascade);

        


    }
    
}

