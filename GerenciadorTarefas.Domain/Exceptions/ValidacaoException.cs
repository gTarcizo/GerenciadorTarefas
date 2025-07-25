
namespace GerenciadorTarefas.Domain.Exceptions;
public class ValidacaoException : Exception
{
   public Dictionary<string, string[]> Erros { get;}
   public ValidacaoException(Dictionary<string, string[]> notificacoes)
       : base($"Erro ao validar")
   {
      Erros = notificacoes;
   }
}
