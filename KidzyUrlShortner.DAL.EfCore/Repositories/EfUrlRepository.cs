using KidzyUrlShortner.DAL.EfCore.Contexts;
using KidzyUrlShortner.DAL.EfCore.Interfaces;
using Microsoft.EntityFrameworkCore;
using VazirUrlShortner.Domain.Entities;

namespace KidzyUrlShortner.DAL.EfCore.Repositories
{
    public class EfUrlRepository : IEfUrlRepository
    {
        private readonly UrlDbContext _urlDbContext;

        public EfUrlRepository(UrlDbContext urlDbContext)
        {
            _urlDbContext = urlDbContext;
        }

        public async Task CreateUrl(Url url)
        {
            await _urlDbContext.Urls.AddAsync(url);
            await _urlDbContext.SaveChangesAsync();
        }

        public async Task<bool> IsSlugUnique(string slug)
        {
            return !await _urlDbContext.Urls.AsNoTracking().AnyAsync(x => x.Slug == slug);
        }
    }
}