# 🛒 OnlineShopCQRS

A simple **.NET 8 Web API** that demonstrates the **CQRS (Command Query Responsibility Segregation)** pattern using **MediatR** and an **in-memory database**.  

This project simulates an online shop where users can **add products** (commands) and **retrieve products** (queries). It’s a learning-oriented example to understand CQRS, clean architecture principles, and the use of MediatR in .NET.

---

## ✨ Features
- **CQRS pattern** with clear separation of write and read operations  
- **Commands**: Create, Update, Delete products  
- **Queries**: Retrieve all products or by Id  
- **In-memory database** using EF Core  
- **MediatR** for request handling  
- Minimal API setup with .NET 8  
- **Swagger UI** for testing endpoints 

## 📌 CQRS Flow Diagram

```mermaid
flowchart TD
    A[Client / UI] --> B[Controller / Minimal API Endpoint]
    B --> C[MediatR / Dispatcher]
    C --> D[Handler (Command or Query)]
    D --> E[Database / EF Core]
    E --> D
    D --> C
    C --> B
    B --> A
```
---

## 🚀 Getting Started

### Prerequisites
- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- Visual Studio Code (or any C# IDE)

### Run the project
```bash
git clone https://github.com/your-username/OnlineShopCQRS.git
cd OnlineShopCQRS
dotnet run
```

### Test the project
Check the port in the file OnlineShopCQRS.http
and navigate to http://localhost:5156/swagger
in your favourite browser
