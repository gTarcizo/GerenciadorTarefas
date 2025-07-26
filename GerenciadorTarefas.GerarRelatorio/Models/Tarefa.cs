using GerenciadorTarefas.GerarRelatorio.Enums;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace GerenciadorTarefas.GerarRelatorio.Models;
public class Tarefa
{

   [BsonId]
   [BsonElement("_id"), BsonRepresentation(BsonType.String)]
   public Guid Id { get; set; }
   public string Dados { get; set; }
   public StatusTarefaEnum Status { get; set; }
   [BsonRepresentation(BsonType.Int32)]
   public int Tentativa { get; set; }
}
