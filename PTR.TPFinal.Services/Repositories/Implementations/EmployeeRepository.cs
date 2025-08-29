using PTR.TPFinal.Domain.Data;
using PTR.TPFinal.Domain.Models;
using PTR.TPFinal.Services.Repositories.Interfaces;

namespace PTR.TPFinal.Services.Repositories.Implementations
{
    public class EmployeeRepository(ECommerceApiContext context) : Repository<Employee>(context), IEmployeeRepository
    {
        public Employee CreateEmployee(Employee entity)
        {
            context.Attach(entity.Area);
            context.Employees.Add(entity);
            context.SaveChanges();

            return entity;
        }
    }
}
