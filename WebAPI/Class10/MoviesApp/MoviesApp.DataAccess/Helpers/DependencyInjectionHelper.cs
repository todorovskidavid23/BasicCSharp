using Microsoft.Extensions.DependencyInjection;
using MoviesApp.DataAccess.Implementations.EntityFramework;
using MoviesApp.DataAccess.Interfaces;

namespace MoviesApp.DataAccess.Helpers;

public static class DependencyInjectionHelper
{
    public static void AddRepositories(this IServiceCollection services)
    {
        // repositories доаѓаат во следните чекори
        services.AddScoped<IMovieRepository, MovieRepository>();        // EF Core
        //services.AddScoped<IMovieRepository, MovieRepositoryDapper>(); // Dapper - бонус
        services.AddScoped<IGenreRepository, GenreRepository>();
        services.AddScoped<IDirectorRepository, DirectorRepository>();
        services.AddScoped<IActorRepository, ActorRepository>();
    }

    public static void AddApplicationServices(this IServiceCollection services)
    {
        // services доаѓаат во следните чекори
    }
}