using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MoviesApp.DAL.Data.Context;
using MoviesApp.DAL.Repositories.Genres;
using MoviesApp.DAL.Repositories.Movies;

namespace MoviesApp.DAL
{
    public static class ServicesExtensions
    {
        public static void AddDALServices(this IServiceCollection services, IConfiguration configuration)
        {
            /*------------------------------------------------------------------------*/
            var connectionString = configuration.GetConnectionString("MoviesAppDb");
            services.AddDbContext<MoviesContext>(options => options.UseSqlServer(connectionString));
            /*------------------------------------------------------------------------*/
            services.AddScoped<IMovieRepository, MovieRepository>();
            services.AddScoped<IGenreRepository, GenreRepository>();
            /*------------------------------------------------------------------------*/
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            /*------------------------------------------------------------------------*/
        }
    }
}
