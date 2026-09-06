using MoviesApp.Dtos;

namespace MoviesApp.Services.Interfaces
{
    public interface IActorService
    {
        Task<List<ActorDto>> GetActorsAsync(int? movieId = null);
        Task<ActorDto> AddActorAsync(AddActorDto addActorDto);
    }
}
