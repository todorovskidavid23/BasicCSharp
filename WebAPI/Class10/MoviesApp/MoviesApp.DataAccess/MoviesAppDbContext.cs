using Microsoft.EntityFrameworkCore;
using MoviesApp.Domain.Models;

namespace MoviesApp.DataAccess
{
    public class MoviesAppDbContext : DbContext
    {
        public MoviesAppDbContext(DbContextOptions<MoviesAppDbContext> options)
        : base(options)
        {
        }


        public DbSet<Movie> Movies { get; set; } = null!;
        public DbSet<Genre> Genres { get; set; } = null!;
        public DbSet<Director> Directors { get; set; } = null!;
        public DbSet<Actor> Actors { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(
                typeof(MoviesAppDbContext).Assembly);
        }

    }    
}
