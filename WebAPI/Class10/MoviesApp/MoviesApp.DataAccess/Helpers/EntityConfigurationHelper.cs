using Microsoft.EntityFrameworkCore;
using MoviesApp.Domain.Models;

namespace MoviesApp.DataAccess.Helpers;

// FLUENT API - сè за табелите, на едно место.
// internal static: овој helper не треба да го гледа никој надвор од DataAccess.
internal static class EntityConfigurationHelper
{
    public static void ConfigureGenre(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Genre>(entity =>
        {
            entity.ToTable("Genre");

            entity.Property(genre => genre.Name)
                  .IsRequired()
                  .HasMaxLength(50);

            // Уникатен индекс: базата физички одбива втор жанр со исто име.
            // Сервисот пред тоа ќе провери и ќе врати убав 409 - но индексот
            // е тој што нè покрива при два истовремени POST-а.
            entity.HasIndex(genre => genre.Name)
                  .IsUnique();
        });
    }

    public static void ConfigureDirector(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Director>(entity =>
        {
            entity.ToTable("Director");

            entity.Property(director => director.FirstName)
                  .IsRequired()
                  .HasMaxLength(50);

            entity.Property(director => director.LastName)
                  .IsRequired()
                  .HasMaxLength(50);

            // "date" наместо стандардниот "datetime2":
            // 3 бајти наместо 8, и нема скриен дел со часови што ги расипува споредбите.
            entity.Property(director => director.DateOfBirth)
                  .HasColumnType("date");
        });
    }

    public static void ConfigureActor(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Actor>(entity =>
        {
            entity.ToTable("Actor");

            entity.Property(actor => actor.FirstName)
                  .IsRequired()
                  .HasMaxLength(50);

            entity.Property(actor => actor.LastName)
                  .IsRequired()
                  .HasMaxLength(50);
        });
    }

    public static void ConfigureMovie(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Movie>(entity =>
        {
            entity.ToTable("Movie");

            entity.Property(movie => movie.Title)
                  .IsRequired()
                  .HasMaxLength(200);

            entity.Property(movie => movie.Description)
                  .IsRequired(false)
                  .HasMaxLength(1000);

            entity.Property(movie => movie.Year)
                  .IsRequired();

            entity.Property(movie => movie.DurationMinutes)
                  .IsRequired();

            // ===> 1:M  Genre -> Movie
            // Restrict: бришење на жанр што сè уште има филмови се ОДБИВА.
            // Cascade би ги избришал филмовите (катастрофа),
            // SetNull е невозможен зашто GenreId е NOT NULL.
            entity.HasOne(movie => movie.Genre)
                  .WithMany(genre => genre.Movies)
                  .HasForeignKey(movie => movie.GenreId)
                  .IsRequired()
                  .OnDelete(DeleteBehavior.Restrict);

            // ===> 1:M  Director -> Movie
            // SetNull: бришење на режисер ги остава филмовите, само без режисер.
            // Работи САМО затоа што DirectorId е int? (nullable).
            entity.HasOne(movie => movie.Director)
                  .WithMany(director => director.Movies)
                  .HasForeignKey(movie => movie.DirectorId)
                  .IsRequired(false)
                  .OnDelete(DeleteBehavior.SetNull);

            // ===> M:M  Movie <-> Actor
            // Краткиот облик .UsingEntity(j => j.ToTable("MovieActor")) исто работи,
            // но ги именува колоните по навигациите: "ActorsId" / "MoviesId".
            // Затоа ги пишуваме рачно - README бара MovieId и ActorId.
            entity.HasMany(movie => movie.Actors)
                  .WithMany(actor => actor.Movies)
                  .UsingEntity(
                      "MovieActor",
                      right => right.HasOne(typeof(Actor)).WithMany().HasForeignKey("ActorId"),
                      left => left.HasOne(typeof(Movie)).WithMany().HasForeignKey("MovieId"),
                      join => join.HasKey("MovieId", "ActorId")
                  );

            // Индекси на колоните по кои филтрираме најчесто.
            entity.HasIndex(movie => movie.GenreId);
            entity.HasIndex(movie => movie.Year);
        });
    }

