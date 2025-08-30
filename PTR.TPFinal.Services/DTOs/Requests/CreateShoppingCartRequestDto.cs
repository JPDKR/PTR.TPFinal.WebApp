using PTR.TPFinal.Domain.Enums;
using PTR.TPFinal.Domain.Models;

namespace PTR.TPFinal.Services.DTOs.Requests
{
    public class CreateShoppingCartRequestDto
    {
        public int ClientId { get; set; }
        public int EmployeeId { get; set; }
        public ICollection<Product> Products { get; set; } = new HashSet<Product>();
        public PaymentType PaymentType { get; set; }
        public int PartialPrice { get; set; }
    }
}