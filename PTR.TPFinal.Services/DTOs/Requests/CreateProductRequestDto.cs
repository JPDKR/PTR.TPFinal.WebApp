namespace PTR.TPFinal.Services.DTOs.Requests
{
    public class CreateProductRequestDto
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public int Price { get; set; }
        public int AreaId { get; set; }
    }
}
