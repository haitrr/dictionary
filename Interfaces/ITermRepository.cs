namespace Dictionary.Interfaces
{
    using System.Threading.Tasks;
  using Dictionary.Repositories;
  using Models;

    public interface ITermRepository : IRepository<Term>
    {
        Task<Term> GetTermAsync(string text, string fromLang, string toLang);
  }
}