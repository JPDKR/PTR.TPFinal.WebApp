using PTR.TPFinal.Domain.Enums;
using PTR.TPFinal.Domain.Models;

namespace PTR.TPFinal.Services.DTOs.Responses
{
    public class ShoppingCartResponseDto
    {
        public Client Client { get; set; }
        public Employee Employee { get; set; }
        public ICollection<Product> Products { get; set; } = new HashSet<Product>();
        public PaymentType PaymentType { get; set; }
    }
}
