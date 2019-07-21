namespace Dictionary.Services
{
    using System.Threading.Tasks;
    using Controllers;
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

        public Task<Term> GetTermAsync(string text, string fromLang, string toLang)
        {
            var term = this.termRepository.GetTermAsync(text, fromLang, toLang);
            if (term == null)
            {
                throw new NotFoundException("Term not found.");
            }

            return term;
        }
    }
}