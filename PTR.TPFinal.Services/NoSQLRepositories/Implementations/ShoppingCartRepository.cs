using MongoDB.Bson;
using MongoDB.Driver;
using PTR.TPFinal.Domain.Data;
using PTR.TPFinal.Domain.Models;
using PTR.TPFinal.Services.DTOs.Requests;
using PTR.TPFinal.Services.NoSQLRepositories.Interfaces;

namespace PTR.TPFinal.Services.NoSQLRepositories.Implementations
{
    public class ShoppingCartRepository(MongoDbContext context) : IShoppingCartRepository
    {
        private readonly IMongoCollection<ShoppingCart> _collection = context.ShoppingCart;
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

        public Task<IEnumerable<ShoppingCart>> AddToShoppingCartAsync(CreateShoppingCartRequestDto request)
        {
            // ToDo
            return null;
        }
    }
}
