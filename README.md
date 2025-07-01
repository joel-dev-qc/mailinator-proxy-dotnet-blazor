# Mailinator Proxy – Blazor WebAssembly + .NET 9 Minimal API

A modern, clean UI for browsing Mailinator inboxes, built with Blazor WebAssembly and a .NET 9 Minimal API backend.
This project simplifies the experience of interacting with Mailinator's API, providing inbox viewing, reading emails, and more, in a rich UI experience.

---

## ✨ Features

- 📨 Browse any Mailinator inbox using the API key
- 📧 Read individual email messages
- ⭐ Mark emails as read
- ⭐ Mark mail inbox as favorite
- 🔄 Auto-refresh support (for near real-time updates)
- 🌙 Dark mode & light mode support
- 🧠 Search by mail inbox name
- 🧼 HTML email rendering (sanitized)

---

## 🧰 Tech Stack

### 🔹 Frontend

- **Blazor WebAssembly (.NET 9)**
- **MudBlazor** – UI component library
- **Blazored.LocalStorage** – local state persistence
- **FluentValidation** – form validation
- **HighlightBlazor** – syntax highlighting for emails/code content

### 🔹 Backend

- **.NET 9 Minimal API**
- **Carter** – lightweight framework for building modular HTTP routes with Minimal API
- **MediatR** – in-process messaging / CQRS
- **MailinatorApiClient** – typed client wrapper for Mailinator REST API
- **HtmlAgilityPack** – HTML parsing & sanitization
- **OpenAPI Microsoft Package** – API documentation
- **Scalar** - OpenAPI Client for documentation generation


## 🔧 Configuration

To run the app locally, you need to provide a **Mailinator API Key** via configuration.

Recommended method:

### 🔹 Option – Using Secret Manager (for development)

In the API project folder, run:

```bash
dotnet user-secrets init
dotnet user-secrets set "Mailinator:ApiKey" "your-mailinator-api-key"
```

### 🔹 Option 2 – Docker / Docker Compose using a `.env` file

Create a `.env` file at the **root of the repository** with the following content:

```env
Mailinator__ApiKey=your-mailinator-api-key
```

Then run the application using Docker Compose:

```bash
docker compose up --build
```
