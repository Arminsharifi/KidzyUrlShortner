using KidzyUrlShortner.Domain.DataTransferObjects;

namespace KidzyUrlShortner.Application.Interfaces
{
    public interface IUrlServices
    {
        Task<CreateUrlResponseDto> CreateUrlAsync(CreateUrlRequestDto createUrlDto);
        Task<GetUrlResponseDto?> GetUrlAsync(string slug);
    }
}