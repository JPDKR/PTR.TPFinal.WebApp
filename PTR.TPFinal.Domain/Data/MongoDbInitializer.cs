using MongoDB.Driver;

namespace PTR.TPFinal.Domain.Data
{
    public class MongoDbInitializer(MongoDbContext context)
    {
        private readonly MongoDbContext _context = context;

        public void Initialize()
        {
            var collections = _context.Database.ListCollectionNames().ToList();
            if (!collections.Contains("ShoppingCart"))
            {
                _context.Database.CreateCollection("ShoppingCart");
            }
        }
    }
}
