using PTR.TPFinal.Services.DTOs.Requests;
using PTR.TPFinal.Services.DTOs.Responses;

namespace PTR.TPFinal.Services.Interfaces
{
    public interface IProductService
    {
        IEnumerable<ProductResponseDto> GetAll();
        ProductResponseDto GetById(int id);
        ProductResponseDto Create(CreateProductRequestDto request);
        void Delete(int id);
    }
}
