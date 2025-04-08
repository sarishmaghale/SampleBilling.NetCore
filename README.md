# Sample Billing System

This is a simple Inventory Management System built with ASP.NET Core using Code-First Approach (CFA). It allows basic **CRUD operations** for managing store items — add, update, delete, and bill items. All data is stored in a SQL Server database.

---

## 🔧 Features

- Add new items to inventory
- Update existing stock
- Delete items
- Generate simple bills from available stock
- Uses Code-First Migrations (CFA)

---

## 🛠️ Tech Stack

- ASP.NET Core (.NET Framework)
- Entity Framework (Code-First)
- SQL Server
- Razor View Engine (.cshtml)

---

## 🚀 Project Setup

Follow these steps to set up and run the project:

### 1. Clone the Repository

```bash
git clone https://github.com/your-username/sample-billing.git
cd sample-billing

### 2. Configure Database

Open appsettings.json or Web.config

"ConnectionStrings": {
  "DefaultConnection": "Server=YOUR_SERVER_NAME;Database=SampleBillingDB;Trusted_Connection=True;"
}

### 2. Create the database from migration

Tools > NuGet Package Manager > Package Manager Console

Update-Database

This is  minor simple project built to learn about the .NET concept. So basically, you'll have to first add data explicitly from database rather than the site.
