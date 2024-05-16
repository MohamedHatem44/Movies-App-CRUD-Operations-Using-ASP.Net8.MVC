using Microsoft.Extensions.DependencyInjection;
using MoviesApp.BL.Managers.Genres;
using MoviesApp.BL.Managers.Movies;

namespace MoviesApp.BL
{
    public static class ServicesExtensions
    {
        public static void AddBLServices(this IServiceCollection services)
        {
            /*------------------------------------------------------------------------*/
            services.AddScoped<IMovieManager, MovieManager>();
            services.AddScoped<IGenreManager, GenreManager>();
            /*------------------------------------------------------------------------*/
        }
    }
}
