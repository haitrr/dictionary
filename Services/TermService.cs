namespace Dictionary.Services
{
    using System.Threading.Tasks;
    using Controllers;
    using Models;

    public class TermService: ITermService
    {
        private readonly ITermRepository termRepository;

        public TermService(ITermRepository termRepository)
        {
            this.termRepository = termRepository;
        }

        public Task<Term> GetTermAsync(string text, string fromLang, string toLang)
        {
            return this.termRepository.GetTermAsync(text, fromLang, toLang);
        }
    }
}