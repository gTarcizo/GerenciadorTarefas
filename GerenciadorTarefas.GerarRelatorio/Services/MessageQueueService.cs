using GerenciadorTarefas.GerarRelatorio.Interfaces;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace GerenciadorTarefas.GerarRelatorio.Services;
public class MessageQueueService : IMessageQueueService
{
   private readonly IConnection _connection;
   private readonly IModel _channel;
   private readonly string? _nomeFila;

   public MessageQueueService(IConfiguration config)
   {
      _nomeFila = config["RabbitMq:NomeFila"];

      var factory = new ConnectionFactory
      {
         HostName = config["RabbitMq:HostName"],
         UserName = config["RabbitMq:UserName"],
         Password = config["RabbitMq:Password"],
         Port = int.Parse(config["RabbitMq:Port"])
      };

      _connection = factory.CreateConnection();
      _channel = _connection.CreateModel();

      _channel.QueueDeclare(_nomeFila, durable: true, exclusive: false, autoDelete: false);
   }

   public void Publicar(string mensagem)
   {
      var body = Encoding.UTF8.GetBytes(mensagem);

      _channel.BasicPublish(
          exchange: "",
          routingKey: _nomeFila,
          basicProperties: null,
          body: body
      );
   }

   public void Consumir(Func<string, Task> processarMensagem)
   {
      var consumidor = new EventingBasicConsumer(_channel);
      consumidor.Received += async (modelo, ea) =>
      {
         var corpo = ea.Body.ToArray();
         var mensagem = Encoding.UTF8.GetString(corpo);
         await processarMensagem(mensagem);
      };

      _channel.BasicConsume(queue: _nomeFila, autoAck: true, consumer: consumidor);
   }
}
