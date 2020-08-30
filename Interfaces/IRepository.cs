namespace Dictionary.Interfaces
{
    using System;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    public interface IRepository<T>
    {
        Task<int> CountAsync(Expression<Func<object, bool>> func);
        Task AddRangeAsync(T[] entities);
    }
}