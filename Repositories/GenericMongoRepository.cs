namespace Dictionary.Repositories
{
  using System;
  using System.Collections.Generic;
  using System.Linq.Expressions;
  using System.Threading.Tasks;
  using MongoDB.Driver;

  public abstract class GenericMongoRepository<T> : IRepository<T>
  {
    protected readonly IMongoCollection<T> Collection;
    public GenericMongoRepository(MongoDbContext mongoDbContext)
    {
      Collection = mongoDbContext.GetCollection<T>();
    }

    public Task AddRangeAsync(IEnumerable<T> objects)
    {
      return this.Collection.InsertManyAsync(objects);
    }

    public virtual Task<long> CountAsync(Expression<Func<T, bool>> filter)
    {
      return this.Collection.CountDocumentsAsync(filter);
    }
  }
}