# 🌐 Monitoramento de Eventos - Global Solution 2025 (.NET API)

Este projeto é uma API REST desenvolvida em C# com ASP.NET Core, parte da entrega da disciplina *Advanced Business Development with .NET* da FIAP. A aplicação permite o cadastro e o gerenciamento de **usuários**, **alertas** e **locais monitorados**, sendo ideal para situações de emergência como enchentes ou desastres naturais.

## 🛠 Tecnologias Utilizadas

- ASP.NET Core 7.0
- Entity Framework Core
- SQL Server
- Swagger (Swashbuckle)
- Razor Pages (TagHelpers)
- C#

---

## 📁 Estrutura do Projeto

MonitoramentoEventos/
├── Controllers/
│ ├── AlertasController.cs
│ ├── UsuariosController.cs
│ └── LocaisMonitoradosController.cs
├── Models/
│ ├── Alerta.cs
│ ├── Usuario.cs
│ └── LocalMonitorado.cs
├── Data/
│ └── AppDbContext.cs
├── Program.cs
└── appsettings.json


---

## 🧠 Requisitos Atendidos

- [x] API REST com boas práticas
- [x] Banco de dados relacional (SQL Server)
- [x] Relacionamento 1:N (Usuário → Alertas; Local → Alertas)
- [x] Swagger para documentação
- [x] Migrations aplicadas
- [x] Razor com TagHelpers

---

## 🔁 Relacionamentos

- Um **Usuário** pode ter vários **Alertas**.
- Um **LocalMonitorado** pode conter vários **Alertas**.
- Cada **Alerta** pertence a exatamente um **Usuário** e um **LocalMonitorado**.

---

## 🧪 Testes com Swagger

Acesse o Swagger via:
https://localhost:porta da api/swagger


Exemplo de criação de um Alerta (POST `/api/alertas`):

```json
{
  "mensagem": "Enchente no centro!",
  "usuarioId": 1,
  "localMonitoradoId": 2
}
▶️ Como Executar


Clone o repositório:

git clone https://github.com/seu-usuario/monitoramento-eventos.git

Configure o appsettings.json:


"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=MonitoramentoEventosDb;Trusted_Connection=True;"
}


Aplique as migrations:

dotnet ef migrations add InitialCreate
dotnet ef database update

execute com "dotnet run"