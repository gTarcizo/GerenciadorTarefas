
using Flunt.Notifications;
using Flunt.Validations;
using GerenciadorTarefas.Domain.Enums;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace GerenciadorTarefas.Domain.Entities;
public class Tarefa : Notifiable<Notification>
{
   public Tarefa(TipoTarefaEnum tipo, string dados)
   {
      Id = new Guid();
      Tipo = tipo;
      Dados = dados;
      ContractValidate();
   }

   [BsonId]
   [BsonElement("_id"), BsonRepresentation(BsonType.String)]
   public Guid Id { get; set; }
   public TipoTarefaEnum Tipo { get; set; }
   public string Dados { get; set; }
   public StatusTarefaEnum Status { get; set; }

   private void ContractValidate()
   {
      string nameOfDados = nameof(Dados);
      int quantidadeCaracteres = 3;

      var contract = new Contract<Tarefa>()
            .Requires()
            .IsNotNullOrEmpty(Dados, nameOfDados, "Preencha os dados.");
      AddNotifications(contract);
   }
}
