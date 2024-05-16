using Microsoft.EntityFrameworkCore;
using MoviesApp.DAL.Data.Context;
using MoviesApp.DAL.Data.Models;
using MoviesApp.DAL.Repositories.Generic;

namespace MoviesApp.DAL.Repositories.Movies
{
    public class MovieRepository : GenericRepository<Movie>, IMovieRepository
    {
        /*------------------------------------------------------------------------*/
        public MovieRepository(MoviesContext context) : base(context)
        {
        }
        /*------------------------------------------------------------------------*/
        // Get Movie By Id With Genre
        public Movie? GetMovieByIdWithGenre(int id)
        {
            return _context.Set<Movie>()
                .Include(movie => movie.Genre)
                .SingleOrDefault(movie => movie.Id == id);
        }
        /*------------------------------------------------------------------------*/
    }
}
