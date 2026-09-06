using MoviesApp.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesApp.Services.Interfaces
{
    public interface IGenreService
    {
        Task<List<GenreDto>> GetAllGenresAsync();
        Task<GenreDto> AddGenreAsync(AddGenreDto addGenreDto);
        Task DeleteGenreAsync(int id);
    }
}
