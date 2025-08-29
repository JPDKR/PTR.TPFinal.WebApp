using PTR.TPFinal.Domain.Models;

namespace PTR.TPFinal.Services.Repositories.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        Product CreateProduct(Product entity);
    }
}
