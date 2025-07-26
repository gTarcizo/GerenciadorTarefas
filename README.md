# GerenciadorTarefas
Projeto de API que utiliza 2 workers independentes para processar filas diferentes no messagebroker utilizando banco de dados NoSQL.
A aplicação roda tanto em Http quanto Https

## Requisitos

- Visual Studio ou Visual Studio Code.
- .NET 8
- Docker (recomendo o [Docker Desktop](https://www.docker.com/products/docker-desktop/) pois foi o que utilizei.
- MongoDB.
- RabbitMQ.

## Rodando aplicação
- Clone este repositório e logo após de certificar que está tudo instalado, execute o comando do docker compose abaixo.
  
```bash
  -docker-compose up -d
```
- Agora é só executar a API (GerenciadorTarefas.API) junto aos Workers (GerenciadorTarefas.GerarRelatorio e GerenciadorTarefas.EnviarEmail).

### Detalhe
- As configurações tanto do RabbitMQ quanto do MongoDB estão nos appsettings.JSON
