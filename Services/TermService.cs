namespace Dictionary.Services
{
    using System.Threading.Tasks;
    using Exceptions;
    using Interfaces;
    using Models;

    public class TermService : ITermService
    {
        private readonly ITermRepository termRepository;

        public TermService(ITermRepository termRepository)
        {
            this.termRepository = termRepository;
        }

        public async Task<Term> GetTermAsync(string text, string fromLang, string toLang)
        {
            var term = await this.termRepository.GetTermAsync(text, fromLang, toLang);
            if (term == null)
            {
                throw new NotFoundException("Term not found.");
            }

            return term;
        }
    }
}