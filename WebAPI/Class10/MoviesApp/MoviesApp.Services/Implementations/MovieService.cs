using MoviesApp.DataAccess.Interfaces;
using MoviesApp.Domain.Models;
using MoviesApp.Dtos;
using MoviesApp.Mappers;
using MoviesApp.Services.CustomExceptions;
using MoviesApp.Services.Interfaces;

namespace MoviesApp.Services.Implementations;

public class MovieService : IMovieService
{
    private readonly IMovieRepository _movieRepository;
    private readonly IGenreRepository _genreRepository;
    private readonly IDirectorRepository _directorRepository;
    private readonly IActorRepository _actorRepository;

    // Сите четири се ИНТЕРФЕЈСИ, сите доаѓаат преку DI.
    // Никаде new SomeRepository().
    public MovieService(
        IMovieRepository movieRepository,
        IGenreRepository genreRepository,
        IDirectorRepository directorRepository,
        IActorRepository actorRepository)
    {
        _movieRepository = movieRepository;
        _genreRepository = genreRepository;
        _directorRepository = directorRepository;
        _actorRepository = actorRepository;
    }

    public async Task<List<MovieDto>> GetAllMoviesAsync(int? genreId = null, int? year = null, string? title = null)
    {
        // Филтрите се предаваат НАДОЛУ во базата.
        // Сервисот не филтрира ништо сам.
        List<Movie> movies = await _movieRepository.GetAllFilteredAsync(genreId, year, title);

        return movies.ToMovieDtoList();
    }

    public async Task<MovieDetailsDto> GetMovieByIdAsync(int id)
    {
        Movie? movieDb = await _movieRepository.GetByIdAsync(id);

        if (movieDb is null)
        {
            // Фрламе, не враќаме null. Контролерот одлучува дека ова е 404.
            throw new MovieNotFoundException($"Movie with id {id} was not found.");
        }

        return movieDb.ToMovieDetailsDto();
    }

    public async Task<MovieDetailsDto> AddMovieAsync(AddMovieDto addMovieDto)
    {
        // 1) Валидација на бизнис правилата
        await ValidateGenreExistsAsync(addMovieDto.GenreId!.Value);
        await ValidateDirectorExistsAsync(addMovieDto.DirectorId);
        List<Actor> actors = await GetAndValidateActorsAsync(addMovieDto.ActorIds);

        // 2) Мапирање
        Movie newMovie = addMovieDto.ToMovie();
        newMovie.Actors = actors;

        // 3) Снимање
        await _movieRepository.AddAsync(newMovie);

        // 4) Повторно вчитување, за да ги имаме Genre и Director имињата
        //    во одговорот. Без ова, GenreName би бил празен стринг.
        Movie? savedMovie = await _movieRepository.GetByIdAsync(newMovie.Id);

        return savedMovie!.ToMovieDetailsDto();
    }

    public async Task UpdateMovieAsync(int id, UpdateMovieDto updateMovieDto)
    {
        // 1) Постои ли воопшто? -> 404
        Movie? movieDb = await _movieRepository.GetByIdAsync(id);

        if (movieDb is null)
        {
            throw new MovieNotFoundException($"Movie with id {id} was not found.");
        }

        // 2) Валидни ли се врските? -> 400
        await ValidateGenreExistsAsync(updateMovieDto.GenreId!.Value);
        await ValidateDirectorExistsAsync(updateMovieDto.DirectorId);
        List<Actor> actors = await GetAndValidateActorsAsync(updateMovieDto.ActorIds);

        // 3) Мапирање ВРЗ ПОСТОЕЧКИОТ трекиран ентитет.
        //    ApplyTo, не ToMovie - инаку SaveChanges не гледа промена.
        updateMovieDto.ApplyTo(movieDb);

        // Замена на целата колекција: EF ја споредува со старата и сам
        // генерира DELETE/INSERT врз MovieActor.
        movieDb.Actors.Clear();
        foreach (Actor actor in actors)
        {
            movieDb.Actors.Add(actor);
        }

        // 4) Снимање
        await _movieRepository.UpdateAsync(movieDb);
    }

