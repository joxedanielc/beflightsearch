using Microsoft.EntityFrameworkCore;
using beflightsearch.Models;

namespace beflightsearch.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Flight> Flights { get; set; }
    }
}
