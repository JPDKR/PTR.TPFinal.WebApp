using Microsoft.EntityFrameworkCore;
using PTR.TPFinal.Domain.Data;
using PTR.TPFinal.Domain.Models;
using PTR.TPFinal.Services.Repositories.Interfaces;

namespace PTR.TPFinal.Services.Repositories.Implementations
{
    public class EmployeeRepository(ECommerceApiContext context) : Repository<Employee>(context), IEmployeeRepository
    {
        public Employee CreateEmployee(Employee entity)
        {
            _context.Attach(entity.Area);
            _context.Employees.Add(entity);
            _context.SaveChanges();

            return entity;
        }

        public IEnumerable<Employee> GetAllInclude()
        {
            return [.. _context.Employees.Include(i => i.Area)];
        }

        public Employee GetByIdInclude(int id)
        {
            return _context.Employees.Include(i => i.Area).FirstOrDefault(w => w.Id == id)!;
        }
    }
}