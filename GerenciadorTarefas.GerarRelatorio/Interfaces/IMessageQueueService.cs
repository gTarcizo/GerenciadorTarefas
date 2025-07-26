namespace GerenciadorTarefas.GerarRelatorio.Interfaces;
public interface IMessageQueueService
{
   void Publicar(string mensagem);
   void Consumir(Func<string, Task> processarMensagem);

}
