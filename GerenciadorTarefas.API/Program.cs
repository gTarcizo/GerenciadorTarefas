using GerenciadorTarefas.API.Endpoints.Tarefa;
using GerenciadorTarefas.Application.Services;
using GerenciadorTarefas.Application.Interfaces;
using GerenciadorTarefas.Infrastructure.Repository;
using GerenciadorTarefas.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region Scoped
builder.Services.AddScoped<ITarefaService, TarefaService>();
builder.Services.AddScoped<ITarefaRepository, TarefaRepository>();
builder.Services.AddSingleton<MongoDbContext>();
#endregion

var app = builder.Build();

#region Tarefa
app.MapMethods(TarefaGET.Pattern, TarefaGET.Methods, TarefaGET.Handler);
app.MapMethods(TarefaPost.Pattern, TarefaPost.Methods, TarefaPost.Handler);
#endregion

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.Run();
