# 🏥 ClinicLab WPF

![C#](https://img.shields.io/badge/C%23-.NET-blue)
![WPF](https://img.shields.io/badge/WPF-Desktop-purple)
![PostgreSQL](https://img.shields.io/badge/Database-PostgreSQL-336791)
![Entity Framework Core](https://img.shields.io/badge/ORM-Entity%20Framework%20Core-green)
![MVVM](https://img.shields.io/badge/Architecture-MVVM-orange)
![Status](https://img.shields.io/badge/Status-Em%20desenvolvimento-yellow)

Sistema desktop desenvolvido em **WPF + C#** para gerenciamento de clínicas e laboratórios.

O projeto foi criado com foco em demonstrar uma aplicação corporativa desktop utilizando **MVVM**, **Entity Framework Core**, **PostgreSQL**, **Repository Pattern**, navegação entre módulos e configuração inicial via **Wizard**.

---

## 📌 Objetivo do Projeto

O objetivo do **ClinicLab** é simular uma aplicação real de ambiente clínico/laboratorial, permitindo o gerenciamento de informações essenciais como pacientes e exames.

Este projeto também serve como portfólio técnico para demonstrar conhecimento em:

- Desenvolvimento desktop com **WPF**
- Programação em **C# / .NET**
- Arquitetura **MVVM**
- Integração com **PostgreSQL**
- Persistência com **Entity Framework Core**
- Uso de **Migrations**
- Organização em camadas
- Repository Pattern
- CRUD completo
- Navegação entre telas
- Dashboard dinâmico
- Configuração de banco via Wizard

---

## 🧩 Funcionalidades

### 📊 Dashboard

- Exibição de indicadores do sistema
- Total de pacientes cadastrados
- Total de exames cadastrados
- Último paciente cadastrado
- Data/hora da última atualização

### 👤 Pacientes

- Cadastro de pacientes
- Edição de pacientes
- Exclusão de pacientes
- Busca por nome ou CPF
- Máscara de CPF no formato `000.000.000-00`
- Máscara de telefone no formato `(99) 98888-9999`
- Validação de campos obrigatórios
- Listagem em `DataGrid`

### 🧪 Exames

- Cadastro de exames
- Edição de exames
- Exclusão de exames
- Busca por nome ou descrição
- Controle de exame ativo/inativo
- Valor do exame
- Prazo de entrega em dias
- Listagem em `DataGrid`

### ⚙️ Wizard de Configuração

Na primeira execução, a aplicação exibe um Wizard para configurar a conexão com o banco de dados.

Opções disponíveis:

- PostgreSQL local
- PostgreSQL externo/Railway

A configuração é salva localmente no perfil do usuário.

---

## 🛠️ Tecnologias Utilizadas

### Linguagens

- C#
- XAML

### Frameworks e Bibliotecas

- .NET
- WPF - Windows Presentation Foundation
- Entity Framework Core
- CommunityToolkit.Mvvm
- Npgsql Entity Framework Core Provider

### Banco de Dados

- PostgreSQL
- pgAdmin
- Railway PostgreSQL opcional

### Ferramentas

- Visual Studio Code
- .NET CLI
- Git
- GitHub
- NuGet
- Railway

---

## 🧱 Arquitetura

O projeto utiliza o padrão **MVVM - Model View ViewModel**.

Essa arquitetura separa responsabilidades entre interface, comportamento da tela, entidades de negócio e persistência de dados.

### Models

Representam as entidades da aplicação.

Exemplos:

- `Paciente`
- `Exame`
- `AppSettings`

### Views

Representam as telas da aplicação em WPF/XAML.

Exemplos:

- `DashboardView`
- `PacientesView`
- `ExamesView`
- `SetupWizardWindow`

### ViewModels

Controlam a lógica de apresentação, comandos, bindings e comunicação com repositories.

Exemplos:

- `DashboardViewModel`
- `PacienteViewModel`
- `ExameViewModel`

### Repositories

Responsáveis pela comunicação com o banco de dados utilizando Entity Framework Core.

Exemplos:

- `PacienteRepository`
- `ExameRepository`

### Services

Responsáveis por serviços auxiliares da aplicação.

Exemplo:

- `ConfigService`

### Helpers

Responsáveis por configurações globais.

Exemplo:

- `AppConfig`

---

## 📁 Estrutura do Projeto

```text
WPF-C#/
│
├── src/
│   └── ClinicLab.App/
│       │
│       ├── Models/
│       │   ├── Paciente.cs
│       │   ├── Exame.cs
│       │   └── AppSettings.cs
│       │
│       ├── Views/
│       │   ├── DashboardView.xaml
│       │   ├── DashboardView.xaml.cs
│       │   ├── PacientesView.xaml
│       │   ├── PacientesView.xaml.cs
│       │   ├── ExamesView.xaml
│       │   ├── ExamesView.xaml.cs
│       │   ├── SetupWizardWindow.xaml
│       │   └── SetupWizardWindow.xaml.cs
│       │
│       ├── ViewModels/
│       │   ├── DashboardViewModel.cs
│       │   ├── PacienteViewModel.cs
│       │   └── ExameViewModel.cs
│       │
│       ├── Repositories/
│       │   ├── PacienteRepository.cs
│       │   └── ExameRepository.cs
│       │
│       ├── Data/
│       │   ├── AppDbContext.cs
│       │   └── AppDbContextFactory.cs
│       │
│       ├── Services/
│       │   └── ConfigService.cs
│       │
│       ├── Helpers/
│       │   └── AppConfig.cs
│       │
│       ├── Assets/
│       ├── App.xaml
│       ├── App.xaml.cs
│       ├── MainWindow.xaml
│       └── MainWindow.xaml.cs
│
├── database/
├── docs/
│   └── screenshots/
│
├── README.md
├── .gitignore
└── LICENSE

🗄️ Banco de Dados

A aplicação utiliza PostgreSQL como banco de dados relacional.

As tabelas são criadas via Entity Framework Core Migrations.

Principais tabelas:

Pacientes
Exames
__EFMigrationsHistory
🔌 Configuração do Banco

A aplicação pode utilizar banco local ou banco externo.

PostgreSQL Local

Connection string padrão:

Host=localhost;Port=5432;Database=cliniclab;Username=postgres;Password=postgres

Banco local esperado:

CREATE DATABASE cliniclab;
PostgreSQL Railway

Também é possível utilizar PostgreSQL hospedado no Railway.

Exemplo de connection string:

Host=SEU_HOST;Port=SUA_PORTA;Database=railway;Username=postgres;Password=SUA_SENHA;SSL Mode=Require;Trust Server Certificate=true

Essa configuração pode ser informada no Wizard de Configuração Inicial.

🧙 Wizard de Configuração

Na primeira execução, a aplicação abre uma tela de configuração inicial.

Nessa tela, o usuário pode escolher:

PostgreSQL local
PostgreSQL Railway

Após salvar, a configuração fica armazenada localmente.

Arquivo salvo:

%APPDATA%/ClinicLab/cliniclab-config.json

No Windows, normalmente fica em:

C:\Users\SEU_USUARIO\AppData\Roaming\ClinicLab\cliniclab-config.json
🔄 Como Resetar o Wizard

Caso queira apagar a configuração salva e abrir o Wizard novamente, execute no PowerShell:

Remove-Item "$env:APPDATA\ClinicLab\cliniclab-config.json" -Force

Depois execute novamente a aplicação:

dotnet run

Esse procedimento é útil para:

trocar o banco local pelo Railway;
testar a primeira execução;
corrigir uma connection string incorreta;
reconfigurar o ambiente.
🌎 Variável de Ambiente

Também é possível configurar a connection string via variável de ambiente:

$env:CLINICLAB_CONNECTION_STRING="Host=localhost;Port=5432;Database=cliniclab;Username=postgres;Password=postgres"

A aplicação utiliza a seguinte ordem de prioridade:

1. Variável de ambiente CLINICLAB_CONNECTION_STRING
2. Arquivo local cliniclab-config.json
3. Connection string padrão local
▶️ Como Executar Localmente
1. Clonar o repositório
git clone https://github.com/TiagoNunesSantana/wpf-c.git
2. Acessar a pasta do projeto
cd wpf-c/src/ClinicLab.App
3. Restaurar dependências
dotnet restore
4. Criar ou atualizar o banco de dados
dotnet ef database update
5. Executar a aplicação
dotnet run
🧪 Testar Primeira Execução

Para simular a primeira execução da aplicação, remova o arquivo de configuração:

Remove-Item "$env:APPDATA\ClinicLab\cliniclab-config.json" -Force

Depois execute:

dotnet run

O Wizard de configuração deverá aparecer novamente.

📦 Como Gerar o Executável

Dentro da pasta:

src/ClinicLab.App

Execute:

dotnet publish -c Release -r win-x64 --self-contained true -p:PublishSingleFile=true

O executável será gerado em:

src/ClinicLab.App/bin/Release/net9.0-windows/win-x64/publish/
⬇️ Download da Aplicação

As versões executáveis serão disponibilizadas na aba Releases do GitHub:

https://github.com/TiagoNunesSantana/wpf-c/releases

## 🖼️ Screenshots

### Dashboard

![Dashboard](https://raw.githubusercontent.com/TiagoNunesSantana/wpf-c/main/docs/screenshots/dashboard.png)

### Pacientes

![Pacientes](https://raw.githubusercontent.com/TiagoNunesSantana/wpf-c/main/docs/screenshots/pacientes.png)

### Exames

![Exames](https://raw.githubusercontent.com/TiagoNunesSantana/wpf-c/main/docs/screenshots/exames.png)

### Wizard de Configuração

![Wizard de Configuração](https://raw.githubusercontent.com/TiagoNunesSantana/wpf-c/main/docs/screenshots/wizard.png)

🗺️ Roadmap

Próximas melhorias planejadas:

Cadastro de agendamentos
Associação de pacientes com exames
Resultados de exames
Login de usuários
Controle de permissões
Relatórios
Exportação para PDF
Melhorias visuais no layout
Publicação de release com instalador
Integração completa com PostgreSQL Railway
🚧 Status do Projeto

Em desenvolvimento.

Funcionalidades já implementadas:

CRUD de pacientes
CRUD de exames
Dashboard dinâmico
Navegação lateral
Máscaras de CPF e telefone
Wizard de configuração
Integração com PostgreSQL
Migrations com Entity Framework Core
👨‍💻 Autor

Tiago Nunes Santana

LinkedIn:

https://www.linkedin.com/in/tiago-santana-25951338

GitHub:

https://github.com/TiagoNunesSantana
📄 Licença

Este projeto está disponível para fins de estudo, demonstração técnica e portfólio profissional.