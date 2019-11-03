# Bank.Api

Api para a realização de operações bancárias tais como:
* Saque
* Depósito
* Transferência
* Extrato

## Sobre o projeto

Essa api foi criada utilizando as seguintes tecnologias:

* Microsoft ASP.NET Core 2.2
* Validação de comandos (fail-fast) via middleware usando a biblioteca [Fluent Validation](https://github.com/JeremySkinner/FluentValidation)
* Banco de dados SQL com [Sql Server](https://docs.microsoft.com/en-us/sql/sql-server/?view=sql-server-ver15)
* Documentação da API gerada com o [Swagger](https://swagger.io/)
* Docker e Docker Compose


## Pontos de melhoria
* Implementar autenticação via [JWT](https://medium.com/@renato.groffe/jwt-asp-net-core-2-2-exemplo-de-implementa%C3%A7%C3%A3o-3e10058c1a73)
* Melhorar a Apresentação do Extrato Bancário
* Adicionar Testes Unitários e de Integração


## Como rodar esse projeto em seu computador

Como a aplicação é containerizada basta executarmos:
```
sudo docker-compose up --build -d
```

Para vermos os logs da aplicação em tempo real basta executarmos:
```
sudo docker-compose logs -f
```

## Documentação

Esse projeto conta com uma documentação dos endpoints da API feita através do [Swagger](https://swagger.io/).
Após rodar a aplicação basta acessar a url "http://localhost:8000/swagger", caso esteja executando a aplicação no docker.


## Rotas

+ POST /api/account - cria uma conta bancária
+ GET /api/account/:accountNumber - lista uma conta bancária
+ POST ​/api​/account​/deposit - realiza um depósito bancário
+ POST ​/api​/account​/draft - realiza um saque bancário
+ POST ​/api​/account​/transfer - realiza uma transferência