    public async Task DeleteMovieAsync(int id)
    {
        Movie? movieDb = await _movieRepository.GetByIdAsync(id);

        if (movieDb is null)
        {
            throw new MovieNotFoundException($"Movie with id {id} was not found.");
        }

        await _movieRepository.DeleteAsync(movieDb);
    }

    // Ендпоинт #15: POST /api/movies/{movieId}/actors/{actorId}
    public async Task AddActorToMovieAsync(int movieId, int actorId)
    {
        Movie? movieDb = await _movieRepository.GetByIdAsync(movieId);
        if (movieDb is null)
        {
            throw new MovieNotFoundException($"Movie with id {movieId} was not found.");
        }

        Actor? actorDb = await _actorRepository.GetByIdAsync(actorId);
        if (actorDb is null)
        {
            throw new ActorNotFoundException($"Actor with id {actorId} was not found.");
        }

        // 409 ако веќе е кастиран. Композитниот PK во базата исто ќе го
        // одбие, но тука добиваме чиста порака наместо SqlException.
        bool alreadyCast = movieDb.Actors.Any(actor => actor.Id == actorId);
        if (alreadyCast)
        {
            throw new ConflictException(
                $"Actor with id {actorId} is already cast in movie with id {movieId}.");
        }

        movieDb.Actors.Add(actorDb);
        await _movieRepository.UpdateAsync(movieDb);
    }

    // Ендпоинт #16
    public async Task RemoveActorFromMovieAsync(int movieId, int actorId)
    {
        Movie? movieDb = await _movieRepository.GetByIdAsync(movieId);
        if (movieDb is null)
        {
            throw new MovieNotFoundException($"Movie with id {movieId} was not found.");
        }

        Actor? actorToRemove = movieDb.Actors.FirstOrDefault(actor => actor.Id == actorId);
        if (actorToRemove is null)
        {
            throw new ActorNotFoundException(
                $"Actor with id {actorId} is not cast in movie with id {movieId}.");
        }

        movieDb.Actors.Remove(actorToRemove);
        await _movieRepository.UpdateAsync(movieDb);
    }

    #region Private helpers

    private async Task ValidateGenreExistsAsync(int genreId)
    {
        Genre? genre = await _genreRepository.GetByIdAsync(genreId);

        if (genre is null)
        {
            // GenreNotFoundException, НЕ MovieNotFoundException.
            // Контролерот ќе го мапира во 400 (лошо тело), не 404 (лоша рута).
            throw new GenreNotFoundException($"Genre with id {genreId} does not exist.");
        }
    }

    private async Task ValidateDirectorExistsAsync(int? directorId)
    {
        // null е валидно - филм смее да нема режисер.
        if (!directorId.HasValue)
        {
            return;
        }

        Director? director = await _directorRepository.GetByIdAsync(directorId.Value);

        if (director is null)
        {
            throw new DirectorNotFoundException(
                $"Director with id {directorId.Value} does not exist.");
        }
    }

    private async Task<List<Actor>> GetAndValidateActorsAsync(List<int> actorIds)
    {
        if (actorIds is null || actorIds.Count == 0)
        {
            return new List<Actor>();
        }

        // ЕДЕН query за сите id-а: WHERE Id IN (...).
        // Не јамка со GetByIdAsync - тоа е N+1 проблемот.
        List<Actor> actors = await _actorRepository.GetByIdsAsync(actorIds);

        // Ако вратил помалку отколку што баравме, некој id не постои.
        if (actors.Count != actorIds.Distinct().Count())
        {
            List<int> foundIds = actors.Select(actor => actor.Id).ToList();
            List<int> missingIds = actorIds.Distinct().Except(foundIds).ToList();

            throw new ActorNotFoundException(
                $"Actor(s) with id(s) {string.Join(", ", missingIds)} do not exist.");
        }

        return actors;
    }

    #endregion
}