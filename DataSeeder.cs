namespace Dictionary
{
  using System.IO;
  using Dictionary.Models;
  using Microsoft.EntityFrameworkCore;
  using Microsoft.EntityFrameworkCore.Infrastructure;
  using Microsoft.EntityFrameworkCore.Storage;
  using Microsoft.Extensions.Logging;
  using Newtonsoft.Json;

  public class DataSeeder : IDataSeeder
  {
    private readonly DictionaryDbContext dictionaryDbContext;
    private readonly ILogger<DataSeeder> logger;

    /// <summary>
    /// Initializes a new instance of the <see cref="DataSeeder"/> class.
    /// </summary>
    public DataSeeder()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="DataSeeder"/> class.
    /// </summary>
    /// <param name="dictionaryDbContext">db context.</param>
    /// <param name="logger">logger.</param>
    public DataSeeder(DictionaryDbContext dictionaryDbContext, ILogger<DataSeeder> logger)
    {
      this.dictionaryDbContext = dictionaryDbContext;
      this.logger = logger;
    }

    /// <inheritdoc/>
    public void SeedDatabase()
    {
      if (!((RelationalDatabaseCreator)this.dictionaryDbContext.Database.GetService<IDatabaseCreator>())
          .Exists())
      {
        this.logger.LogInformation("****** Begin seeding data. *********");
        this.dictionaryDbContext.Database.Migrate();
        this.logger.LogInformation("Importing dictionaries");

        foreach (string file in Directory.EnumerateFiles("./Sources"))
        {
          var name = Path.GetFileNameWithoutExtension(file);
          var langs = name.Split("-");
          var fromLang = langs[0];
          var toLang = langs[1];
          this.logger.LogInformation($"Importing {name} dictionary.");
          var terms = JsonConvert.DeserializeObject<Term[]>(File.ReadAllText(file));
          foreach (var term in terms)
          {
            term.OriginalLanguage = fromLang;
            term.ToLanguage = toLang;
          }

          this.dictionaryDbContext.Terms.AddRange(terms);
          this.dictionaryDbContext.SaveChanges();
          this.logger.LogInformation($"Imported {terms.Length} terms.");
        }

        this.logger.LogInformation("****** Done seeding data. *********");
      }
      else
      {
        this.logger.LogInformation("Database is already existed. No seeding performed.");
      }
    }
  }
}