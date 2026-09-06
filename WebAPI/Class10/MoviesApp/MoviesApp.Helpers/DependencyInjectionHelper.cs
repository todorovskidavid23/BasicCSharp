using Microsoft.Extensions.DependencyInjection;
using MoviesApp.DataAccess.Implementations.EntityFramework;
using MoviesApp.DataAccess.Interfaces;
using MoviesApp.Services.Implementations;
using MoviesApp.Services.Interfaces;

namespace MoviesApp.Helpers;

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
        services.AddScoped<IMovieService, MovieService>();
        services.AddScoped<IGenreService, GenreService>();
        services.AddScoped<IDirectorService, DirectorService>();
        services.AddScoped<IActorService, ActorService>();

    }
}