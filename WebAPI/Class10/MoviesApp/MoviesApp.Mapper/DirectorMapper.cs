using MoviesApp.Domain.Models;
using MoviesApp.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesApp.Mappers
{
    public static class DirectorMapper
    {
        public static DirectorDto ToDirectorDto(this Director director)
        {
            return new DirectorDto
            {
                Id = director.Id,
                FirstName = director.FirstName,
                LastName = director.LastName,
                FullName = $"{director.FirstName} {director.LastName}",
                DateOfBirth = director.DateOfBirth
            };
        }

        public static DirectorDetailsDto ToDirectorDetailsDto(this Director director)
        {
            return new DirectorDetailsDto
            {
                Id = director.Id,
                FirstName = director.FirstName,
                LastName = director.LastName,
                FullName = $"{director.FirstName} {director.LastName}",
                DateOfBirth = director.DateOfBirth,
                Movies = director.Movies?.ToMovieDtoList() ?? new List<MovieDto>()
            };
        }

        public static List<DirectorDto> ToDirectorDtoList(this IEnumerable<Director> directors)
            => directors.Select(director => director.ToDirectorDto()).ToList();

        public static Director ToDirector(this AddDirectorDto dto)
        {
            return new Director
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                DateOfBirth = dto.DateOfBirth
            };
        }
    }
}
