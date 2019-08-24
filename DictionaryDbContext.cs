namespace Dictionary
{
    using Microsoft.EntityFrameworkCore;

    public class DictionaryDbContext : DbContext
    {
        public DictionaryDbContext(DbContextOptions<DictionaryDbContext> options)
            : base(options)
        {
        }
    }
}