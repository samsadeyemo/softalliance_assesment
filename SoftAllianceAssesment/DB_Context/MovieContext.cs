using Microsoft.EntityFrameworkCore;
using SoftAllianceAssesment.DBModels;

namespace SoftAllianceAssesment.DB_Context
{
    public class MovieContext : DbContext
    {
        public MovieContext(DbContextOptions options) : base(options) { }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Movie> Movies { get; set; }
    }
}