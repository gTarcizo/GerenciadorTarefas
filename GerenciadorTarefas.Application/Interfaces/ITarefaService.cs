using GerenciadorTarefas.Domain.Entities;
using GerenciadorTarefas.Domain.Enums;

namespace GerenciadorTarefas.Application.Interfaces;
public interface ITarefaService
{
   Task<Tarefa> RetornarTarefaPor(Guid id);
   Task<Guid> CriarTarefa(TipoTarefaEnum tipo, string dados);
}
