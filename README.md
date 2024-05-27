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

[Docker Desktop](https://www.docker.com/products/docker-desktop/)
[Rancher Desktop](https://rancherdesktop.io/)
[Sql Server Management Studio](https://learn.microsoft.com/pt-br/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver16)

### 🔧 Instalação

Siga as instruções abaixo para executar o projeto TODOLIST

1 - Clone o repositório do projeto 
```sh 
git clone https://github.com/cesarmendes/todobackend 
```
2 - Através de um terminal de prompt, entre na pasta raiz do projeto e certifique-se de estar no mesmo nível do arquivo docker-compose.yml 
```sh 
cd todobackend
```
3 - Utilize o Docker Compose para subir os serviços necessários 
```sh 
docker-compose up
```
4 - Se conecte ao servidor de banco de dados que está rodando localmente, utilizando o Sql Server Management Studio crie uma conexão utilizando 'Autenticação do Sql Server' e forneça o usuário 'SA' e senha 'todolist123!'
5 - Ainda no SSMS, abra o arquivo scripts.sql que foi gerado via EF Migrations e execute o script para criar banco de dados e tabelas necessárias para o projeto.  

## ⚙️ Links para utilizar

Quando a instalação estiver conclúida, o usuário poderá ter acesso ao sistema e os recuros de backend através dos links abaixo:
[Frontend](http://localhost:8080/)
[Api](http://localhost:5000/swagger/index.html)
[Kibana](http://localhost:5601/app/home#/)
[RabbitMQ](http://localhost:15672/)

## 🛠️ Construído com

Mencione as ferramentas que você usou para criar seu projeto

* [React](https://react.dev/) - O framework web usado
* [MUI](https://mui.com/) - Biblioteca de componentes visuais
* [ROME](https://rometools.github.io/rome/) - Usada para gerar RSS

## 🖇️ Colaborando

Por favor, leia o [COLABORACAO.md](https://gist.github.com/usuario/linkParaInfoSobreContribuicoes) para obter detalhes sobre o nosso código de conduta e o processo para nos enviar pedidos de solicitação.

## 📌 Versão

Nós usamos [SemVer](http://semver.org/) para controle de versão. Para as versões disponíveis, observe as [tags neste repositório](https://github.com/suas/tags/do/projeto). 

## ✒️ Autores

Mencione todos aqueles que ajudaram a levantar o projeto desde o seu início

* **Um desenvolvedor** - *Trabalho Inicial* - [umdesenvolvedor](https://github.com/linkParaPerfil)
* **Fulano De Tal** - *Documentação* - [fulanodetal](https://github.com/linkParaPerfil)

Você também pode ver a lista de todos os [colaboradores](https://github.com/usuario/projeto/colaboradores) que participaram deste projeto.

## 📄 Licença

Este projeto está sob a licença (sua licença) - veja o arquivo [LICENSE.md](https://github.com/usuario/projeto/licenca) para detalhes.

## 🎁 Expressões de gratidão

* Conte a outras pessoas sobre este projeto 📢;
* Convide alguém da equipe para uma cerveja 🍺;
* Um agradecimento publicamente 🫂;
* etc.


---
⌨️ com ❤️ por [Armstrong Lohãns](https://gist.github.com/lohhans) 😊
