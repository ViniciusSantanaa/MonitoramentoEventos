Monitoramento de Eventos API
📝 Descrição
Esta é uma API RESTful desenvolvida em .NET 7 para um sistema de monitoramento de eventos. A API permite gerenciar usuários, locais monitorados e os alertas gerados, fornecendo um backend robusto para uma aplicação cliente.

O projeto utiliza Entity Framework Core para o mapeamento objeto-relacional (ORM) e se conecta a um banco de dados SQL Server. A documentação da API é gerada automaticamente e pode ser visualizada interativamente através do Swagger (OpenAPI).

🔗 Link do Repositório
O código-fonte completo deste projeto está disponível no GitHub:


🏛️ Arquitetura e Diagramas
A API segue uma arquitetura em camadas simples, comum em aplicações .NET, separando as responsabilidades de controllers, lógica de dados e modelos.

Diagrama da Arquitetura

    graph TD

    A[Cliente (Ex: App Web/Mobile)] --> B{API Gateway / Roteamento ASP.NET};
    
    B --> C[Controllers];
    
    C --> D{DbContext (Entity Framework)};
    
    D <--> E[Banco de Dados (SQL Server)];
    

    subgraph "Camada da API"
        B
        C
    end

    subgraph "Camada de Dados"
        D
    end

    subgraph "Infraestrutura"
        E
    end

🛠️ Tecnologias Utilizadas
.NET 7: Framework para construção da aplicação.

ASP.NET Core: Para criar a API RESTful.

Entity Framework Core 7: Para a camada de acesso a dados.

SQL Server: Banco de dados relacional.

Swagger (Swashbuckle): Para documentação e teste interativo da API.

📂 Estrutura do Projeto
/Models: Contém as classes de entidade que representam as tabelas do banco de dados (Usuario, LocalMonitorado, Alerta).

/Data: Contém o DbContext (AppDbContext.cs), responsável pela comunicação com o banco de dados.

/Controllers: Contém os controladores da API, que expõem os endpoints para cada entidade.

appsettings.json: Arquivo de configuração (incluindo a string de conexão).

Program.cs: Arquivo de inicialização da aplicação (configuração de serviços e middleware).

🚀 Desenvolvimento
Siga os passos abaixo para configurar e executar o projeto localmente.

1. Pré-requisitos
.NET 7 SDK

SQL Server (Express ou outra edição)

Um editor de código como Visual Studio ou VS Code.

2. Configuração do Ambiente
Clone o Repositório:

git clone https://github.com/ViniciusSantanaa/MonitoramentoEventos.git
cd MonitoramentoEventos

Configure a String de Conexão:
Abra o arquivo appsettings.json e altere a DefaultConnection para apontar para o seu banco de dados SQL Server.

{
  "ConnectionStrings": {
    "DefaultConnection": "Server=SEU_SERVIDOR;Database=MonitoramentoDb;Trusted_Connection=True;Encrypt=False;TrustServerCertificate=True;"
  }
}

Aplique as Migrations:
Para criar o banco de dados e as tabelas, execute os seguintes comandos no terminal:

# Instalar a ferramenta do EF Core (se ainda não tiver)
dotnet tool install --global dotnet-ef

# Aplicar as migrations para criar o banco de dados
dotnet ef database update

3. Executando a Aplicação
Pela linha de comando:

dotnet run

Pelo Visual Studio:
Abra a solução (.sln) e pressione F5.

🧪 Testes e Exemplos de Uso
A forma mais simples de testar a API é utilizando a interface do Swagger.

1. Acesso via Swagger
Após executar a aplicação, acesse a seguinte URL no seu navegador:

URL do Swagger: https://localhost:<PORTA>/swagger

Você verá uma página interativa com todos os endpoints disponíveis, onde poderá testá-los diretamente.

2. Exemplos de Requisições
Abaixo estão exemplos de corpos (body) de requisição em formato JSON para os endpoints POST.

Criar um novo Usuário
Endpoint: POST /api/Usuarios

Corpo (JSON):

{
  "nome": "João da Silva",
  "email": "joao.silva@example.com"
}

Criar um novo Local Monitorado
Endpoint: POST /api/LocaisMonitorados

Corpo (JSON):

{
  "nome": "Escritório Central",
  "endereco": "Rua das Flores, 123, São Paulo, SP"
}

Criar um novo Alerta
Endpoint: POST /api/Alertas

Corpo (JSON):

{
  "descricao": "Movimento suspeito detectado na entrada principal.",
  "dataHora": "2024-10-27T14:30:00",
  "status": "Aberto",
  "usuarioId": 1,
  "localId": 1
}

Nota: Os valores de usuarioId e localId devem corresponder a IDs existentes no banco de dados.

🌐 Endpoints da API
A seguir, a lista completa dos endpoints para referência.

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

