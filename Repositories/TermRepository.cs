namespace Dictionary.Repositories
{
  using System.Threading.Tasks;
  using Interfaces;
  using Microsoft.EntityFrameworkCore;
  using Models;
  using MongoDB.Driver;

  public class TermRepository : GenericMongoRepository<Term>, ITermRepository
  {
    public TermRepository(MongoDbContext mongoDbContext) : base(mongoDbContext)
    {
    }

    public Task<Term> GetTermAsync(string text, string fromLang, string toLang)
    {
      return this.Collection.Find(
          t => t.Text == text.ToLowerInvariant() && t.OriginalLanguage == fromLang && t.ToLanguage == toLang).SingleOrDefaultAsync();
    }
  }
}