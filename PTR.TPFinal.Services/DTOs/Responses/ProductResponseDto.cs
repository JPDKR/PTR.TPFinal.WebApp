using PTR.TPFinal.Domain.Models;

namespace PTR.TPFinal.Services.DTOs.Responses
{
    public class ProductResponseDto
    {
        public string? Description { get; set; }
        public Area Area { get; set; }
        public int Price { get; set; }
    }
}
