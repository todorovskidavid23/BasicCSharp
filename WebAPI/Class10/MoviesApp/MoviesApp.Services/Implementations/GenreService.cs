using MoviesApp.DataAccess.Interfaces;
using MoviesApp.Domain.Models;
using MoviesApp.Dtos;
using MoviesApp.Mappers;
using MoviesApp.Services.CustomExceptions;
using MoviesApp.Services.Interfaces;

namespace MoviesApp.Services.Implementations;

public class GenreService : IGenreService
{
    private readonly IGenreRepository _genreRepository;

    public GenreService(IGenreRepository genreRepository)
    {
        _genreRepository = genreRepository;
    }

    public async Task<List<GenreDto>> GetAllGenresAsync()
    {
        // Проекцијата веќе враќа GenreDto со COUNT пресметан во SQL.
        return await _genreRepository.GetAllWithMovieCountAsync();
    }

    public async Task<GenreDto> AddGenreAsync(AddGenreDto addGenreDto)
    {
        // 409, не 400 и не SqlException.
        bool nameExists = await _genreRepository.NameExistsAsync(addGenreDto.Name);

        if (nameExists)
        {
            throw new ConflictException($"A genre named '{addGenreDto.Name}' already exists.");
        }

        Genre newGenre = addGenreDto.ToGenre();
        await _genreRepository.AddAsync(newGenre);

        return newGenre.ToGenreDto();
    }

    public async Task DeleteGenreAsync(int id)
    {
        // 1) Постои ли? -> 404
        Genre? genreDb = await _genreRepository.GetByIdAsync(id);
        if (genreDb is null)
        {
            throw new GenreNotFoundException($"Genre with id {id} was not found.");
        }

        // 2) Има ли филмови? -> 409, и НИШТО не се брише.
        //    Ова е парот на DeleteBehavior.Restrict: базата исто ќе одбие,
        //    но сакаме чиста порака наместо SqlException.
        bool hasMovies = await _genreRepository.HasMoviesAsync(id);
        if (hasMovies)
        {
            throw new ConflictException(
                $"Genre with id {id} cannot be deleted because it still has movies.");
        }

        await _genreRepository.DeleteAsync(genreDb);
    }
}