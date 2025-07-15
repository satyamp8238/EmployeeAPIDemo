# 👨‍💼 EmployeeAPI - ASP.NET Core Web API

A lightweight, in-memory Web API built with ASP.NET Core for performing CRUD operations on employee records.

---

## 📌 Overview

This API allows you to:

- Create a new employee ✅  
- Read all or a specific employee ✅  
- Update an employee’s details ✅  
- Delete an employee ✅  

🔁 All data is stored **in memory**, no database required.

---

## 🚀 Technologies Used

- ASP.NET Core 7/8
- C#
- Swagger UI (for API testing)
- In-Memory List as data store

---

## 📡 API Endpoints

| Method | Endpoint               | Description           |
|--------|------------------------|-----------------------|
| GET    | `/api/employees`       | Get all employees     |
| GET    | `/api/employees/{id}`  | Get employee by ID    |
| POST   | `/api/employees`       | Add a new employee    |
| PUT    | `/api/employees/{id}`  | Update an employee    |
| DELETE | `/api/employees/{id}`  | Delete an employee    |

---

## 🧱 Employee Model

```csharp
public class Employee
{
    public int EmployeeId { get; set; }
    public string FullName { get; set; }
    public string Department { get; set; }
    public decimal Salary { get; set; }
}
