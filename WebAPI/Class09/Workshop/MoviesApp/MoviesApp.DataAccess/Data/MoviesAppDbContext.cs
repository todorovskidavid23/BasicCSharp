using Microsoft.EntityFrameworkCore;
using MoviesApp.DataAccess.Helpers;
using MoviesApp.Domain.Models;

namespace MoviesApp.DataAccess.Data
{
    public class MoviesAppDbContext : DbContext
    {
        public MoviesAppDbContext(DbContextOptions<MoviesAppDbContext> options) : base(options)
        {
        }

        public DbSet<Actor> Actors { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Movie> Movies { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ConfigureMovie();
            modelBuilder.ConfigureGenre();
            modelBuilder.ConfigureDirector();
            modelBuilder.ConfigureActor();
        }
    }
}
