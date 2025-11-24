# Livraria - Clean Architecture Study

Este projeto é uma aplicação de gerenciamento de livraria desenvolvida com **.NET 9** e **Blazor Server**, criada com o objetivo principal de estudar e aplicar os conceitos de **Clean Architecture** (Arquitetura Limpa).

## Objetivo

O intuito deste projeto é demonstrar como estruturar uma aplicação moderna separando responsabilidades, facilitando a testabilidade e a manutenção. O foco não é apenas o CRUD, mas sim como as camadas interagem entre si respeitando as regras de dependência.

## Tecnologias Utilizadas

- **.NET 9**
- **Blazor Server** (Interactive Server)
- **Entity Framework Core**
- **SQLite**
- **Bootstrap 5**

## Estrutura do Projeto (Clean Architecture)

A solução está dividida em projetos que representam as camadas da arquitetura:

### 1. **Livraria.Domain** (Núcleo)
Contém as regras de negócio corporativas e entidades. É o coração do projeto e não depende de nenhuma outra camada.
- **Entities**: `Books`
- **Interfaces**: `IBookRepository`
- **Enums**: `Category`, `Publisher`

### 2. **Livraria.Application** (Aplicação)
*Em desenvolvimento.* Responsável por orquestrar os casos de uso da aplicação.
- Atualmente, a lógica está simplificada, mas idealmente conteria Services/UseCases.

### 3. **Livraria.Infrastructure** (Infraestrutura)
Implementa as interfaces definidas no Domínio e lida com detalhes técnicos externos (banco de dados, arquivos, etc).
- **Context**: `ApplicationDbContext`
- **Repositories**: `BookRepository` (Implementação do EF Core)

### 4. **Livraria.Blazor** (Interface de Usuário)
A camada de apresentação. Depende da Aplicação e Infraestrutura (para injeção de dependência).
- **Components**: Páginas e componentes Razor (`BooksCatalog`, `BookCard`, `DeleteDialog`).

### 5. **Livraria.CrossCutting** (Transversal)
Responsável pela configuração de Injeção de Dependência (IoC), garantindo que a camada de Apresentação não precise conhecer detalhes concretos da Infraestrutura diretamente.

## Funcionalidades

- **Listagem de Livros**: Visualização em cards.
- **Cadastro**: Adição de novos livros com validação.
- **Edição**: Atualização de dados existentes.
- **Exclusão**: Remoção com diálogo de confirmação customizado.

## Como Rodar

1. Certifique-se de ter o **.NET SDK** instalado.
2. Clone o repositório.
3. Navegue até a pasta da solução.
4. Execute o projeto:
   ```bash
   dotnet run --project Livraria.Blazor
   ```
5. O banco de dados SQLite será criado automaticamente na primeira execução.
