using Microsoft.EntityFrameworkCore;
using Mission06_Meek.Models;

namespace Mission06_Meek.Data;

public class MovieDbContext(DbContextOptions<MovieDbContext> options) : DbContext(options)
{
    public DbSet<Movie> Movies => Set<Movie>();
    public DbSet<Category> Categories => Set<Category>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Movie>()
            .HasOne(movie => movie.Category)
            .WithMany(category => category.Movies)
            .HasForeignKey(movie => movie.CategoryId);
    }
}
