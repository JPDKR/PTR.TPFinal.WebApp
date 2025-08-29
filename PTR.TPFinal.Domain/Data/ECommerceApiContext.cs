using Microsoft.EntityFrameworkCore;
using PTR.TPFinal.Domain.Models;

namespace PTR.TPFinal.Domain.Data
{
    public class ECommerceApiContext(DbContextOptions<ECommerceApiContext> options) : DbContext(options)
    {
        public DbSet<Area> Areas { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}