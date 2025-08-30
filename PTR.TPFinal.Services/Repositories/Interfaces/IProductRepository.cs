using PTR.TPFinal.Domain.Models;
using PTR.TPFinal.Services.DTOs.Responses;

namespace PTR.TPFinal.Services.Repositories.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        Product CreateProduct(Product entity);
        IEnumerable<Product> GetAllInclude();
        Product GetByIdInclude(int id);
    }
}