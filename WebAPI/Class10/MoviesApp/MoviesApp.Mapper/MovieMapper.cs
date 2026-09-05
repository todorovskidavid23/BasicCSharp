using MoviesApp.Domain.Models;
using MoviesApp.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesApp.Mappers
{
    public static class MovieMapper
    {
        public static MovieDto ToMovieDto(this Movie movie)
        {
            return new MovieDto
            {
                Id = movie.Id,
                Title = movie.Title,
                Description = movie.Description,
                Year = movie.Year,
                DurationMinutes = movie.DurationMinutes,

                // Навигациите се null ако не се Include-ирани.
                // Затоа секој ?. тука е потсетник дека репозиториумот
                // мора да го направи своето.
                GenreName = movie.Genre?.Name ?? string.Empty,
                DirectorFullName = movie.Director is null
                    ? null
                    : $"{movie.Director.FirstName} {movie.Director.LastName}"
            };
        }

        public static MovieDetailsDto ToMovieDetailsDto(this Movie movie)
        {
            return new MovieDetailsDto
            {
                Id = movie.Id,
                Title = movie.Title,
                Description = movie.Description,
                Year = movie.Year,
                DurationMinutes = movie.DurationMinutes,
                GenreName = movie.Genre?.Name ?? string.Empty,
                DirectorFullName = movie.Director is null
                    ? null
                    : $"{movie.Director.FirstName} {movie.Director.LastName}",
                Actors = movie.Actors?.ToActorDtoList() ?? new List<ActorDto>()
            };
        }

        public static List<MovieDto> ToMovieDtoList(this IEnumerable<Movie> movies)
            => movies.Select(movie => movie.ToMovieDto()).ToList();

        public static Movie ToMovie(this AddMovieDto dto)
        {
            // .Value е безбедно: [Required] веќе ги отфрли null вредностите
            // пред кодот воопшто да стигне до сервисот.
            return new Movie
            {
                Title = dto.Title,
                Description = dto.Description,
                Year = dto.Year!.Value,
                DurationMinutes = dto.DurationMinutes!.Value,
                GenreId = dto.GenreId!.Value,
                DirectorId = dto.DirectorId,
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow
            };
        }

        // ApplyTo, како кај NotesApp: менува ПОСТОЕЧКИ tracked ентитет,
        // не прави нов. Клучно за да работи EF change tracking-от при PUT.
        public static void ApplyTo(this UpdateMovieDto dto, Movie existingMovie)
        {
            existingMovie.Title = dto.Title;
            existingMovie.Description = dto.Description;
            existingMovie.Year = dto.Year!.Value;
            existingMovie.DurationMinutes = dto.DurationMinutes!.Value;
            existingMovie.GenreId = dto.GenreId!.Value;
            existingMovie.DirectorId = dto.DirectorId;
            existingMovie.UpdatedDate = DateTime.UtcNow;
        }
    }
}
