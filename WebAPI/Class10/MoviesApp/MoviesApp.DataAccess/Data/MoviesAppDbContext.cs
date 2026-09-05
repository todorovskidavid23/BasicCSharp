using Microsoft.EntityFrameworkCore;
using MoviesApp.DataAccess.Helpers;
using MoviesApp.Domain.Models;

namespace MoviesApp.DataAccess.Data;

/// <summary>
/// Нашата база, гледано од C#. Прави две работи:
/// 1) секој DbSet станува табела,
/// 2) OnModelCreating() кажува како изгледаат тие табели.
/// </summary>
public class MoviesAppDbContext : DbContext
{
    // Опциите (provider + connection string) ги噢 доставува Program.cs преку DI.
    // Никогаш не ги градиме тука.
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
        // ===> Конфигурација на ентитетите
        modelBuilder.ConfigureGenre();
        modelBuilder.ConfigureDirector();
        modelBuilder.ConfigureActor();
        modelBuilder.ConfigureMovie();

        // ===> Seed податоци (доаѓа во следниот чекор)
        modelBuilder.SeedData();

        base.OnModelCreating(modelBuilder);
    }
}