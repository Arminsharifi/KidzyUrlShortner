namespace KidzyUrlShortner.DAL.Dapper.Interfaces
{
    public interface IDapperUrlRepository
    {
        Task<string?> GetUrlWithIncermentTimesVisitedAsync(string slug);
    }
}