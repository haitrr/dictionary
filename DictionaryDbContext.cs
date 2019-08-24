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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Term>().HasIndex(t => t.Text).IsUnique();
        }

        // ReSharper disable once UnusedAutoPropertyAccessor.Global
        public DbSet<Term> Terms { get; set; }
    }
}