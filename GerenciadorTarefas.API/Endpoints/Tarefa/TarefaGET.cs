using GerenciadorTarefas.API.DTOs;
using GerenciadorTarefas.API.Extensions;
using GerenciadorTarefas.Application.Interfaces;

namespace GerenciadorTarefas.API.Endpoints.Tarefa;
public class TarefaGET
{
   public static string Pattern => "v1/Tarefas";
   public static string[] Methods => [HttpMethod.Get.ToString()];
   public static Delegate Handler => Action;

   public static async Task<IResult> Action(Guid id, ITarefaService _service)
   {
      try
      {
         var tarefa = await _service.RetornarTarefaPor(id);
         if (tarefa is null) return Results.NotFound("Tarefa não encontrada.");
         return Results.Ok(new TarefaResponse(tarefa.Tipo.RetornarDisplayName(), tarefa.Dados, tarefa.Status.RetornarDisplayName()));
      }
      catch (Exception e)
      {
         return Results.BadRequest(e.ToString());
      }
   }
}
