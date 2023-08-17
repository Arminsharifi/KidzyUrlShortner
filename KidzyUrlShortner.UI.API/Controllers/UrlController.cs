using KidzyUrlShortner.Application.Interfaces;
using KidzyUrlShortner.Domain.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace KidzyUrlShortner.UI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UrlController : ControllerBase
    {
        private readonly IUrlServices _urlServices;
        private readonly ILogger<UrlController> _logger;

        public UrlController(IUrlServices urlServices, ILogger<UrlController> logger)
        {
            _urlServices = urlServices;
            _logger = logger;
        }

        [HttpGet("Get")]
        public async Task<IActionResult> GetUrl([Required][FromQuery][MaxLength(10)] string slug)
        {
            try
            {
                GetUrlResponseDto? getUrlResponseDto = await _urlServices.GetUrlAsync(slug);
                return getUrlResponseDto is not null ? Ok(getUrlResponseDto) : NotFound();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost("Set")]
        public async Task<IActionResult> SetUrl([Required][FromBody] CreateUrlRequestDto createUrlDto)
        {
            try
            {
                CreateUrlResponseDto createUrlResponse = await _urlServices.CreateUrlAsync(createUrlDto);
                return Ok(createUrlResponse);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}