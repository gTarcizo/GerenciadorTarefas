using GerenciadorTarefas.API.DTOs;
using GerenciadorTarefas.Application.Interfaces;

namespace GerenciadorTarefas.API.Endpoints.Tarefa;
public class TarefaPost
{
   public static string Pattern => "v1/Tarefa";
   public static string[] Methods => [HttpMethod.Post.ToString()];
   public static Delegate Handler => Action;

   public static async Task<IResult> Action(TarefaRequest tarefaRequest,ITarefaService _service)
   {
      try
      {
         await _service.CriarTarefa(tarefaRequest.Tipo, tarefaRequest.Dados);

         return Results.Created(Pattern,tarefaRequest);
      }
      catch (Exception e)
      {
         return Results.BadRequest();
      }
   }
}
