using PTR.TPFinal.Domain.Data;
using PTR.TPFinal.Domain.Models;
using PTR.TPFinal.Services.Repositories.Interfaces;

namespace PTR.TPFinal.Services.Repositories.Implementations
{
    public class ProductRepository(ECommerceApiContext context) : Repository<Product>(context), IProductRepository
    {
        public Product CreateProduct(Product entity)
        {
            context.Attach(entity.Area);
            context.Products.Add(entity);
            context.SaveChanges();

            return entity;
        }
    }
}
