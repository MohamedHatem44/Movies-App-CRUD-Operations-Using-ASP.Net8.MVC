using System.ComponentModel.DataAnnotations;

namespace MoviesApp.DAL.Data.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required, MaxLength(250)]
        public string Title { get; set; } = string.Empty;

        public int Year { get; set; }

        public double Rate { get; set; }

        [Required, MaxLength(2500)]
        public string Storyline { get; set; } = string.Empty;

        [Required]
        public byte[] Poster { get; set; }
        /*------------------------------------------------------------------------*/
        public byte GenreId { get; set; }

        public Genre Genre { get; set; } = null!;
        /*------------------------------------------------------------------------*/
    }
}
