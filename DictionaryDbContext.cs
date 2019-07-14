namespace Dictionary
{
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class DictionaryDbContext : DbContext
    {
        public DictionaryDbContext(DbContextOptions<DictionaryDbContext> options)
            : base(options)
        {
        }

        // ReSharper disable once UnusedAutoPropertyAccessor.Global
        public DbSet<Term> Terms { get; set; }
    }
}