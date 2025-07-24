using GerenciadorTarefas.Application.Interfaces;
using GerenciadorTarefas.Domain.Entities;
using GerenciadorTarefas.Domain.Enums;


namespace GerenciadorTarefas.Application.Services;
public class TarefaService : ITarefaService
{
   ITarefaRepository _repository;
   public TarefaService(ITarefaRepository tarefaRepository)
   {
      _repository = tarefaRepository;
   }
   public async Task<Tarefa> RetornarTarefaPor(Guid id)
   {
      return await _repository.RetornarTarefaPor(id);
   }
   public async Task<Guid> CriarTarefa(TipoTarefaEnum tipo, string dados)
   {
      Tarefa tarefa = new Tarefa { Id = new Guid(), Tipo = tipo, Dados = dados };
      await _repository.CriarTarefa(tarefa);
      return tarefa.Id;
   }
}
