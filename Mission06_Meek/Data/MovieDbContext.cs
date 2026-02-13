using Microsoft.EntityFrameworkCore;
using Mission06_Meek.Models;

namespace Mission06_Meek.Data;

public class MovieDbContext(DbContextOptions<MovieDbContext> options) : DbContext(options)
{
    public DbSet<Movie> Movies => Set<Movie>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Movie>().HasData(
            new Movie
            {
                MovieId = 1,
                Category = "Drama",
                Title = "The Shawshank Redemption",
                Year = 1994,
                Director = "Frank Darabont",
                Rating = "R",
                Edited = false,
                LentTo = null,
                Notes = "Classic"
            },
            new Movie
            {
                MovieId = 2,
                Category = "Sci-Fi",
                Title = "Interstellar",
                Year = 2014,
                Director = "Christopher Nolan",
                Rating = "PG-13",
                Edited = false,
                LentTo = null,
                Notes = "Great score"
            },
            new Movie
            {
                MovieId = 3,
                Category = "Animation",
                Title = "Spider-Man: Into the Spider-Verse",
                Year = 2018,
                Director = "Bob Persichetti",
                Rating = "PG",
                Edited = false,
                LentTo = null,
                Notes = "Rewatchable"
            }
        );
    }
}
