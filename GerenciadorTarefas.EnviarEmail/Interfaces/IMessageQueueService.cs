namespace GerenciadorTarefas.EnviarEmail.Interfaces;
public interface IMessageQueueService
{
   void Publicar(string mensagem);
   void Consumir(Func<string, Task> processarMensagem);

}
