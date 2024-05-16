using MoviesApp.DAL.Data.Context;
using MoviesApp.DAL.Repositories.Genres;
using MoviesApp.DAL.Repositories.Movies;

namespace MoviesApp.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        /*------------------------------------------------------------------------*/
        public readonly MoviesContext _context;
        /*------------------------------------------------------------------------*/
        public IMovieRepository MovieRepository { get; }
        public IGenreRepository GenreRepository { get; }
        /*------------------------------------------------------------------------*/
        public UnitOfWork(IMovieRepository movieRepository, IGenreRepository genreRepository, MoviesContext context)
        {
            MovieRepository = movieRepository;
            GenreRepository = genreRepository;
            _context = context;
        }
        /*------------------------------------------------------------------------*/
        public void SaveChanges()
        {
            _context.SaveChanges();
        }
        /*------------------------------------------------------------------------*/
    }
}
