using GerenciadorTarefas.API.Extensions;
using GerenciadorTarefas.Application.Interfaces;
using GerenciadorTarefas.Domain.Entities;
using GerenciadorTarefas.Domain.Enums;
using GerenciadorTarefas.Domain.Exceptions;


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
   public async Task<Tarefa> CriarTarefa(TipoTarefaEnum tipo, string dados)
   {
      Tarefa tarefa = new Tarefa(tipo, dados);
      if (!tarefa.IsValid) throw new ValidacaoException(tarefa.Notifications.RetornarDetalhesValidacao());

      await _repository.CriarTarefa(tarefa);
      return tarefa;
   }
}
