using Microsoft.EntityFrameworkCore;
using YelpCamp_ASPNET_Angular.Models;

namespace YelpCamp_ASPNET_Angular.Data
{
    public class CampgroundContext : DbContext
    {
        public DbSet<Campground> Campgrounds { get; set; }

        public CampgroundContext(DbContextOptions<CampgroundContext> options) : base(options)
        {
        }
    }
}