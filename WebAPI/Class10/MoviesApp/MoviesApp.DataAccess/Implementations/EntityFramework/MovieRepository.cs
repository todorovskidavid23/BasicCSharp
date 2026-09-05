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
    public class MovieRepository : IMovieRepository
    {
        private readonly MoviesAppDbContext _context;

        public MovieRepository(MoviesAppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Movie>> GetAllAsync()
        {
            return await _context.Movies
                .AsNoTracking()
                .Include(movie => movie.Genre)
                .Include(movie => movie.Director)
                .ToListAsync();
        }

        // ===================================================================
        // ЈАДРОТО НА ВЕЖБАТА: филтрирање во базата, не во меморија.
        // ===================================================================
        public async Task<List<Movie>> GetAllFilteredAsync(int? genreId, int? year, string? title)
        {
            // 1) Почни со IQueryable - тоа е РЕЦЕПТ за query, не самиот query.
            //    Базата сè уште не е допрена.
            IQueryable<Movie> query = _context.Movies
                .AsNoTracking()
                .Include(movie => movie.Genre)
                .Include(movie => movie.Director);

            // 2) Додавај филтри само за параметрите што имаат вредност.
            //    Секој .Where() се додава на истиот рецепт - не се извршува.
            if (genreId.HasValue)
            {
                query = query.Where(movie => movie.GenreId == genreId.Value);
            }

            if (year.HasValue)
            {
                query = query.Where(movie => movie.Year == year.Value);
            }

            if (!string.IsNullOrWhiteSpace(title))
            {
                query = query.Where(movie => movie.Title.Contains(title));
            }

            // Погледни што ќе се испрати - корисно при дебагирање.
            // string sql = query.ToQueryString();

            // 3) ToListAsync() ЕДНАШ, на крајот. Тука се одвива единствениот
            //    контакт со базата, со сите WHERE услови споени во еден SQL.
            return await query.ToListAsync();
        }

        public async Task<Movie?> GetByIdAsync(int id)
        {
            // БЕЗ AsNoTracking - овој метод го користи и PUT.
            // Ентитетот мора да е трекиран за SaveChangesAsync да ја види промената.
            return await _context.Movies
                .Include(movie => movie.Genre)
                .Include(movie => movie.Director)
                .Include(movie => movie.Actors)
                .FirstOrDefaultAsync(movie => movie.Id == id);
        }

        public async Task<List<Movie>> GetByIdsAsync(List<int> ids)
        {
            return await _context.Movies
                .Where(movie => ids.Contains(movie.Id))
                .ToListAsync();
        }

        public async Task<bool> ExistsAsync(int id)
        {
            // AnyAsync праќа SELECT CASE WHEN EXISTS(...) - не влече ниту еден ред.
            return await _context.Movies.AnyAsync(movie => movie.Id == id);
        }

        public async Task AddAsync(Movie entity)
        {
            _context.Movies.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Movie entity)
        {
            // Update() не е потребен: ентитетот доаѓа од GetByIdAsync,
            // значи веќе е трекиран и change tracker-от ги знае измените.
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Movie entity)
        {
            _context.Movies.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
