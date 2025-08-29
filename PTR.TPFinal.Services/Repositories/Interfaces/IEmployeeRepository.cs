using PTR.TPFinal.Domain.Models;

namespace PTR.TPFinal.Services.Repositories.Interfaces
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        Employee CreateEmployee(Employee entity);
    }
}
