
using GerenciadorTarefas.Domain.Enums;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace GerenciadorTarefas.Domain.Entities;
public class Tarefa
{
   [BsonId]
   [BsonElement("_id"), BsonRepresentation(BsonType.String)]
   public Guid Id { get; set; }
   public TipoTarefaEnum Tipo { get; set; }
   public string Dados { get; set; }
   public StatusTarefaEnum Status { get; set; }

}
