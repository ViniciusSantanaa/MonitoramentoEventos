Monitoramento de Eventos API
📝 Descrição
Esta é uma API RESTful desenvolvida em .NET 7 para um sistema de monitoramento de eventos. A API permite gerenciar usuários, locais monitorados e os alertas gerados, fornecendo um backend robusto para uma aplicação cliente.

O projeto utiliza Entity Framework Core para o mapeamento objeto-relacional (ORM) e se conecta a um banco de dados SQL Server. A documentação da API é gerada automaticamente e pode ser visualizada interativamente através do Swagger (OpenAPI).

🛠️ Tecnologias Utilizadas
.NET 7: Framework para construção da aplicação.

ASP.NET Core: Para criar a API RESTful.

Entity Framework Core 7: Para a camada de acesso a dados.

SQL Server: Banco de dados relacional.

Swagger (Swashbuckle): Para documentação e teste interativo da API.

📂 Estrutura do Projeto
O projeto está organizado da seguinte forma:

/Models: Contém as classes de entidade que representam as tabelas do banco de dados (Usuario, LocalMonitorado, Alerta).

/Data: Contém o DbContext (AppDbContext.cs), responsável pela comunicação com o banco de dados e mapeamento das entidades.

/Controllers: Contém os controladores da API, que expõem os endpoints para cada entidade.

appsettings.json: Arquivo de configuração, onde a string de conexão do banco de dados deve ser definida.

Program.cs: Arquivo principal de inicialização da aplicação, onde os serviços e o pipeline de middleware são configurados.

🚀 Como Executar o Projeto
Siga os passos abaixo para configurar e executar o projeto localmente.

1. Pré-requisitos
.NET 7 SDK

SQL Server (Express ou outra edição)

Um editor de código como Visual Studio ou VS Code.

2. Clone o Repositório
git clone https://github.com/ViniciusSantanaa/MonitoramentoEventos.git
cd MonitoramentoEventos

3. Configure a String de Conexão
Abra o arquivo appsettings.json e altere a DefaultConnection para apontar para o seu banco de dados SQL Server.

Exemplo de appsettings.json:

{
  "ConnectionStrings": {
    "DefaultConnection": "Server=SEU_SERVIDOR;Database=MonitoramentoDb;Trusted_Connection=True;Encrypt=False;TrustServerCertificate=True;"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}

Nota: Encrypt=False e TrustServerCertificate=True são usados para ambientes de desenvolvimento. Para produção, configure um certificado SSL válido.

4. Aplique as Migrations
Para criar o banco de dados e as tabelas, execute os seguintes comandos no terminal, na pasta raiz do projeto:

# Instalar a ferramenta de linha de comando do EF Core (se ainda não tiver)
dotnet tool install --global dotnet-ef

# Aplicar as migrations para criar o banco de dados
dotnet ef database update

5. Execute a Aplicação
Você pode executar a aplicação de duas formas:

Pela linha de comando:

dotnet run

Pelo Visual Studio:

Abra o arquivo da solução (.sln).

Pressione F5 ou clique no botão "Play" para iniciar a depuração.

A aplicação estará rodando em https://localhost:<PORTA> e http://localhost:<PORTA>. A interface do Swagger estará disponível em https://localhost:<PORTA>/swagger.

🌐 Endpoints da API
A seguir estão os endpoints disponíveis para cada recurso.

api/Usuarios
Verbo

Rota

Descrição

GET

/

Retorna todos os usuários.

GET

/{id}

Retorna um usuário específico pelo ID.

POST

/

Cria um novo usuário.

PUT

/{id}

Atualiza um usuário existente.

DELETE

/{id}

Deleta um usuário.

api/LocaisMonitorados
Verbo

Rota

Descrição

GET

/

Retorna todos os locais monitorados.

GET

/{id}

Retorna um local específico pelo ID.

POST

/

Cria um novo local monitorado.

PUT

/{id}

Atualiza um local monitorado existente.

DELETE

/{id}

Deleta um local monitorado.

api/Alertas
Verbo

Rota

Descrição

GET

/

Retorna todos os alertas.

GET

/{id}

Retorna um alerta específico pelo ID.

POST

/

Cria um novo alerta.

PUT

/{id}

Atualiza um alerta existente.

DELETE

/{id}

Deleta um alerta.

