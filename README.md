# 🛍️ SimpleShop API

SimpleShop is a RESTful Web API built with .NET 8 that allows you to manage products and orders for a basic e-commerce backend. This solution follows best practices such as Clean Architecture, DTOs, Repository and Service layers, AutoMapper, and EF Core with SQL Server.

---

## 📁 Solution Structure

SimpleShopAPI.sln
├── SimpleShopAPI/ # API (Web)
├── BusinessLogicLayer/ # Services, Automapper & Repositories
├── DataAccessLayer/ # EF Core Models, DbContext, and Seed

---

## 🚀 Features

✅ Full CRUD for Products  
✅ Full CRUD for Orders  
✅ Stock updates tied to order operations  
✅ DTOs to control data flow  
✅ Repository & Service pattern  
✅ AutoMapper integration  
✅ Swagger UI for testing  
✅ Seeded data (50 products)

---

## 🔧 Technologies

- .NET 8
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server / LocalDb
- AutoMapper
- Swagger / Swashbuckle

---

## 🛠️ Getting Started

### 1. Clone the repo

```bash
git clone https://github.com/your-username/SimpleShopAPI.git
cd SimpleShopAPI
