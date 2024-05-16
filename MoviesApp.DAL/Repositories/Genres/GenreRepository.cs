using MoviesApp.DAL.Data.Context;
using MoviesApp.DAL.Data.Models;
using MoviesApp.DAL.Repositories.Generic;

namespace MoviesApp.DAL.Repositories.Genres
{
    public class GenreRepository : GenericRepository<Genre>, IGenreRepository
    {
        public GenreRepository(MoviesContext context) : base(context)
        {
        }
    }
}
