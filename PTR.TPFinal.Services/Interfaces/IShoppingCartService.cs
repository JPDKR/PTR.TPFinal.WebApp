using PTR.TPFinal.Services.DTOs.Requests;
using PTR.TPFinal.Services.DTOs.Responses;

namespace PTR.TPFinal.Services.Interfaces
{
    public interface IShoppingCartService
    {
        IEnumerable<ShoppingCartResponseDto> GetAll();
        ShoppingCartResponseDto GetById(int id);
        ShoppingCartResponseDto Create(CreateShoppingCartRequestDto request);
        void Delete(int id);
    }
}
