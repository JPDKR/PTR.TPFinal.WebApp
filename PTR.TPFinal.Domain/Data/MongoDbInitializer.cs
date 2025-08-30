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

            //var reviewsRaw = _context.Database.GetCollection<BsonDocument>("Reviews");

            //var filterNeedsRename = Builders<BsonDocument>.Filter.And(
            //    Builders<BsonDocument>.Filter.Exists("comment", true),
            //    Builders<BsonDocument>.Filter.Not(Builders<BsonDocument>.Filter.Exists("comentario", true))
            //);

            //var rename = Builders<BsonDocument>.Update.Rename("comment", "comentario");

            //var result = reviewsRaw.UpdateMany(filterNeedsRename, rename);
        }
    }
}
