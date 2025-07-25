using GerenciadorTarefas.API.DTOs;
using GerenciadorTarefas.Domain.Extensions;
using GerenciadorTarefas.Application.Interfaces;
using GerenciadorTarefas.Domain.Exceptions;

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
         var tarefa = await _service.CriarTarefa(tarefaRequest.Tipo, tarefaRequest.Dados);

         return Results.Created(Pattern, new TarefaResponse(tarefa.Tipo.RetornarDisplayName(), tarefa.Dados, tarefa.Status.RetornarDisplayName()));
      }
      catch(ValidacaoException e)
      {
         return Results.ValidationProblem(e.Erros);

      }
      catch (Exception e)
      {
         return Results.BadRequest(e.ToString());
      }
   }
}
