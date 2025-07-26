using GerenciadorTarefas.EnviarEmail.Enums;
using GerenciadorTarefas.EnviarEmail.Interfaces;
using GerenciadorTarefas.EnviarEmail.Models;
using GerenciadorTarefas.EnviarEmail.Repository;
using GerenciadorTarefas.EnviarEmail.Services;
using MongoDB.Bson.IO;
using System.Text.Json;

namespace GerenciadorTarefas.EnviarEmail;

public class Worker : BackgroundService
{
   private readonly ILogger<Worker> _logger;
   private readonly IMessageQueueService _queueService;
   private readonly ITarefaRepository _repository;

   public Worker(ILogger<Worker> logger, IMessageQueueService queueService, ITarefaRepository tarefaRepository)
   {
      _logger = logger;
      _queueService = queueService;
      _repository = tarefaRepository;
   }

   protected override Task ExecuteAsync(CancellationToken stoppingToken)
   {
      _queueService.Consumir(async (mensagem) =>
      {
         var tarefa = JsonSerializer.Deserialize<Tarefa>(mensagem);
         if (tarefa == null) return;
         bool sucesso = false;


         try
         {
            for (int tentativa = 1; tentativa <= 3 && !sucesso; tentativa++)
            {
               sucesso = await ProcessarTarefa(tarefa);
            }
         }
         catch (Exception ex)
         {
            _logger.LogInformation($"Falha ao processar email");
            await _repository.AtualizarStatus(tarefa.Id, StatusTarefaEnum.Erro);
         }
      });

      return Task.CompletedTask;
   }

   public async Task<bool> ProcessarTarefa(Tarefa tarefa)
   {
      await _repository.AtualizarStatus(tarefa.Id, StatusTarefaEnum.EmProcessamento);
      _logger.LogInformation($"Processando os dados: {tarefa.Dados}");

      await Task.Delay(1500);

      _logger.LogInformation($"Email processado com sucesso. {tarefa.Id}");
      await _repository.AtualizarStatus(tarefa.Id, StatusTarefaEnum.Concluida);
      return true;
   }
}
