using GerenciadorTarefas.Domain.Enums;

namespace GerenciadorTarefas.API.DTOs;

public record TarefaRequest(TipoTarefaEnum Tipo, string Dados);
