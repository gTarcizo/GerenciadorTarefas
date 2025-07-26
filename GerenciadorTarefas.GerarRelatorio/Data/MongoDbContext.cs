using MongoDB.Driver;

namespace GerenciadorTarefas.GerarRelatorio.Data;
public class MongoDbContext
{
   public IMongoDatabase _database;
   public MongoDbContext(IConfiguration config)
   {
      var connectionString = config["MongoDB:DbConnection"];
      var dataBaseName = config["MongoDB:Database"];
      var url = MongoUrl.Create(connectionString);
      var client = new MongoClient(url);
      _database = client.GetDatabase(dataBaseName);
   }
}
