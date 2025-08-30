using PTR.TPFinal.Domain.Models;

namespace PTR.TPFinal.Services.NoSQLRepositories.Interfaces
{
    public interface IShoppingCartRepository
    {
        Task<IEnumerable<ShoppingCart>> FindAsync(string fieldName, string fieldValue);
        Task<ShoppingCart?> FindByIdAsync(string id);
        Task<bool> UpdateAsync(ShoppingCart document, string id);
        Task DeleteAsync(string id);
        Task<decimal> AddToShoppingCartAsync(ShoppingCart request, int partialPrice);
    }
}