using VazirUrlShortner.Domain.Entities;

namespace KidzyUrlShortner.DAL.EfCore.Interfaces
{
    public interface IEfUrlRepository
    {
        Task CreateUrl(Url url);
        Task<bool> IsSlugUnique(string slug);
    }
}