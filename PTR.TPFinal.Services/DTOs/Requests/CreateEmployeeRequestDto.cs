namespace PTR.TPFinal.Services.DTOs.Requests
{
    public class CreateEmployeeRequestDto
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public int AreaId { get; set; }
        public int Salary { get; set; }
    }
}
