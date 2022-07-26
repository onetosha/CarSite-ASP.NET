using CarSite.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace CarSite.DAL
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Car> Car { get; set; }
    }
}