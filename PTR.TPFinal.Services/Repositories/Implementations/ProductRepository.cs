using Microsoft.EntityFrameworkCore;
using PTR.TPFinal.Domain.Data;
using PTR.TPFinal.Domain.Models;
using PTR.TPFinal.Services.Repositories.Interfaces;

namespace PTR.TPFinal.Services.Repositories.Implementations
{
    public class ProductRepository(ECommerceApiContext context) : Repository<Product>(context), IProductRepository
    {
        public Product CreateProduct(Product entity)
        {
            _context.Attach(entity.Area);
            _context.Products.Add(entity);
            _context.SaveChanges();

            return entity;
        }

        public IEnumerable<Product> GetAllInclude()
        {
            return [.. _context.Products.Include(i => i.Area)];
        }

        public Product GetByIdInclude(int id)
        {
            return _context.Products.Include(i => i.Area).FirstOrDefault(w => w.Id == id)!;
        }
    }
}
