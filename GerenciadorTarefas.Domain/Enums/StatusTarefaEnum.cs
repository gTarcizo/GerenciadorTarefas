using System.ComponentModel.DataAnnotations;

namespace GerenciadorTarefas.Domain.Enums;
public enum StatusTarefaEnum
{
   [Display(Name = "Pendente")]
   Pendente,
   [Display(Name = "Em Processamento")]
   EmProcessamento,
   [Display(Name = "Concluído")]
   Concluida,
   [Display(Name = "Erro")]
   Erro
}
