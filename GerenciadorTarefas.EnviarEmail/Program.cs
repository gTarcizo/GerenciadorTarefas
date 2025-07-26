using GerenciadorTarefas.EnviarEmail;
using GerenciadorTarefas.EnviarEmail.Data;
using GerenciadorTarefas.EnviarEmail.Interfaces;
using GerenciadorTarefas.EnviarEmail.Repository;
using GerenciadorTarefas.EnviarEmail.Services;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddSingleton<ITarefaRepository, TarefaRepository>();
builder.Services.AddSingleton<IMessageQueueService, MessageQueueService>();
builder.Services.AddSingleton<MongoDbContext>();

builder.Services.AddHostedService<Worker>();

var host = builder.Build();
host.Run();
