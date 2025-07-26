using GerenciadorTarefas.EnviarEmail.Enums;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace GerenciadorTarefas.EnviarEmail.Models;
public class Tarefa
{

   [BsonId]
   [BsonElement("_id"), BsonRepresentation(BsonType.String)]
   public Guid Id { get; set; }
   public string Dados { get; set; }
   public StatusTarefaEnum Status { get; set; }
   public int Tentativa { get; set; }
}
