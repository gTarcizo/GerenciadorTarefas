using Flunt.Notifications;

namespace GerenciadorTarefas.API.Extensions;

public static class DetalhesValidacoesExtension
{
  public static Dictionary<string, string[]> RetornarDetalhesValidacao(this IReadOnlyCollection<Notification> notification)
  {
    return notification
          .GroupBy(x => x.Key)
          .ToDictionary(y => y.Key, y => y.Select(z => z.Message).ToArray());
  }
}
