using MoviesApp.BL.ViewModels.Movies;
using MoviesApp.DAL.Data.Models;

namespace MoviesApp.BL.Managers.Movies
{
    public interface IMovieManager
    {
        /*------------------------------------------------------------------------*/
        // Get All Moives
        Task<IEnumerable<ReadMovieVM>> GetAllMoives();
        /*------------------------------------------------------------------------*/
        // Populate a select list with Genres
        Task<MovieFormVM> GetGenresVMAsync();
        /*------------------------------------------------------------------------*/
        // Get a Specific Moive By Id
        ReadMovieVM? GetMoiveById(int id);
        /*------------------------------------------------------------------------*/
        // Get a Specific Movie With Details By Id
        ReadMovieVM? GetMoiveByIdWithDetails(int id);
        /*------------------------------------------------------------------------*/
        // Create a New Moive
        public void CreateMovie(MemoryStream posterStream, MovieFormVM movieFormVM);
        /*------------------------------------------------------------------------*/
        // Get Movie For Edit By Id
        public MovieFormVM? GetForEditById(int id);
        /*------------------------------------------------------------------------*/
        // Update a Specific Moive By Id
        void UpdateMoive(MemoryStream posterStream, MovieFormVM movieFormVM);
        /*------------------------------------------------------------------------*/
        // Delete a Specific Moive By Id
        void DeleteMoive(int id);
        /*------------------------------------------------------------------------*/
    }
}
