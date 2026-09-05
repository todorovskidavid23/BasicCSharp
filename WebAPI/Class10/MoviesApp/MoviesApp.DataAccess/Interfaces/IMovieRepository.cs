using MoviesApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesApp.DataAccess.Interfaces
{
    public interface IMovieRepository : IRepository<Movie>
    {
        Task<List<Movie>> GetAllFilteredAsync(int? genreId, int? year, string? title);
        Task<bool> ExistsAsync(int id);
    }
}
