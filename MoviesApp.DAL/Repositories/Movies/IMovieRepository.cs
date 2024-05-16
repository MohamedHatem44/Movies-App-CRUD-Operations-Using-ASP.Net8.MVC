using Microsoft.EntityFrameworkCore;
using MoviesApp.DAL.Data.Models;
using MoviesApp.DAL.Repositories.Generic;

namespace MoviesApp.DAL.Repositories.Movies
{
    public interface IMovieRepository : IGenericRepository<Movie>
    {
        /*------------------------------------------------------------------------*/
        // Get Movie By Id With Genre
        public Movie? GetMovieByIdWithGenre(int id);
        /*------------------------------------------------------------------------*/
    }
}
