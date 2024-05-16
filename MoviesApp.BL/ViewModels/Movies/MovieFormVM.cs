using MoviesApp.DAL.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace MoviesApp.BL.ViewModels.Movies
{
    public class MovieFormVM
    {
        public int Id { get; set; }

        [Required, StringLength(250)]
        public string Title { get; set; } = string.Empty;

        public int Year { get; set; }

        [Range(1, 10)]
        public double Rate { get; set; }

        [Required, StringLength(2500)]
        public string Storyline { get; set; } = string.Empty;

        [Display(Name = "Select poster...")]
        public byte[] Poster { get; set; }

        [Display(Name = "Genre")]
        public byte GenreId { get; set; }

        public IEnumerable<Genre> Genres { get; set; } = null!;
    }
}
