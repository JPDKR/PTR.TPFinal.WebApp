using PTR.TPFinal.Domain.Models;

namespace PTR.TPFinal.Services.DTOs.Responses
{
    public class EmployeeResponseDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public Area Area { get; set; } = new();
        public int Salary { get; set; }
    }
}