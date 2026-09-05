using Microsoft.EntityFrameworkCore;
using MoviesApp.DataAccess.Data;
using MoviesApp.DataAccess.Interfaces;
using MoviesApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesApp.DataAccess.Implementations.EntityFramework
{
    public class ActorRepository : IActorRepository
    {
        private readonly MoviesAppDbContext _context;

        public ActorRepository(MoviesAppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Actor>> GetAllAsync()
        {
            return await _context.Actors.AsNoTracking().ToListAsync();
        }

        // Ендпоинт #13: GET /api/actors?movieId=
        // Тргнуваме од Actors и филтрираме преку M:M навигацијата -
        // EF го преведува во EXISTS врз MovieActor.
        public async Task<List<Actor>> GetByMovieIdAsync(int movieId)
        {
            return await _context.Actors
                .AsNoTracking()
                .Where(actor => actor.Movies.Any(movie => movie.Id == movieId))
                .ToListAsync();
        }

        public async Task<Actor?> GetByIdAsync(int id)
        {
            return await _context.Actors.FirstOrDefaultAsync(actor => actor.Id == id);
        }

        public async Task<List<Actor>> GetByIdsAsync(List<int> ids)
        {
            return await _context.Actors.Where(actor => ids.Contains(actor.Id)).ToListAsync();
        }

        public async Task AddAsync(Actor entity)
        {
            _context.Actors.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Actor entity)
        {
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Actor entity)
        {
            _context.Actors.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
