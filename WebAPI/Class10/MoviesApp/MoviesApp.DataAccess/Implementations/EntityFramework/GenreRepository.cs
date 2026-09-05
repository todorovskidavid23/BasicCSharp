using Microsoft.EntityFrameworkCore;
using MoviesApp.DataAccess.Data;
using MoviesApp.DataAccess.Interfaces;
using MoviesApp.Domain.Models;
using MoviesApp.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesApp.DataAccess.Implementations.EntityFramework
{
    public class GenreRepository : IGenreRepository
    {
        private readonly MoviesAppDbContext _context;

        public GenreRepository(MoviesAppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Genre>> GetAllAsync()
        {
            return await _context.Genres.AsNoTracking().ToListAsync();
        }

        // Ендпоинт #7: листа со број на филмови по жанр.
        // Проекција со .Select() - бројот се пресметува во SQL со COUNT,
        // не со вчитување на сите филмови во меморија.
        public async Task<List<GenreDto>> GetAllWithMovieCountAsync()
        {
            return await _context.Genres
                .AsNoTracking()
                .Select(genre => new GenreDto
                {
                    Id = genre.Id,
                    Name = genre.Name,
                    MovieCount = genre.Movies.Count   // -> (SELECT COUNT(*) FROM Movie ...)
                })
                .ToListAsync();
        }

        public async Task<Genre?> GetByIdAsync(int id)
        {
            return await _context.Genres.FirstOrDefaultAsync(genre => genre.Id == id);
        }

        public async Task<List<Genre>> GetByIdsAsync(List<int> ids)
        {
            return await _context.Genres.Where(genre => ids.Contains(genre.Id)).ToListAsync();
        }

        // excludeId служи за update: "постои ли ДРУГ жанр со ова име".
        public async Task<bool> NameExistsAsync(string name, int? excludeId = null)
        {
            IQueryable<Genre> query = _context.Genres.Where(genre => genre.Name == name);

            if (excludeId.HasValue)
            {
                query = query.Where(genre => genre.Id != excludeId.Value);
            }

            return await query.AnyAsync();
        }

        public async Task<bool> HasMoviesAsync(int genreId)
        {
            // Ендпоинт #9: DELETE жанр што сè уште има филмови -> 409.
            return await _context.Movies.AnyAsync(movie => movie.GenreId == genreId);
        }

        public async Task AddAsync(Genre entity)
        {
            _context.Genres.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Genre entity)
        {
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Genre entity)
        {
            _context.Genres.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
