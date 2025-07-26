using GerenciadorTarefas.EnviarEmail.Enums;

namespace GerenciadorTarefas.EnviarEmail.Interfaces;
public interface ITarefaRepository
{
   Task AtualizarStatus(Guid id, StatusTarefaEnum status);
}
