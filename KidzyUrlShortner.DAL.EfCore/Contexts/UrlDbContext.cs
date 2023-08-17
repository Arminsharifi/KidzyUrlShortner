using KidzyUrlShortner.DAL.EfCore.Mappings;
using Microsoft.EntityFrameworkCore;
using VazirUrlShortner.Domain.Entities;

namespace KidzyUrlShortner.DAL.EfCore.Contexts
{
    public class UrlDbContext : DbContext
    {
        public DbSet<Url> Urls { get; set; }

        public UrlDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UrlMapping());
        }
    }
}
