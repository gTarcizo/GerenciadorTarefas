using GerenciadorTarefas.EnviarEmail.Data;
using GerenciadorTarefas.EnviarEmail.Enums;
using GerenciadorTarefas.EnviarEmail.Interfaces;
using GerenciadorTarefas.EnviarEmail.Models;
using MongoDB.Driver;

namespace GerenciadorTarefas.EnviarEmail.Repository;
public class TarefaRepository : ITarefaRepository
{
   private readonly IMongoCollection<Tarefa> _tarefas;

   public TarefaRepository(MongoDbContext mongoDb, IMessageQueueService rabbit)
   {
      _tarefas = mongoDb._database.GetCollection<Tarefa>("Tarefa");
   }

   public async Task AtualizarStatus(Guid id, StatusTarefaEnum status)
   {
      var filtro = Builders<Tarefa>.Filter.Eq(x => x.Id, id);
      var atualizacao = Builders<Tarefa>.Update
          .Set(t => t.Status, status);

      await _tarefas.UpdateOneAsync(filtro, atualizacao);
   }
}
