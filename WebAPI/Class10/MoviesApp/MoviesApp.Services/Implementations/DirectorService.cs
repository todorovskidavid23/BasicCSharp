using MoviesApp.DataAccess.Interfaces;
using MoviesApp.Domain.Models;
using MoviesApp.Dtos;
using MoviesApp.Mappers;
using MoviesApp.Services.CustomExceptions;
using MoviesApp.Services.Interfaces;

namespace MoviesApp.Services.Implementations;

public class DirectorService : IDirectorService
{
    private readonly IDirectorRepository _directorRepository;

    public DirectorService(IDirectorRepository directorRepository)
    {
        _directorRepository = directorRepository;
    }

    public async Task<List<DirectorDto>> GetAllDirectorsAsync()
    {
        List<Director> directors = await _directorRepository.GetAllAsync();
        return directors.ToDirectorDtoList();
    }

    public async Task<DirectorDetailsDto> GetDirectorByIdAsync(int id)
    {
        Director? directorDb = await _directorRepository.GetByIdWithMoviesAsync(id);

        if (directorDb is null)
        {
            throw new DirectorNotFoundException($"Director with id {id} was not found.");
        }

        return directorDb.ToDirectorDetailsDto();
    }

    public async Task<DirectorDto> AddDirectorAsync(AddDirectorDto addDirectorDto)
    {
        Director newDirector = addDirectorDto.ToDirector();
        await _directorRepository.AddAsync(newDirector);

        return newDirector.ToDirectorDto();
    }
}