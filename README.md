# ewave-eventos-senior

##Features
* *Cadastro Funcionários*
* *Cadastro Categorias palestra*
* *Cadastro Eventos*
* *Cadastro Palestra*
* *Envio de email para organizadores (uma semana antes do evento, para confirmar participação)*
* *Confirmar Participação evento*
* *Envio de email para participantes e palestrante (três dias antes do evento para informar local e hora)*

## Tecnologias

**.NET Core 3.1** <br>
**Testes de Unidade** <br>
**Conteinerização** <br>
**REST** <br>
**DDD** <br>
**CQRS** <br>
**Swagger** <br>
**EntityFramework** <br>
**Sql Server** <br>
**HangFire** <br>


## Desafios
Desenvolver uma arquitetura escalável para grandes projetos.

## Melhorias
Mais formas de notificar os participantes dos eventos, sistema de eventos, autenticação de usuário(funcionarios), disponibilização de serviços com permissões, geração de relatórios e desenvolvimento do frontend em Angular 2+

# Executar o Projeto

Para executar o projeto, é necessário [docker](https://app.dbdesigner.net/signup  "docker")

Gerar Imagem container
```
docker image build -t eventos-api:dev -f docker/Dockerfile .
```

Inicia o container sql primeiro:
```
docker-compose -f docker/docker-compose-dev.yml up -d sqlserver
```

Aguardar aproximadamente 1min para container sql estar apto, depois iniciar o container com a API:
```
docker-compose -f docker/docker-compose-dev.yml up -d api
```

Finaliza o container caso necessário:
```
docker-compose -f docker/docker-compose-dev.yml down
```

Após :
- api : clicando [aqui](http://localhost:5000/swagger  "aqui").
- hangfire : clicando [aqui](http://localhost:5000/hangfire  "aqui").
