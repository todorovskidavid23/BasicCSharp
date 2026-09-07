using Microsoft.EntityFrameworkCore;
using MoviesApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MoviesApp.DataAccess.Helpers
{
    internal static class EntityConfigurationHelper
    {
        public static void ConfigureMovie(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>(entity =>
            {
                entity.ToTable("Movie");

                entity.Property(movie => movie.Title)
                      .IsRequired()
                      .HasMaxLength(200);

                entity.Property(movie => movie.Description)
                      .HasMaxLength(1000);

                entity.Property(movie => movie.Year)
                      .IsRequired();

                entity.Property(movie => movie.DurationMinutes)
                      .IsRequired();

                // Genre -> Movie (1:M)
                entity.HasOne(movie => movie.Genre)
                      .WithMany(genre => genre.Movies)
                      .HasForeignKey(movie => movie.GenreId);
                //.OnDelete(DeleteBehavior.Restrict);

                // Director -> Movie (1:M)
                entity.HasOne(movie => movie.Director)
                      .WithMany(director => director.Movies)
                      .HasForeignKey(movie => movie.DirectorId);
                      //.OnDelete(DeleteBehavior.SetNull);

                // Movie -> Actor (M:M)
                entity.HasMany(movie => movie.Actors)
                      .WithMany(actor => actor.Movies)
                      .UsingEntity(
                          "MovieActor",
                          right => right.HasOne(typeof(Actor))
                                         .WithMany()
                                         .HasForeignKey("ActorId"),
                          left => left.HasOne(typeof(Movie))
                                       .WithMany()
                                       .HasForeignKey("MovieId")
                      );

                // Indexes
                entity.HasIndex(movie => movie.GenreId);
                entity.HasIndex(movie => movie.Year);
            });
        }


        public static void ConfigureGenre(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Genre>(entity =>
            {
                entity.ToTable("Genre");

                entity.Property(genre => genre.Name)
                      .IsRequired()
                      .HasMaxLength(50);

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

    }
}
