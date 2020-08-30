namespace Dictionary.Repositories
{
  using System;
  using System.Linq;
  using System.Linq.Expressions;
  using System.Threading.Tasks;
  using Dictionary.Interfaces;
  using Microsoft.EntityFrameworkCore;

  public abstract class GenericRepository<T> : IRepository<T> where T: class
  {
    protected readonly DbSet<T> DbSet;
    protected readonly DictionaryDbContext DictionaryDbContext;

    protected GenericRepository(DictionaryDbContext dbContext)
    {
      this.DictionaryDbContext = dbContext;
      this.DbSet = dbContext.Set<T>();
    }

    public Task<int> CountAsync(Expression<Func<object, bool>> func)
    {
      return this.DbSet.AsNoTracking()
        .Where(func)
        .CountAsync();
    }

    public Task AddRangeAsync(T[] entities)
    {
      this.DbSet.AddRange(entities);
      return this.DictionaryDbContext.SaveChangesAsync();
    }
  }
}