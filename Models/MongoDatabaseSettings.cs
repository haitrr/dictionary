using Dictionary.Interfaces;

namespace Dictionary.Models
{
  public class MongoDatabaseSettings : IMongoDatabaseSettings
  {
    public string ConnectionString { get; set; }
    public string DatabaseName { get; set; }
  }
}