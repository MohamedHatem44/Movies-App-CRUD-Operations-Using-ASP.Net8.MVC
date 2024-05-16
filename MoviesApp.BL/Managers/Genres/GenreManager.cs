using MoviesApp.BL.ViewModels.Genres;
using MoviesApp.DAL;
using MoviesApp.DAL.Data.Models;

namespace MoviesApp.BL.Managers.Genres
{
    public class GenreManager : IGenreManager
    {
        private readonly IUnitOfWork _unitOfWork;
        /*------------------------------------------------------------------------*/
        public GenreManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        /*------------------------------------------------------------------------*/
        // Get All Genres
        public async Task<IEnumerable<ReadGenreVM>> GetAllGenres()
        {
            IEnumerable<Genre> genres = await _unitOfWork.GenreRepository.GetAllAsync();
            IEnumerable<ReadGenreVM> genresVM = genres.Select(genre => new ReadGenreVM
            {
                Id = genre.Id,
                Name = genre.Name,
            });

            return genresVM;
            /*------------------------------------------------------------------------*/
        }
    }
}


