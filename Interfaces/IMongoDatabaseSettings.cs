namespace Dictionary.Interfaces
{
  public interface IMongoDatabaseSettings
  {
    string DatabaseName { get; set; }
    string ConnectionString { get; set; }
  }
}