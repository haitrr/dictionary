using Dictionary.Interfaces;
using MongoDB.Driver;

namespace Dictionary
{
  public class MongoDbContext
  {
    private readonly IMongoDatabase database;
    public MongoDbContext(IMongoDatabaseSettings settings)
    {
      var client = new MongoClient(settings.ConnectionString);
      this.database = client.GetDatabase(settings.DatabaseName);
    }

    public IMongoCollection<T> GetCollection<T>()
    {
      var type = typeof(T);
      return this.database.GetCollection<T>(type.Name);
    }
  }
}