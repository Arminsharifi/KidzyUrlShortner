using KidzyUrlShortner.Application.Interfaces;
using KidzyUrlShortner.Basekit.Tools;
using KidzyUrlShortner.DAL.Dapper.Interfaces;
using KidzyUrlShortner.DAL.EfCore.Interfaces;
using KidzyUrlShortner.Domain.DataTransferObjects;
using VazirUrlShortner.Domain.Entities;

namespace KidzyUrlShortner.Application.Services
{
    public class UrlServices : IUrlServices
    {
        private readonly IDapperUrlRepository _urlDapperRepository;
        private readonly IEfUrlRepository _urlEfRepository;

        public UrlServices(IDapperUrlRepository urlDapperRepository, IEfUrlRepository urlEfRepository)
        {
            _urlDapperRepository = urlDapperRepository;
            _urlEfRepository = urlEfRepository;
        }

        public async Task<CreateUrlResponseDto> CreateUrlAsync(CreateUrlRequestDto createUrlDto)
        {
            string Slug = await GetUniqueSlugAsync();
            await _urlEfRepository.CreateUrl(new Url()
            {
                Link = createUrlDto.Url,
                Slug = Slug
            });
            return new CreateUrlResponseDto() { Slug = Slug };
        }

        private async Task<string> GetUniqueSlugAsync()
        {
            string slug;

            do
            {
                slug = SlugTools.GenerateRandomSlug();
            } while (!await _urlEfRepository.IsSlugUnique(slug));

            return slug;
        }

        public async Task<GetUrlResponseDto?> GetUrlAsync(string slug)
        {
            string? Url = await _urlDapperRepository.GetUrlWithIncermentTimesVisitedAsync(slug);
            return !string.IsNullOrWhiteSpace(Url) ? new GetUrlResponseDto() { Url = Url } : null;
        }
    }
}