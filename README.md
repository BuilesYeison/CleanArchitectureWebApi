# Clean Architecture Web API Template

## 📌 Project Overview

This project is a **.NET Core 8 Web API** template that follows **Clean Architecture** principles as defined by **Robert C. Martin**. It provides a well-structured foundation for building scalable and maintainable APIs, implementing best practices such as **CQRS, MediatR, FluentValidation, AutoMapper, and Entity Framework Core**.

## 🏗️ Solution Structure

The solution is divided into **four main projects**, each representing a specific layer in the **Clean Architecture** pattern:

### 1️⃣ **Application Layer** (`Application`)

- Contains **business logic** and **application rules**.
- Implements the **CQRS pattern** (Commands & Queries) using **MediatR**.
- Uses **FluentValidation** for request validation.
- Contains **DTOs, Mappings, Interfaces, and Wrappers**.

**📁 Key folders:**

- `Features/EntityName` → Organizes handlers for each entity.
  - `Commands` → Handles Create, Update, Delete operations.
  - `Queries` → Handles Read operations.
  - `Handlers` → Implements MediatR request handlers.
  - `DTO` → Defines Data Transfer Objects.
  - `Validators` → Contains FluentValidation rules.
- `Interfaces` → Contains repository and service interfaces.
- `Mappings` → Stores AutoMapper configuration.
- `Wrappers` → Standardized API responses.
- `DependencyInjection.cs` → Registers dependencies for this layer.

### 2️⃣ **Domain Layer** (`Domain`)

- Defines the **core business entities**.
- Contains **Enums, Exceptions, and Business Rules**.
- No external dependencies (pure C# classes).

**📁 Key folders:**

- `Entities` → Defines core domain models.
- `Enums` → Stores domain-level enumerations.
- `Exceptions` → Custom exceptions for domain logic.

### 3️⃣ **Infrastructure Layer** (`Infrastructure`)

- Implements **data access, services, and third-party integrations**.
- Uses **Entity Framework Core** for database management.
- Contains **repository implementations and service connectors**.

**📁 Key folders:**

- `Persistence` → Implements repository patterns and database context.
- `Migrations` → Stores EF Core migration scripts.
- `Services` → Implements external integrations.
- `DependencyInjection.cs` → Registers dependencies for this layer.

### 4️⃣ **Web API Layer** (`WebApi`)

- The entry point of the application.
- Configures **controllers, middlewares, and dependency injection**.
- Uses **Swagger for API documentation**.
- Implements **global exception handling** middleware.

**📁 Key folders:**

- `Controllers` → Handles HTTP requests and calls the Application layer.
- `Middleware` → Implements global exception handling.
- `Services` → Configures API-level dependencies.
- `appsettings.json` → Configuration file.
- `Program.cs` → Configures dependency injection and application startup.

## 🚀 Implemented Technologies & Libraries

- **ASP.NET Core 8** → Web API framework.
- **Entity Framework Core** → ORM for database access.
- **MediatR** → CQRS pattern implementation.
- **FluentValidation** → Request validation.
- **AutoMapper** → DTO to entity mapping.
- **Swagger / OpenAPI** → API documentation.

## 🏁 Getting Started

### 1️⃣ Clone the repository

```sh
 git clone https://github.com/BuilesYeison/CleanArchitectureWebApi.git
```

### 2️⃣ Install dependencies

```sh
 cd CleanArchitectureWebApi
 dotnet restore
```

### 3️⃣ Run the API

```sh
 dotnet run --project WebApi
```

## 📌 Future Enhancements

- ✅ Implement **Unit & Integration Tests** (xUnit + Moq).
- ✅ Implement **Serilog**.
- ✅ Add **Background Jobs** support (Hangfire, Quartz.NET).
- ✅ Introduce **Event-Driven Architecture** with RabbitMQ/Kafka.
- ✅ Configure **Authentication & Authorization** (JWT, Azure AD, Identity Server).

---

🎯 **Built for scalability and maintainability!** 🚀

