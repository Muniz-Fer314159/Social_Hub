# 🌐 Mini Social API

API de uma mini rede social desenvolvida para fins de estudo, com foco em arquitetura real de backend, autenticação e uso de banco relacional.

## 🚀 Funcionalidades (MVP)

- 👤 Cadastro e login de usuários
- 📝 Criação de posts (texto e/ou imagem)
- 📰 Feed de postagens
- ❤️ Curtidas em posts
- 💬 Comentários em posts

---

## 🧠 Arquitetura

Frontend (futuro)  
⬇  
ASP.NET Core Web API  
⬇  
Entity Framework Core (ORM)  
⬇  
PostgreSQL  

---

## 🧰 Tecnologias Utilizadas

### 🔹 Backend
- ASP.NET Core Web API
- Entity Framework Core
- PostgreSQL
- ASP.NET Identity
- JWT Authentication
- Swagger (documentação da API)

### 🔹 Upload de Arquivos
- Armazenamento local de imagens (`wwwroot/uploads`)

---

## 🗂 Estrutura do Projeto

Backend/
├── Controllers/ → Endpoints da API
├── Models/ → Entidades do banco
├── DTOs/ → Objetos de entrada/saída
├── Services/ → Regras de negócio
├── Data/ → DbContext
├── wwwroot/uploads/ → Imagens dos posts
├── appsettings.json
└── Program.cs


---

## 🗄 Banco de Dados

O banco é gerado automaticamente via **Entity Framework Migrations** com base nos Models da aplicação.

Principais entidades:

- User (Identity)
- Post
- Comment
- Like

---

## 🔐 Autenticação

A API utiliza **JWT (JSON Web Token)** para autenticação.

Fluxo:
1. Usuário se registra
2. Faz login
3. Recebe um token JWT
4. Envia o token nas requisições protegidas

---

## ⚙️ Como Rodar o Projeto Localmente

1. Clonar o repositório 

2. Configurar a string de conexão com PostgreSQL no `appsettings.json`

3. dotnet run

4. Acessar o Swagger:

https://localhost:{porta}/swagger

---

# 🎯 Objetivo do Projeto
Este projeto tem como objetivo praticar:

- Arquitetura de APIs REST

- Relacionamentos em banco relacional

- Autenticação segura com JWT

- Boas práticas de backend

- Preparação para deploy em nuvem