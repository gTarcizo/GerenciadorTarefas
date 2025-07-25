using GerenciadorTarefas.Domain.Entities;
using GerenciadorTarefas.Application.Interfaces;
using GerenciadorTarefas.Infrastructure.Data;
using MongoDB.Driver;

namespace GerenciadorTarefas.Infrastructure.Repository;
public class TarefaRepository : ITarefaRepository
{
   private readonly IMongoCollection<Tarefa> _tarefas;
   private IMessageQueue _rabbit;

   public TarefaRepository(MongoDbContext mongoDb, IMessageQueue rabbit)
   {
      _tarefas = mongoDb._database.GetCollection<Tarefa>("Tarefa");
      _rabbit = rabbit;
   }
   public async Task<Tarefa> RetornarTarefaPor(Guid id)
   {
      Tarefa tarefa = await _tarefas.Find(x=> x.Id == id).FirstOrDefaultAsync();
      return tarefa;
   }
   public async Task CriarTarefa(Tarefa tarefa)
   {
      await _tarefas.InsertOneAsync(tarefa);
      await _rabbit.PublicarTarefa(tarefa);
   }
}
