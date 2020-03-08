namespace Dictionary
{
    using System.IO;
    using Dictionary.Interfaces;
    using Dictionary.Models;
    using Microsoft.Extensions.Logging;
    using MongoDB.Driver;
    using Newtonsoft.Json;

    public class DataSeeder : IDataSeeder
    {
        private readonly ITermRepository termRepository;
        private readonly ILogger<DataSeeder> logger;
        private readonly MongoDbContext dbContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="DataSeeder"/> class.
        /// </summary>
        public DataSeeder()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataSeeder"/> class.
        /// </summary>
        /// <param name="termRepository">term repo.</param>
        /// <param name="logger">logger.</param>
        /// <param name="dbContext">db context.</param>
        public DataSeeder(ITermRepository termRepository, ILogger<DataSeeder> logger, MongoDbContext dbContext)
        {
            this.termRepository = termRepository;
            this.logger = logger;
            this.dbContext = dbContext;
        }

        /// <inheritdoc/>
        public void SeedDatabase()
        {
            var termCount = this.termRepository.CountAsync(_ => true)
                .GetAwaiter()
                .GetResult();
            if (termCount == 0)
            {
                this.logger.LogInformation("****** Begin seeding data. *********");
                this.logger.LogInformation("Importing dictionaries");

                this.dbContext.GetCollection<Term>()
                    .Indexes.CreateOne(
                        new CreateIndexModel<Term>(
                            Builders<Term>.IndexKeys.Combine(
                                Builders<Term>.IndexKeys.Ascending(t => t.OriginalLanguage),
                                Builders<Term>.IndexKeys.Ascending(t => t.ToLanguage),
                                Builders<Term>.IndexKeys.Ascending(t => t.Text)),
                            new CreateIndexOptions { Unique = true }));

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

                    this.termRepository.AddRangeAsync(terms)
                        .GetAwaiter()
                        .GetResult();
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