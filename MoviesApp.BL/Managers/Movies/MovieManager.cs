using MoviesApp.BL.ViewModels.Movies;
using MoviesApp.DAL;
using MoviesApp.DAL.Data.Models;
using System.Reflection;

namespace MoviesApp.BL.Managers.Movies
{
    public class MovieManager : IMovieManager
    {
        /*------------------------------------------------------------------------*/
        private readonly IUnitOfWork _unitOfWork;
        /*------------------------------------------------------------------------*/
        public MovieManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        /*------------------------------------------------------------------------*/
        // Get All Moives
        public async Task<IEnumerable<ReadMovieVM>> GetAllMoives()
        {
           var movies = await _unitOfWork.MovieRepository.GetAllAsync();
           var moviesVM = movies.Select(m => new ReadMovieVM
            {
                Id = m.Id,
                Title = m.Title,
                Year = m.Year,
                Rate = m.Rate,
                Storyline = m.Storyline,
                Poster = m.Poster
            }).ToList();

            return moviesVM;
        }
        /*------------------------------------------------------------------------*/
        // Populate a select list with Genres
        public async Task<MovieFormVM> GetGenresVMAsync()
        {
            var genres = await _unitOfWork.GenreRepository.GetAllAsync();
            var viewModel = new MovieFormVM
            {
                Genres = genres.OrderBy(m => m.Name)
            };
            return viewModel;
        }
        /*------------------------------------------------------------------------*/
        // Get a Specific Moive By Id
        public ReadMovieVM? GetMoiveById(int id)
        {
            var movie = _unitOfWork.MovieRepository.GetById(id);
            if (movie is null)
                return null;

            return new ReadMovieVM
            {
                Id = movie.Id,
                Title = movie.Title,
                Year = movie.Year,
                Rate = movie.Rate,
                Storyline = movie.Storyline,
                Poster = movie.Poster
            };
        }
        /*------------------------------------------------------------------------*/
        // Get a Specific Movie With Details By Id
        public ReadMovieVM? GetMoiveByIdWithDetails(int id)
        {
            var movie = _unitOfWork.MovieRepository.GetMovieByIdWithGenre(id);
            if (movie is null)
                return null;

            return new ReadMovieVM
            {
                Id = movie.Id,
                Title = movie.Title,
                Year = movie.Year,
                Rate = movie.Rate,
                Storyline = movie.Storyline,
                Poster = movie.Poster,
                GenreId = movie.GenreId,
                Genre = movie.Genre,
            };
        }
        /*------------------------------------------------------------------------*/
        // Create a New Moive
        public void CreateMovie(MemoryStream posterStream, MovieFormVM movieFormVM)
        {
            var movie = new Movie
            {
                Title = movieFormVM.Title,
                GenreId = movieFormVM.GenreId,
                Year = movieFormVM.Year,
                Rate = movieFormVM.Rate,
                Storyline = movieFormVM.Storyline,
                Poster = posterStream.ToArray()
            };
            _unitOfWork.MovieRepository.Create(movie);
            _unitOfWork.SaveChanges();
        }
        /*------------------------------------------------------------------------*/
        // Get Movie For Edit By Id
        public MovieFormVM? GetForEditById(int id)
        {
            var movie = _unitOfWork.MovieRepository.GetMovieByIdWithGenre(id);
            if (movie is null)
                return null;
            var genres = _unitOfWork.GenreRepository.GetAllAsync();

            return new MovieFormVM
            {
                Id = movie.Id,
                Title = movie.Title,
                Year = movie.Year,
                Rate = movie.Rate,
                Storyline = movie.Storyline,
                Poster = movie.Poster,
                GenreId = movie.GenreId,
                Genres = genres.Result
            };
        }
        /*------------------------------------------------------------------------*/
        // Update a Specific Moive By Id
        public void UpdateMoive(MemoryStream posterStream, MovieFormVM movieFormVM)
        {
            if (movieFormVM is null)
                return;
            var movie = _unitOfWork.MovieRepository.GetById(movieFormVM.Id);
            if (movie is null)
                return;

            movie.Title = movieFormVM.Title;
            movie.GenreId = movieFormVM.GenreId;
            movie.Year = movieFormVM.Year;
            movie.Rate = movieFormVM.Rate;
            movie.Storyline = movieFormVM.Storyline;
            movie.Poster = posterStream.ToArray();

            _unitOfWork.MovieRepository.Update(movie);
            _unitOfWork.SaveChanges();
        }
        /*------------------------------------------------------------------------*/
        // Delete a Specific Moive By Id
        public void DeleteMoive(int id)
        {
            var movie = _unitOfWork.MovieRepository.GetById(id);
            if (movie is null)
                return;
            _unitOfWork.MovieRepository.Delete(movie);
            _unitOfWork.SaveChanges();
        }
        /*------------------------------------------------------------------------*/
    }
}
