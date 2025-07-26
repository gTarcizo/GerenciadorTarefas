using GerenciadorTarefas.GerarRelatorio.Enums;

namespace GerenciadorTarefas.GerarRelatorio.Interfaces;
public interface ITarefaRepository
{
   Task AtualizarStatus(Guid id, StatusTarefaEnum status, int tentativa = 1);
}
