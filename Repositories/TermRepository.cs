namespace Dictionary.Repositories
{
    using System.Threading.Tasks;
    using Interfaces;
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class TermRepository : ITermRepository
    {
        private readonly DictionaryDbContext dbContext;

        public TermRepository(DictionaryDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Task<Term> GetTermAsync(string text, string fromLang, string toLang)
        {
            return this.dbContext.Terms.SingleOrDefaultAsync(
                t => t.Text == text.ToLowerInvariant() && t.OriginalLanguage == fromLang && t.ToLanguage == toLang);
        }
    }
}