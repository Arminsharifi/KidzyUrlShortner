using Dapper;
using KidzyUrlShortner.DAL.Dapper.Interfaces;
using Npgsql;

namespace KidzyUrlShortner.DAL.Dapper.Repositories
{
    public class DapperUrlRepository : IDapperUrlRepository
    {
        private readonly NpgsqlConnection _connection;

        public DapperUrlRepository(string connectionString)
        {
            _connection = new NpgsqlConnection(connectionString);
        }

        public async Task<string?> GetUrlWithIncermentTimesVisitedAsync(string slug) =>
             await _connection.QuerySingleOrDefaultAsync<string?>("UPDATE tbl_url SET times_visited = times_visited + 1 WHERE slug = @Slug RETURNING link", new { Slug = slug });
    }
}