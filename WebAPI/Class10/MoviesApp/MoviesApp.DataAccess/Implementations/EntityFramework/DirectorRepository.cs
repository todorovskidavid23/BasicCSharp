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
    public class DirectorRepository : IDirectorRepository
    {
        private readonly MoviesAppDbContext _context;

        public DirectorRepository(MoviesAppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Director>> GetAllAsync()
        {
            return await _context.Directors.AsNoTracking().ToListAsync();
        }

        public async Task<Director?> GetByIdAsync(int id)
        {
            return await _context.Directors.FirstOrDefaultAsync(director => director.Id == id);
        }

        // Ендпоинт #11: режисер СО неговите филмови.
        // ThenInclude оди едно ниво подлабоко: Director -> Movies -> Genre,
        // за да можеме да го покажеме името на жанрот во MovieDto.
        public async Task<Director?> GetByIdWithMoviesAsync(int id)
        {
            return await _context.Directors
                .AsNoTracking()
                .Include(director => director.Movies)
                    .ThenInclude(movie => movie.Genre)
                .FirstOrDefaultAsync(director => director.Id == id);
        }

        public async Task<List<Director>> GetByIdsAsync(List<int> ids)
        {
            return await _context.Directors.Where(d => ids.Contains(d.Id)).ToListAsync();
        }

        public async Task AddAsync(Director entity)
        {
            _context.Directors.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Director entity)
        {
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Director entity)
        {
            _context.Directors.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
