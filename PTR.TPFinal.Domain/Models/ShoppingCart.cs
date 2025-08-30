using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PTR.TPFinal.Domain.Models
{
    public class ShoppingCart
    {
        [BsonId]
        public ObjectId Id { get; set; }
        [BsonElement("clientId")]
        public int ClientId { get; set; }
        [BsonElement("employeeId")]
        public int EmployeeId { get; set; }
        [BsonElement("paymentMethod")]
        public int PaymentMethod { get; set; }
        [BsonElement("createdAt")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        [BsonElement("products")]
        public ICollection<Product> Products { get; set; }
        [BsonElement("discount")]
        public int discount { get; set; }
        [BsonElement("totalPrice")]
        public decimal TotalPrice { get; set; }
    }
}
