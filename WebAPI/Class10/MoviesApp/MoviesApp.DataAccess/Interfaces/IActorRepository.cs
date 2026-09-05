using MoviesApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesApp.DataAccess.Interfaces
{
    public interface IActorRepository : IRepository<Actor>
    {
        Task<List<Actor>> GetByMovieIdAsync(int movieId);
    }
}
