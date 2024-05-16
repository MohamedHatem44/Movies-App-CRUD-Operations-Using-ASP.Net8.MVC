using MoviesApp.DAL.Repositories.Genres;
using MoviesApp.DAL.Repositories.Movies;

namespace MoviesApp.DAL
{
    public interface IUnitOfWork
    {
        /*------------------------------------------------------------------------*/
        public IMovieRepository MovieRepository { get; }
        public IGenreRepository GenreRepository { get; }
        /*------------------------------------------------------------------------*/
        void SaveChanges();
        /*------------------------------------------------------------------------*/
    }
}
