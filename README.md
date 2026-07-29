# 🧵 MalkiTailorShop

A desktop management system for tailoring businesses, built with **C# / .NET Framework 4.8** and **Windows Forms**. It handles the full workflow of a tailor shop — from customer registration and order tracking to body measurements, payments, and reporting.

---

## ✨ Features

- **Role-based login** — separate dashboards for Admin and Tailor roles
- **Customer Management** — add, update, delete and search customers
- **Order Management** — create and track dress orders with due dates and status
- **Body Measurements** — record per-customer measurements for Frocks, Saree Jackets, and Uniforms
- **Advance Payments** — track initial deposits and outstanding balances
- **Final Payments** — record completion payments and mark orders settled
- **Employee Management** — manage tailor staff records (Admin only)
- **Reports & CSV Export** — filter orders by date range and export to CSV (Admin only)
- **Analytics Dashboard** — live counts of customers, active orders, tailors, and revenue on the Home screen
- **Responsive UI** — flat-style sidebar navigation, consistent color-coded action buttons

---

## 🖥️ Tech Stack

| Layer | Technology |
|---|---|
| Language | C# |
| Framework | .NET Framework 4.8 |
| UI | Windows Forms (WinForms) |
| Data Access | ADO.NET (`System.Data.SqlClient`) — no ORM |
| Database | Microsoft SQL Server / SQL Server LocalDB |
| IDE | Visual Studio 2013 or later |

---

## 📁 Project Structure

```
MalkiTailorShop/
├── MalkiTailorShop.sln
├── MalkiTailorShop/
│   ├── Program.cs                    # Entry point → Login form
│   ├── App.config                    # .NET 4.8 runtime config
│   ├── DB Connection/
│   │   └── DBConnection.cs           # SqlConnection helper
│   ├── Login.cs                      # Auth + role-based routing
│   ├── Home.cs                       # Analytics dashboard (Admin)
│   ├── AdminDashboard.cs             # Admin navigation hub
│   ├── TailerDashboard.cs            # Tailor navigation hub
│   ├── CustomerManagement.cs         # Customer CRUD
│   ├── OrderManagement.cs            # Order management
│   ├── Measurement.cs                # Body measurements
│   ├── AdvancePayment.cs             # Advance payment tracking
│   ├── FinalPayment.cs               # Final payment + settlement
│   ├── EmployeeManagement.cs         # Employee / tailor records
│   ├── Report.cs                     # Reporting + CSV export
│   ├── ResponsiveUIHelper.cs         # Responsive layout utility
│   └── Properties/
│       ├── AssemblyInfo.cs
│       ├── Resources.resx
│       └── Settings.settings
└── setup_db.ps1                      # One-time DB setup script
```

---

## 🚀 Getting Started

### Prerequisites

- Windows OS
- [Visual Studio 2013 or later](https://visualstudio.microsoft.com/) (Community edition is free)
- .NET Framework 4.8 (usually pre-installed on Windows 10/11)
- SQL Server LocalDB — included with Visual Studio by default

### 1. Clone the repository

```bash
git clone https://github.com/your-username/MalkiTailorShop.git
cd MalkiTailorShop
```

### 2. Set up the database

Open **PowerShell as Administrator** and run:

```powershell
.\setup_db.ps1
```

This creates the `MalkiDB` LocalDB database with all required tables and inserts two default accounts:

| Username | Password | Role |
|---|---|---|
| `admin` | `admin` | Admin |
| `tailor` | `tailor` | Tailor |

> **Tip:** Change these passwords immediately after first login in a production environment.

### 3. Open and build

1. Open `MalkiTailorShop.sln` in Visual Studio.
2. Build the solution: **Build → Build Solution** (or `Ctrl+Shift+B`).
3. Press **F5** to run.

No NuGet packages are required — all dependencies ship with the .NET Framework.

---

## 🗄️ Database Schema

```
Users           (Username PK, Password)
Customers       (CustomerID PK, CustomerName, TelephoneNo, Address)
Orders          (OrderID PK, CustomerID FK, TailorID FK, DressType,
                 OrderDate, DueDate, Price, Status)
Measurements    (MeasurementID PK, OrderID FK, Bust, Waist, Chest,
                 DressLength, Shoulder, SleeveLength, ArmRound, SkirtLength)
AdvancePayments (PaymentID PK, OrderID FK, Price, Advance,
                 AdvancePayDate, Balance)
FinalPayments   (PaymentID PK, OrderID FK, Advance, BalanceAmount,
                 FinalPayDate, Status)
Employees       (TailorID PK, TailorName, Age, TelephoneNo,
                 Address, NICNumber, Status)
```

---

## 👤 User Roles

| Feature | Admin | Tailor |
|---|:---:|:---:|
| Customer Management | ✅ | ✅ |
| Order Management | ✅ | ✅ |
| Measurements | ✅ | ✅ |
| Advance Payments | ✅ | ✅ |
| Final Payments | ✅ | ✅ |
| Employee Management | ✅ | ❌ |
| Reports & CSV Export | ✅ | ❌ |
| Analytics Dashboard | ✅ | ❌ |

---

## 🔧 Configuration

The database connection string is defined in `DB Connection/DBConnection.cs`:

```csharp
new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;
                    Initial Catalog=MalkiDB;
                    Integrated Security=True");
```

To connect to a different SQL Server instance, update `Data Source` accordingly.

---

## 🛣️ Roadmap

- [ ] Password hashing (currently stored as plain text)
- [ ] Complete Update / Delete wiring in all forms
- [ ] ORM integration (Entity Framework)
- [ ] Proper logging framework
- [ ] Unit test coverage
- [ ] PDF export for reports
- [ ] Installer / setup wizard

---

## 📄 License

This project is open source. Feel free to fork and adapt it for your own tailoring business management needs.

---

## 🙏 Acknowledgements

Built with Visual Studio and a lot of 