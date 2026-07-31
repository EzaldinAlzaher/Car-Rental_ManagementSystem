# Car Rental Management System

A simple **Car Rental Management System** built with **C#**, **.NET**, and **Entity Framework Core** as a Console Application.

## ✨ Features

- Branch Management (CRUD)
- Employee Management (CRUD)
- Vehicle Type Management (CRUD)
- Vehicle Management (CRUD)
- Customer Management (CRUD)
- Rental Management
- Payment Management

## 🛠️ Technologies

- C#
- ASP.NET Core
- Entity Framework Core
- SQL Server
- Console Application

## 📂 Project Structure

```
CarRentalManagementSystem
│
├── DataAccess
│   └── AppDbContext.cs
│
├── Domain
│   ├── Branch.cs
│   ├── Customer.cs
│   ├── Employee.cs
│   ├── Payment.cs
│   ├── Rental.cs
│   ├── Vehicle.cs
│   └── VehicleType.cs
│
├── Operations
│   ├── BranchOperations.cs
│   ├── CustomerOperations.cs
│   ├── EmployeeOperations.cs
│   ├── PaymentOperations.cs
│   ├── RentalOperations.cs
│   ├── VehicleOperations.cs
│   └── VehicleTypeOperations.cs
│
└── Program.cs
```

## 🗄️ Database Relationships

- One Branch → Many Employees
- One Branch → Many Vehicles
- One Vehicle Type → Many Vehicles
- One Customer → Many Rentals
- One Vehicle → Many Rentals
- One Rental → Many Payments

## 🚀 Business Rules

- A vehicle cannot be rented unless it is **Available**.
- Vehicle status changes to **Rented** after creating a rental.
- Branches with related employees or vehicles cannot be deleted.
- Vehicle types with related vehicles cannot be deleted.
- Customers with active rentals cannot be deleted.

## 📷 Preview

Console-based application using Entity Framework Core for managing car rental operations.

## 👨‍💻 Author

**Ezaldin Alzaher**

- LinkedIn: https://www.linkedin.com/in/ezaldin-alzaher
