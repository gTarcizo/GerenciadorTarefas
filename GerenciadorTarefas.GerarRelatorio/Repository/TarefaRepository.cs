using GerenciadorTarefas.GerarRelatorio.Data;
using GerenciadorTarefas.GerarRelatorio.Enums;
using GerenciadorTarefas.GerarRelatorio.Interfaces;
using GerenciadorTarefas.GerarRelatorio.Models;
using MongoDB.Driver;

namespace GerenciadorTarefas.GerarRelatorio.Repository;
public class TarefaRepository : ITarefaRepository
{
   private readonly IMongoCollection<Tarefa> _tarefas;

   public TarefaRepository(MongoDbContext mongoDb, IMessageQueueService rabbit)
   {
      _tarefas = mongoDb._database.GetCollection<Tarefa>("Tarefa");
   }

   public async Task AtualizarStatus(Guid id, StatusTarefaEnum status, int tentativa = 1)
   {
      var filtro = Builders<Tarefa>.Filter.Eq(x => x.Id, id);
      var atualizacao = Builders<Tarefa>.Update
          .Set(t => t.Status, status)
          .Set(t => t.Tentativa, tentativa);

      await _tarefas.UpdateOneAsync(filtro, atualizacao);
   }
}
