using MoviesApp.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesApp.Services.Interfaces
{
    // Ниту еден IActionResult, ниту еден статус код.
    // Овој интерфејс мора да е повикувачки од конзолна апликација.
    public interface IMovieService
    {
        Task<List<MovieDto>> GetAllMoviesAsync(int? genreId = null, int? year = null, string? title = null);
        Task<MovieDetailsDto> GetMovieByIdAsync(int id);
        Task<MovieDetailsDto> AddMovieAsync(AddMovieDto addMovieDto);
        Task UpdateMovieAsync(int id, UpdateMovieDto updateMovieDto);
        Task DeleteMovieAsync(int id);

        // Ендпоинти #15 и #16
        Task AddActorToMovieAsync(int movieId, int actorId);
        Task RemoveActorFromMovieAsync(int movieId, int actorId);
    }
}
