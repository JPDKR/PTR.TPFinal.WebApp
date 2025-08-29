using PTR.TPFinal.Domain.Models;

namespace PTR.TPFinal.Services.DTOs.Responses
{
    public class EmployeeResponseDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public Area Area { get; set; }
        public int Salary { get; set; }
    }
}
