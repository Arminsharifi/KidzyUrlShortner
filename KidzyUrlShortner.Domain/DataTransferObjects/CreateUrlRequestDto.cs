using System.ComponentModel.DataAnnotations;

namespace KidzyUrlShortner.Domain.DataTransferObjects
{
    public record CreateUrlRequestDto
    {
        [Required]
        [MaxLength(200)]
        [Url]
        public string Url { get; set; }
    }
}