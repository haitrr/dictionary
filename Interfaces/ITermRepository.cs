namespace Dictionary.Interfaces
{
    using System.Threading.Tasks;
    using Models;

    public interface ITermRepository
    {
        Task<Term> GetTermAsync(string text, string fromLang, string toLang);
    }
}