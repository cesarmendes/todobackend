# TODOLIST

Essa aplicação nasceu com o objetivo de atender um teste técnico de uma grande empresa de investimentos de São Paulo, para a construção desse pequeno sistema seria
necessário atender as seguintes condições:
- Candidato codifica projeto com prazo de uma semana:
- Construir uma app para cadastro e consulta de tarefas (descrição/data/status).
- Arquitetura, página em Angular (ou front de sua escolha) + API + Worker com comunicação via RabbitMQ em .Net6  C#.
- Ter logs para suporte da aplicação.
- Aplicação de design patterns.
- Utilização de framework de persistência.
- Banco de dados livre.

### 📋 Pré-requisitos

Para rodar o projeto e utilizar, será necessário ter o Docker Desktop instalado na máquina ou ferramenta similar que permita
acesso aos comandos do Docker CLI que possa ser utilizado via prompt. Também será necessário o Sql Server Managment Studio para criar a estrutura
da base de dados.

* [Docker Desktop](https://www.docker.com/products/docker-desktop/)
* [Rancher Desktop](https://rancherdesktop.io/)
* [Sql Server Management Studio](https://learn.microsoft.com/pt-br/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver16)

### 🔧 Instalação

Siga as instruções abaixo para executar o projeto TODOLIST

1 - Clone o repositório do projeto 
```sh 
git clone https://github.com/cesarmendes/todolist 
```
2 - Através de um terminal de prompt, entre na pasta raiz do projeto e certifique-se de estar no mesmo nível do arquivo docker-compose.yml 
```sh 
cd todolist
```
3 - Utilize o Docker Compose para subir os serviços necessários 
```sh 
docker-compose up
```
4 - Se conecte ao servidor de banco de dados que está rodando localmente, utilizando o Sql Server Management Studio crie uma conexão utilizando 'Autenticação do Sql Server' e forneça as credenciais
```sh
usuário 'SA' e senha 'todolist123!'
```
5 - Ainda no SSMS, abra o arquivo scripts.sql que foi gerado via EF Migrations e execute o script para criar banco de dados e tabelas necessárias para o projeto.  

## ⚙️ Links para utilizar

Quando a instalação estiver conclúida, o usuário poderá ter acesso ao sistema e os recuros de backend através dos links abaixo:

* [Frontend](http://localhost:8080/) - Acesse para cadastrar e listar tarefas
* [Api](http://localhost:5000/swagger/index.html) - Acesse para ter acesso ao Swagger da Api
* [Kibana](http://localhost:5601/app/home#/) - Acesse para ter acesso aos logs das aplicações Api e Worker
* [RabbitMQ](http://localhost:15672/) - Acesse para ter acesso na filas dos serviços, usuário e senha 'rabbitmq'

## 🛠️ Construído com

Para a construção desse projeto, foram utlizados as ferramentas listadas abaixo:

* [React 18](https://react.dev/) - O framework de frontend SPA utilizado foi o React 18
* [MUI 5.15.18](https://mui.com/) - A biblioteca de componentes visuais MUI 5.15.18 para React
* [Typescript](https://www.typescriptlang.org/) - A linguagem foi utilizado typescript
* [Asp.NET Core 6](https://learn.microsoft.com/pt-br/aspnet/core/release-notes/aspnetcore-6.0?view=aspnetcore-6.0) - O framework para construção de APIs foi utilizado o Asp.NET Core 6. 
* [Entity Framework](https://learn.microsoft.com/en-us/ef/) - O ORM utilizado para manipulação de base de dados foi utilizado o Entity Framework 6
* [RabbitMQ](https://www.rabbitmq.com/docs) - O Broker de mensagens foi utilizdo o RabbitMQ com a biblioteca MassTransit
* [Sql Server Express](https://www.microsoft.com/pt-br/sql-server/sql-server-downloads) - A base de dados relacional foi utilizado o Sql Server Express.
* [ElasticSearch](https://www.elastic.co/pt/elasticsearch) - A base de dados para ingestão de logs foi utilizado o ElasticSearch
* [Kibana](https://www.elastic.co/pt/kibana) - A ferramenta de analise de dados foi utilizado o Kibana para visualizar os logs

