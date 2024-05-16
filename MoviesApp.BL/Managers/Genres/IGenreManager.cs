using MoviesApp.BL.ViewModels.Genres;

namespace MoviesApp.BL.Managers.Genres
{
    public interface IGenreManager
    {
        /*------------------------------------------------------------------------*/
        // Get All Genres
        Task<IEnumerable<ReadGenreVM>> GetAllGenres();
        /*------------------------------------------------------------------------*/
    }
}

