using Microsoft.EntityFrameworkCore;
using MoviesApp.DAL.Data.Models;

namespace MoviesApp.DAL.Data.Context
{
    public class MoviesContext : DbContext
    {
        // Table
        public DbSet<Movie> Movies { set; get; }
        public DbSet<Genre> Genres { set; get; }

        public MoviesContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}

