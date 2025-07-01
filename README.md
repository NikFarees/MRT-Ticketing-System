# 🚇 MRT Ticketing System – ASP.NET Core MVC Project

This is a **school project** built with **ASP.NET Core MVC** that simulates a ticket booking system for the MRT Sungai Buloh–Kajang (SBK) Line. The system offers separate functionalities for **users** to buy tickets and for **admins** to manage and analyze sales, send emails, and view transaction reports.

---

## 🎯 Project Purpose

The goal of this project is to simulate a real-world **ticketing platform** using ASP.NET Core MVC. It was developed as part of a university course on **Web Application Development**, demonstrating core features like routing, MVC architecture, authentication, and reporting.

---

## 👥 Roles & Access

### 🧑 User:
- View MRT SBK Line routes and stations
- Select travel destinations and buy tickets
- Receive purchase confirmations

### 👨‍💼 Admin:
- View full list of transactions
- See detailed information about each ticket sale
- Send confirmation or follow-up **emails to customers**
- Access **reports and summaries** of ticket activity

---

## ✨ Core Features

### ✅ User Features:
- Interactive ticket selection for MRT SBK Line
- Purchase ticket workflow
- Clean and responsive user interface

### 🛠️ Admin Features:
- View and manage **transaction details**
- **Send emails** directly to users (e.g., confirmations)
- View ticket sales reports:
  - Total Sales
  - Tickets Sold per Station
  - Peak Usage Times
  - Most Frequent Users

---

## 🧰 Technologies Used

- **ASP.NET Core MVC**
- **C#**
- **Entity Framework Core**
- **Razor Pages / Views**
- **Bootstrap** (UI styling)
- **LINQ**
- **SMTP / MailKit** (for sending emails)

---

## 🗂️ Project Structure

- `/Controllers` – Business logic & routing (`ProjectController1.cs`)
- `/Views` – Razor-based pages for user/admin
- `/Models` – Entity models (EF Core)
- `/wwwroot` – Static assets (CSS, JS, images)
- `appsettings.json` – SMTP & DB connection config

---

## 🔗 Page Navigation

| Role   | Page                        | URL                                                                 |
|--------|-----------------------------|----------------------------------------------------------------------|
| User   | Buy Ticket Page             | `https://localhost:7170/ProjectController1/MRTSungaiBulohKajangLine` |
| Admin  | View Reports & Transactions | `https://localhost:7170/ProjectController1/Index`                    |

---

## 📧 Email System

Admins can send emails to customers directly from the system — useful for:
- Sending purchase confirmations

---

## 📊 Reporting

Includes admin dashboards with:
- Transaction List
- Customer Report
- Ticket Report
- Most Popular Station Start and End
- Least Popular Station Start and End

---

## 🚀 Deployment

This system is **designed to run locally**:
1. Open the solution in **Visual Studio**
2. Build the project
3. Run using **IIS Express**
4. Use provided URLs to navigate as admin or user

---

## 🙋‍♂️ Author

Built by a student as a capstone for learning **ASP.NET Core MVC** and practical web app development.

---

## 📚 License

This project is for **educational use** only and not intended for commercial deployment.

