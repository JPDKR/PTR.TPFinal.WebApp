using Microsoft.Extensions.Options;
using MongoDB.Driver;
using PTR.TPFinal.Domain.Models;
using PTR.TPFinal.Domain.Models.Configuration;

namespace PTR.TPFinal.Domain.Data
{
    public class MongoDbContext
    {
        private readonly IMongoDatabase _database;

        public MongoDbContext(IOptions<MongoDbConfiguration> options)
        {
            var client = new MongoClient(options.Value.ConnectionString);
            _database = client.GetDatabase(options.Value.Database);
        }

        public IMongoDatabase Database => _database;
        public IMongoCollection<ShoppingCart> ShoppingCart => _database.GetCollection<ShoppingCart>("ShoppingCart");
    }
}
