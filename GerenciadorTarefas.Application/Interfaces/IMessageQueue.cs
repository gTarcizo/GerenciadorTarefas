using GerenciadorTarefas.Domain.Entities;

namespace GerenciadorTarefas.Application.Interfaces;
public interface IMessageQueue
{
   Task PublicarTarefa(Tarefa tarefa);
}
