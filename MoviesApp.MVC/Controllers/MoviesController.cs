using MoviesApp.BL.ViewModels.Movies;
using Microsoft.AspNetCore.Mvc;
using MoviesApp.BL.Managers.Movies;
using NToastNotify;

namespace MoviesApp.MVC.Controllers
{
    public class MoviesController : Controller
    {
        /*------------------------------------------------------------------------*/
        private readonly IMovieManager _movieManager;
        private readonly IToastNotification _toastNotification;
        private List<string> _allowedExtenstions = new List<string> { ".jpg", ".png" };
        private long _maxAllowedPosterSize = 1048576;
        /*------------------------------------------------------------------------*/
        public MoviesController(IMovieManager movieManager, IToastNotification toastNotification)
        {
            _movieManager = movieManager;
            _toastNotification = toastNotification;
        }
        /*------------------------------------------------------------------------*/
        // Get All Moives
        public async Task<IActionResult> Index()
        {
            var movies = await _movieManager.GetAllMoives();
            return View(movies);
        }
        /*------------------------------------------------------------------------*/
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var viewModel = await _movieManager.GetGenresVMAsync();
            return View("MovieForm", viewModel);
        }
        /*------------------------------------------------------------------------*/
        // Create a New Moive
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MovieFormVM movieFormVM)
        {
            var files = Request.Form.Files;

            if (!files.Any())
            {
                var viewModel = await _movieManager.GetGenresVMAsync();
                movieFormVM.Genres = viewModel.Genres;
                ModelState.AddModelError("Poster", "Please select movie poster!");
                return View("MovieForm", movieFormVM);
            }

            var poster = files.FirstOrDefault();

            if (!_allowedExtenstions.Contains(Path.GetExtension(poster.FileName).ToLower()))
            {
                var viewModel = await _movieManager.GetGenresVMAsync();
                movieFormVM.Genres = viewModel.Genres;
                ModelState.AddModelError("Poster", "Only .PNG, .JPG images are allowed!");
                return View("MovieForm", movieFormVM);
            }

            if (poster.Length > _maxAllowedPosterSize)
            {
                var viewModel = await _movieManager.GetGenresVMAsync();
                movieFormVM.Genres = viewModel.Genres;
                ModelState.AddModelError("Poster", "Poster cannot be more than 1 MB!");
                return View("MovieForm", movieFormVM);
            }

            using var dataStream = new MemoryStream();
            await poster.CopyToAsync(dataStream);

            _movieManager.CreateMovie(dataStream, movieFormVM);
            _toastNotification.AddSuccessToastMessage("Movie created successfully");
            return RedirectToAction(nameof(Index));
        }
        /*------------------------------------------------------------------------*/
        // Get Movie With Details
        [HttpGet]
        public IActionResult Details(int id)
        {
            var movie = _movieManager.GetMoiveByIdWithDetails(id);

            if (movie == null)
                return NotFound();

            return View(movie);
        }
        /*------------------------------------------------------------------------*/
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var viewModel = _movieManager.GetForEditById(id);

            if (viewModel == null)
                return NotFound();
            return View("MovieForm", viewModel);
        }
        /*------------------------------------------------------------------------*/
        // Update a Specific Moive By Id
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(MovieFormVM movieFormVM)
        {
            var movie = _movieManager.GetMoiveById(movieFormVM.Id);

            if (movie == null)
                return NotFound();

            var files = Request.Form.Files;

            if (files.Any())
            {
                var poster = files.FirstOrDefault();

                using var dataStream = new MemoryStream();

                await poster.CopyToAsync(dataStream);

                movieFormVM.Poster = dataStream.ToArray();

                if (!_allowedExtenstions.Contains(Path.GetExtension(poster.FileName).ToLower()))
                {
                    var viewModel = await _movieManager.GetGenresVMAsync();
                    movieFormVM.Genres = viewModel.Genres;
                    ModelState.AddModelError("Poster", "Only .PNG, .JPG images are allowed!");
                    return View("MovieForm", movieFormVM);
                }

                if (poster.Length > _maxAllowedPosterSize)
                {
                    var viewModel = await _movieManager.GetGenresVMAsync();
                    movieFormVM.Genres = viewModel.Genres;
                    ModelState.AddModelError("Poster", "Poster cannot be more than 1 MB!");
                    return View("MovieForm", movieFormVM);
                }
                _movieManager.UpdateMoive(dataStream, movieFormVM);

            }
            _toastNotification.AddSuccessToastMessage("Movie updated successfully");
            return RedirectToAction(nameof(Index));
        }
        /*------------------------------------------------------------------------*/
        // Delete a Specific Moive By Id
        public IActionResult Delete(int id)
        {
            var movie = _movieManager.GetMoiveById(id);
            if (movie == null)
                return NotFound();

            _movieManager.DeleteMoive(id);
            return Ok();
        }
        /*------------------------------------------------------------------------*/
    }
}