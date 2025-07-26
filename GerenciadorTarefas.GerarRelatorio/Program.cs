using GerenciadorTarefas.GerarRelatorio;
using GerenciadorTarefas.GerarRelatorio.Data;
using GerenciadorTarefas.GerarRelatorio.Interfaces;
using GerenciadorTarefas.GerarRelatorio.Repository;
using GerenciadorTarefas.GerarRelatorio.Services;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddSingleton<ITarefaRepository, TarefaRepository>();
builder.Services.AddSingleton<IMessageQueueService, MessageQueueService>();
builder.Services.AddSingleton<MongoDbContext>();

builder.Services.AddHostedService<Worker>();

var host = builder.Build();
host.Run();
