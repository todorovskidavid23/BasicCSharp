using MoviesApp.DataAccess.Interfaces;
using MoviesApp.Domain.Models;
using MoviesApp.Dtos;
using MoviesApp.Mappers;
using MoviesApp.Services.CustomExceptions;
using MoviesApp.Services.Interfaces;

namespace MoviesApp.Services.Implementations;

public class ActorService : IActorService
{
    private readonly IActorRepository _actorRepository;
    private readonly IMovieRepository _movieRepository;

    public ActorService(IActorRepository actorRepository, IMovieRepository movieRepository)
    {
        _actorRepository = actorRepository;
        _movieRepository = movieRepository;
    }

    public async Task<List<ActorDto>> GetActorsAsync(int? movieId = null)
    {
        if (!movieId.HasValue)
        {
            List<Actor> allActors = await _actorRepository.GetAllAsync();
            return allActors.ToActorDtoList();
        }

        // Ендпоинт #13 наведува 400 како неуспех - значи непостоечки
        // movieId е лош ПАРАМЕТАР, не ненајден ресурс.
        bool movieExists = await _movieRepository.ExistsAsync(movieId.Value);
        if (!movieExists)
        {
            throw new MovieNotFoundException($"Movie with id {movieId.Value} does not exist.");
        }

        List<Actor> actors = await _actorRepository.GetByMovieIdAsync(movieId.Value);
        return actors.ToActorDtoList();
    }

    public async Task<ActorDto> AddActorAsync(AddActorDto addActorDto)
    {
        Actor newActor = addActorDto.ToActor();
        await _actorRepository.AddAsync(newActor);

        return newActor.ToActorDto();
    }
}