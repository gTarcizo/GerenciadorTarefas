using GerenciadorTarefas.Domain.Entities;

namespace GerenciadorTarefas.Application.Interfaces;

public interface ITarefaRepository
{
   Task<Tarefa> RetornarTarefaPor(Guid id);
   Task CriarTarefa(Tarefa tarefa);
}
