namespace Dictionary.Interfaces
{
    using System.Threading.Tasks;
    using Models;

    public interface ITermService
    {
        Task<Term> GetTermAsync(string text, string fromLang, string toLang);
    }
}