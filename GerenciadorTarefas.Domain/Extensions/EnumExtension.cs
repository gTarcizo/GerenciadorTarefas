using System.Reflection;
using System.ComponentModel.DataAnnotations;

namespace GerenciadorTarefas.Domain.Extensions;

public static class EnumExtension
{
   public static string RetornarDisplayName(this Enum valor)
   {
      var tipo = valor.GetType();
      var nome = valor.ToString();

      var campo = tipo.GetField(nome);
      if (campo == null) return nome;

      var atributo = campo.GetCustomAttribute<DisplayAttribute>();
      return atributo?.Name ?? nome;
   }
}
