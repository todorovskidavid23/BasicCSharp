using MoviesApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesApp.DataAccess.Interfaces
{
    public interface IDirectorRepository : IRepository<Director>
    {
        Task<Director?> GetByIdWithMoviesAsync(int id);
    }
}
