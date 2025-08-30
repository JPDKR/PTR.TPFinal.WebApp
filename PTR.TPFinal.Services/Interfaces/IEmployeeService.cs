using PTR.TPFinal.Services.DTOs.Requests;
using PTR.TPFinal.Services.DTOs.Responses;

namespace PTR.TPFinal.Services.Interfaces
{
    public interface IEmployeeService
    {
        IEnumerable<EmployeeResponseDto> GetAll();
        EmployeeResponseDto GetById(int id);
        EmployeeResponseDto Create(CreateEmployeeRequestDto request);
        void Delete(int id);
    }
}