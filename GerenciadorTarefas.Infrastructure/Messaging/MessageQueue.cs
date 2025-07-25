using GerenciadorTarefas.Application.Interfaces;
using GerenciadorTarefas.Domain.Entities;
using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace GerenciadorTarefas.Infrastructure.Messaging;
public class MessageQueue : IMessageQueue
{
   private readonly string? _hostname;
   private readonly string? _exchange;
   public MessageQueue(IConfiguration configuration)
   {
      _hostname = configuration["RabbitMq:HostName"];
   }

   public async Task PublicarTarefa(Tarefa tarefa)
   {
      var factory = new ConnectionFactory { HostName = _hostname};
      var connection = await factory.CreateConnectionAsync();
      var channel = await connection.CreateChannelAsync();
      

      await channel.QueueDeclareAsync(
          queue: tarefa.Tipo.ToString(),
          durable: true,
          exclusive: false,
          autoDelete: false,
          arguments: null
      );

      var json = JsonSerializer.Serialize(tarefa);
      var body = Encoding.UTF8.GetBytes(json);

      await channel.BasicPublishAsync("",tarefa.Tipo.ToString(),body);
   }
}
