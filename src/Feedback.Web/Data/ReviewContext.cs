using Feedback.Web.Entities;
using Microsoft.EntityFrameworkCore;

namespace Feedback.Web.Data;

public class ReviewContext : DbContext
{
    public DbSet<Review> Reviews { get; set; }
    
    
    
    public ReviewContext(DbContextOptions<ReviewContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Primary keys
        
        modelBuilder.Entity<Review>().HasKey(x => x.Id);

        


    }
}