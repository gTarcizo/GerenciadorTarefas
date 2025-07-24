using GerenciadorTarefas.Domain.Enums;

namespace GerenciadorTarefas.API.DTOs;

public record TarefaResponse(string Tipo, string Dados, string Status);
