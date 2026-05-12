# ClinicLab WPF

Sistema desktop desenvolvido em WPF + C# para gerenciamento de pacientes em ambiente clínico/laboratorial.

O projeto foi criado com foco em arquitetura desktop corporativa utilizando MVVM, Entity Framework Core e PostgreSQL, simulando aplicações reais utilizadas em ambientes empresariais.

---

# Objetivo do Projeto

O objetivo deste projeto é demonstrar:

- Desenvolvimento desktop com WPF
- Arquitetura MVVM
- Integração com PostgreSQL
- Persistência utilizando Entity Framework Core
- Organização de projeto enterprise
- Uso de Repository Pattern
- Data Binding em WPF
- CRUD completo em aplicação desktop

---

# Tecnologias Utilizadas

## Linguagem

- C#
- XAML

---

# Frameworks e Bibliotecas

- .NET 9
- WPF (Windows Presentation Foundation)
- Entity Framework Core
- CommunityToolkit.Mvvm

---

# Banco de Dados

- PostgreSQL 17
- pgAdmin 4

---

# Ferramentas Utilizadas

- Visual Studio Code
- Git
- GitHub
- .NET CLI
- NuGet

---

# Arquitetura do Projeto

O projeto foi estruturado utilizando o padrão MVVM (Model-View-ViewModel), separando responsabilidades entre:

## Models

Responsáveis pelas entidades da aplicação e representação dos dados.

## Views

Responsáveis pelas telas e interface gráfica em WPF/XAML.

## ViewModels

Responsáveis pela lógica de apresentação, comandos e Data Binding.

## Repositories

Responsáveis pela comunicação e persistência no banco PostgreSQL.

## Data

Responsável pela configuração do Entity Framework e DbContext.

---

# Funcionalidades Implementadas

- Cadastro de pacientes
- Integração com PostgreSQL
- Listagem automática em DataGrid
- Persistência utilizando Entity Framework Core
- Data Binding com MVVM
- Commands utilizando CommunityToolkit.Mvvm

---

# Estrutura do Projeto

```text
src/
 └── ClinicLab.App/
      ├── Models/
      ├── Views/
      ├── ViewModels/
      ├── Repositories/
      ├── Data/
      ├── Services/
      ├── Helpers/
      └── Assets/
Como Executar
Clonar projeto
git clone https://github.com/TiagoNunesSantana/wpf-c.git
Restaurar dependências
dotnet restore
Executar aplicação
dotnet run
Banco de Dados

Criar banco PostgreSQL:

CREATE DATABASE cliniclab;

Configurar connection string em:

Data/AppDbContext.cs
Próximas Implementações
Login de usuários
Dashboard administrativo
CRUD completo
Validações
Navegação entre telas
Relatórios
Deploy PostgreSQL no Railway
Melhorias visuais e responsividade
Autor

Tiago Nunes Santana

LinkedIn:
https://www.linkedin.com/in/tiago-santana-25951338