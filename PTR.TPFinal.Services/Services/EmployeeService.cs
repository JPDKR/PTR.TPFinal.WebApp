using AutoMapper;
using PTR.TPFinal.Domain.Models;
using PTR.TPFinal.Services.DTOs.Requests;
using PTR.TPFinal.Services.DTOs.Responses;
using PTR.TPFinal.Services.Interfaces;
using PTR.TPFinal.Services.Repositories.Interfaces;

namespace PTR.TPFinal.Services.Services
{
    public class EmployeeService(IMapper mapper, IEmployeeRepository employeeRepository) : IEmployeeService
    {
        private readonly IMapper _mapper = mapper;
        private readonly IEmployeeRepository _employeeRepository = employeeRepository;

        public EmployeeResponseDto Create(CreateEmployeeRequestDto request)
        {
            Employee requestEmployee = _mapper.Map<Employee>(request);
            Employee createdEmployee = _employeeRepository.CreateEmployee(requestEmployee);
            return _mapper.Map<EmployeeResponseDto>(createdEmployee);
        }

        public void Delete(int id)
        {
            _employeeRepository.Delete(id);
        }

        public IEnumerable<EmployeeResponseDto> GetAll()
        {
            var Employees = _employeeRepository.GetAllInclude();
            return _mapper.Map<IEnumerable<EmployeeResponseDto>>(Employees);
        }

        public EmployeeResponseDto GetById(int id)
        {
            Employee? Employee = _employeeRepository.GetByIdInclude(id);
            return _mapper.Map<EmployeeResponseDto>(Employee);
        }
    }
}