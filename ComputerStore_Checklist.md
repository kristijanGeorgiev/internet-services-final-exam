# ✅ ComputerStore Web API Project Setup – Checklist

## 📁 Project Structure

- [x] `ComputerStore.API` — ASP.NET Core Web API
- [x] `ComputerStore.Application` — Application layer
- [x] `ComputerStore.Infrastructure` — Data access & service implementations
- [x] `ComputerStore.Domain` — Core domain models
- [x] `ComputerStore.Tests` — xUnit test project

---

## 🔗 Project References

- [x] `API` → `Application`
- [x] `API` → `Infrastructure`
- [x] `Application` → `Domain`
- [x] `Infrastructure` → `Application`
- [x] `Infrastructure` → `Domain`
- [x] `Tests` → `API`
- [x] `Tests` → `Application`

---

## 📂 Folder Structure

### `ComputerStore.API/`
- [x] Controllers/
- [x] Mappings/
- [x] Middleware/

### `ComputerStore.Application/`
- [x] DTOs/
- [x] Interfaces/

### `ComputerStore.Domain/`
- [x] Entities/
- [x] Interfaces/

### `ComputerStore.Infrastructure/`
- [x] Data/
- [x] Repositories/
- [x] Services/

### `ComputerStore.Tests/`
- [x] IntegrationTest/
- [x] UnitTest/

---

## 📦 NuGet Packages

### `.API`
- [x] AutoMapper.Extensions.Microsoft.DependencyInjection
- [x] Microsoft.AspNetCore.Hosting
- [x] Microsoft.EntityFrameworkCore
- [x] Microsoft.EntityFrameworkCore.Design
- [x] Microsoft.EntityFrameworkCore.Tools
- [x] Microsoft.EntityFrameworkCore.SqlServer
- [x] Microsoft.VisualStudio.Web.CodeGeneration.Design

### `.Application`
- [x] Microsoft.EntityFrameworkCore

### `.Infrastructure`
- [x] Microsoft.AspNetCore.Hosting
- [x] Microsoft.EntityFrameworkCore
- [x] Microsoft.EntityFrameworkCore.Relational
- [x] Microsoft.EntityFrameworkCore.SqlServer

### `.Tests`
- [x] Moq
- [x] Microsoft.AspNetCore.Mvc.Testing

---

## 🛠 Development Order

- [x] 1. Define `Entities` in `.Domain`
- [x] 2. Create `DTOs` in `.Application`
- [x] 3. Define repository interfaces in `.Domain`
- [x] 4. Implement repositories in `.Infrastructure`
- [x] 5. Define service interfaces in `.Application`
- [x] 6. Implement services in `.Infrastructure`
- [x] 7. Create API controllers in `.API`
