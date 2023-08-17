namespace KidzyUrlShortner.Domain.DataTransferObjects
{
    public record CreateUrlResponseDto
    {
        public string Slug { get; set; }
    }
}