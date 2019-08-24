namespace Dictionary.Repositories
{
  using System;
  using System.Collections.Generic;
  using System.Linq.Expressions;
  using System.Threading.Tasks;

  public interface IRepository<T>
  {
    Task<long> CountAsync(Expression<Func<T, bool>> filter);
    Task AddRangeAsync(IEnumerable<T> objects);
  }
}