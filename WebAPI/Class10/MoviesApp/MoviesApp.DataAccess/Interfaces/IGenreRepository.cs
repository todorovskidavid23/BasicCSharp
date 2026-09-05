using MoviesApp.Domain.Models;
using MoviesApp.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesApp.DataAccess.Interfaces
{
    public interface IGenreRepository : IRepository<Genre>
    {
        // Проекција во SQL - враќа DTO директно, како GetAllByPriorityAsync кај NotesApp.
        Task<List<GenreDto>> GetAllWithMovieCountAsync();

        Task<bool> NameExistsAsync(string name, int? excludeId = null);

        Task<bool> HasMoviesAsync(int genreId);
    }
}
