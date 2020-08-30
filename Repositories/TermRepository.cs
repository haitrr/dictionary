namespace Dictionary.Repositories
{
    using System.Linq;
    using System.Threading.Tasks;
    using Interfaces;
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class TermRepository : GenericRepository<Term>, ITermRepository
    {

        public Task<Term> GetTermAsync(string text, string fromLang, string toLang)
        {
            return this.DbSet.Where(
                    t => t.Text == text.ToLowerInvariant()
                         && t.OriginalLanguage == fromLang
                         && t.ToLanguage == toLang)
                .SingleOrDefaultAsync();
        }

        public TermRepository(DictionaryDbContext dbContext)
            : base(dbContext)
        {
        }
    }
}