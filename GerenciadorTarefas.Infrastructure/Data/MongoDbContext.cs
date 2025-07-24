using MongoDB.Driver;
using Microsoft.Extensions.Configuration;

namespace GerenciadorTarefas.Infrastructure.Data;
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
