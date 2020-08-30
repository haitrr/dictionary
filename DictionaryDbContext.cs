namespace Dictionary
{
    using Dictionary.Models;
    using Microsoft.EntityFrameworkCore;

    public class DictionaryDbContext : DbContext
    {
        protected DictionaryDbContext()
        {
        }

        public DictionaryDbContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Term>().HasIndex(t => new {t.OriginalLanguage, t.ToLanguage, t.Text}).IsUnique();
        }
    }
}