    //SeedData - метод кој ќе се повика од OnModelCreating во MoviesDbContext за да се пополнат табелите со почетни податоци.
    public static void SeedData(this ModelBuilder modelBuilder)
    {
        // ===> Genres
        modelBuilder.Entity<Genre>().HasData(
            new Genre { Id = 1, Name = "Drama" },
            new Genre { Id = 2, Name = "Crime" },
            new Genre { Id = 3, Name = "Sci-Fi" },
            new Genre { Id = 4, Name = "Comedy" },
            new Genre { Id = 5, Name = "Action" }
        );

        // ===> Directors
        // Датумите се КОНСТАНТИ. DateTime.UtcNow тука би значел
        // нова вредност при секој Add-Migration.
        modelBuilder.Entity<Director>().HasData(
            new Director { Id = 1, FirstName = "Christopher", LastName = "Nolan", DateOfBirth = new DateTime(1970, 7, 30) },
            new Director { Id = 2, FirstName = "Quentin", LastName = "Tarantino", DateOfBirth = new DateTime(1963, 3, 27) },
            new Director { Id = 3, FirstName = "Frank", LastName = "Darabont", DateOfBirth = null }
        );

        // ===> Actors
        modelBuilder.Entity<Actor>().HasData(
            new Actor { Id = 1, FirstName = "Morgan", LastName = "Freeman" },
            new Actor { Id = 2, FirstName = "Tim", LastName = "Robbins" },
            new Actor { Id = 3, FirstName = "Leonardo", LastName = "DiCaprio" },
            new Actor { Id = 4, FirstName = "John", LastName = "Travolta" },
            new Actor { Id = 5, FirstName = "Samuel L.", LastName = "Jackson" },
            new Actor { Id = 6, FirstName = "Uma", LastName = "Thurman" }
        );

        // ===> Movies
        // Само GenreId / DirectorId - НИКОГАШ Genre = new Genre{...}.
        // HasData прима скалари и странски клучеви, не навигации.
        modelBuilder.Entity<Movie>().HasData(
            new Movie { Id = 1, Title = "The Shawshank Redemption", Description = "Two imprisoned men bond over a number of years.", Year = 1994, DurationMinutes = 142, GenreId = 1, DirectorId = 3 },
            new Movie { Id = 2, Title = "Pulp Fiction", Description = "The lives of two mob hitmen intertwine.", Year = 1994, DurationMinutes = 154, GenreId = 2, DirectorId = 2 },
            new Movie { Id = 3, Title = "Inception", Description = "A thief who steals corporate secrets through dream-sharing.", Year = 2010, DurationMinutes = 148, GenreId = 3, DirectorId = 1 },
            new Movie { Id = 4, Title = "Interstellar", Description = null, Year = 2014, DurationMinutes = 169, GenreId = 3, DirectorId = 1 },
            new Movie { Id = 5, Title = "Django Unchained", Description = "A freed slave sets out to rescue his wife.", Year = 2012, DurationMinutes = 165, GenreId = 2, DirectorId = 2 },
            new Movie { Id = 6, Title = "Se7en", Description = "Two detectives hunt a serial killer.", Year = 1995, DurationMinutes = 127, GenreId = 2, DirectorId = null },
            new Movie { Id = 7, Title = "The Dark Knight", Description = "Batman faces the Joker.", Year = 2008, DurationMinutes = 152, GenreId = 5, DirectorId = 1 },
            new Movie { Id = 8, Title = "The Grand Budapest Hotel", Description = null, Year = 2014, DurationMinutes = 99, GenreId = 4, DirectorId = null },
            new Movie { Id = 9, Title = "Kill Bill: Vol. 1", Description = "The Bride wakes from a coma and seeks revenge.", Year = 2003, DurationMinutes = 111, GenreId = 5, DirectorId = 2 }
        );

        // ===> MovieActor (join табелата)
        // Нема C# класа за неа, па ја адресираме по име, со анонимни објекти.
        modelBuilder.Entity("MovieActor").HasData(
            new { MovieId = 1, ActorId = 1 },
            new { MovieId = 1, ActorId = 2 },
            new { MovieId = 2, ActorId = 4 },   // Pulp Fiction - 3 актери
            new { MovieId = 2, ActorId = 5 },
            new { MovieId = 2, ActorId = 6 },
            new { MovieId = 3, ActorId = 3 },
            new { MovieId = 5, ActorId = 3 },
            new { MovieId = 5, ActorId = 5 },
            new { MovieId = 6, ActorId = 1 },
            new { MovieId = 7, ActorId = 1 },
            new { MovieId = 9, ActorId = 6 }
        );
        // Филмови 4 и 8 намерно немаат ниту еден актер.
    }
}