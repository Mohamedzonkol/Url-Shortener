using Microsoft.EntityFrameworkCore;
using UrlShortner.Models;
using UrlShortner.Models.Entites;

namespace UrlShortner.Dbcontexts
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Link?> ShortLinks { get; set; }
        public DbSet<Visit> Visits { get; set; }
    }
}
