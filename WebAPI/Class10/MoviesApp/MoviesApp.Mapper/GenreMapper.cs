using MoviesApp.Domain.Models;
using MoviesApp.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesApp.Mappers
{
    public static class GenreMapper
    {
        public static GenreDto ToGenreDto(this Genre genre)
        {
            return new GenreDto
            {
                Id = genre.Id,
                Name = genre.Name,
                // Работи само ако Movies е Include-ирано; инаку е 0.
                // Затоа GET /api/genres ќе го пресмета во SQL, не тука.
                MovieCount = genre.Movies?.Count ?? 0
            };
        }

        public static List<GenreDto> ToGenreDtoList(this IEnumerable<Genre> genres)
            => genres.Select(genre => genre.ToGenreDto()).ToList();

        public static Genre ToGenre(this AddGenreDto dto)
            => new Genre { Name = dto.Name };
    }
}
