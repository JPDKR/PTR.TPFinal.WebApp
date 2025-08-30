using MongoDB.Bson;
using MongoDB.Driver;
using PTR.TPFinal.Domain.Data;
using PTR.TPFinal.Domain.Enums;
using PTR.TPFinal.Domain.Models;
using PTR.TPFinal.Services.NoSQLRepositories.Interfaces;
using PTR.TPFinal.Services.Patterns.Strategy;

namespace PTR.TPFinal.Services.NoSQLRepositories.Implementations
{
    public class ShoppingCartRepository(MongoDbContext contextMongo, ECommerceApiContext contextSQL) : IShoppingCartRepository
    {
        private readonly IMongoCollection<ShoppingCart> _collection = contextMongo.ShoppingCart;
        private const string IdField = "_id";

        public async Task<IEnumerable<ShoppingCart>> FindAsync(string fieldName, string fieldValue)
        {
            if (string.Equals(fieldName, "Id", StringComparison.OrdinalIgnoreCase) ||
                string.Equals(fieldName, "_id", StringComparison.OrdinalIgnoreCase))
            {
                if (!ObjectId.TryParse(fieldValue, out var oid))
                    return [];

                var fId = Builders<ShoppingCart>.Filter.Eq(r => r.Id, oid);
                return await _collection.Find(fId).ToListAsync();
            }

            var filter = Builders<ShoppingCart>.Filter.Eq(fieldName, fieldValue);
            var cursor = await _collection.FindAsync(filter);
            return cursor.ToList();
        }

        public async Task<ShoppingCart?> FindByIdAsync(string id)
        {
            if (!ObjectId.TryParse(id, out var oid))
                return null;

            var filter = Builders<ShoppingCart>.Filter.Eq(r => r.Id, oid);
            return await _collection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task<bool> UpdateAsync(ShoppingCart document, string id)
        {
            if (!ObjectId.TryParse(id, out var oid))
                return false;

            var filter = Builders<ShoppingCart>.Filter.Eq(r => r.Id, oid);

            var setDoc = document.ToBsonDocument();
            if (setDoc.Contains(IdField))
                setDoc.Remove(IdField);

            var update = new BsonDocument("$set", setDoc);
            var result = await _collection.UpdateOneAsync(filter, update);

            return result.ModifiedCount == 1;
        }

        public async Task DeleteAsync(string id)
        {
            if (!ObjectId.TryParse(id, out var oid))
                return;

            var filter = Builders<ShoppingCart>.Filter.Eq(r => r.Id, oid);
            await _collection.DeleteOneAsync(filter);
        }

        public async Task<decimal> AddToShoppingCartAsync(ShoppingCart request, int partialPrice)
        {
            var client = contextSQL.Clients.FirstOrDefault(c => c.Id == request.ClientId) ?? throw new KeyNotFoundException("Client not found");
            var employee = contextSQL.Employees.FirstOrDefault(e => e.Id == request.EmployeeId) ?? throw new KeyNotFoundException("Employee not found");

            foreach (var item in request.Products)
            {
                var product = contextSQL.Products.FirstOrDefault(c => c.Id == item.Id) ?? throw new KeyNotFoundException($"Product not found with id {item.Id}");
                var area = contextSQL.Areas.FirstOrDefault(a => a.Id == item.Area.Id) ?? throw new KeyNotFoundException($"Area not found with id {product.Area.Id}");
            }

            var strategy = PaymentFactory.Create((PaymentType)request.PaymentMethod);
            var context = new PaymentContext(strategy);

            request.TotalPrice = context.ExecutePayment(partialPrice);

            await _collection.InsertOneAsync(request);

            return request.TotalPrice;
        }
    }
}
