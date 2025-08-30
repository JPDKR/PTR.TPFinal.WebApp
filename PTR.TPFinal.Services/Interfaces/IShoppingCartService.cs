using PTR.TPFinal.Domain.Models;
using PTR.TPFinal.Services.DTOs.Requests;
using PTR.TPFinal.Services.DTOs.Responses;

namespace PTR.TPFinal.Services.Interfaces
{
    public interface IShoppingCartService
    {
        Task<IEnumerable<ShoppingCart>> GetAllAsync(string fieldName, string fieldValue);
        Task<ShoppingCart?> GetByIdAsync(string id);
        Task<bool> UpdateAsync(ShoppingCart ShoppingCart, string id);
        Task DeleteAsync(string id);
        Task<IEnumerable<ShoppingCart>> AddToShoppingCartAsync(CreateShoppingCartRequestDto request);
    }
}
