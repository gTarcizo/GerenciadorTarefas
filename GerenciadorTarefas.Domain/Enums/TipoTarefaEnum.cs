using System.ComponentModel.DataAnnotations;

namespace GerenciadorTarefas.Domain.Enums;
public enum TipoTarefaEnum
{
   [Display(Name = "Gerar Relatório")]
   GerarRelatorio,
   [Display(Name = "Enviar E-Mail")]
   EnviarEmail
}
