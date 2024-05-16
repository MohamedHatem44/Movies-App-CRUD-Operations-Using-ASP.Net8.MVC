using MoviesApp.DAL.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace MoviesApp.BL.ViewModels.Movies
{
    public class ReadMovieVM
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public int Year { get; set; }

        public double Rate { get; set; }

        public string Storyline { get; set; } = string.Empty;

        public byte[]? Poster { get; set; }
        /*------------------------------------------------------------------------*/
        public byte GenreId { get; set; }

        public Genre Genre { get; set; } = null!;
        /*------------------------------------------------------------------------*/
    }
}
