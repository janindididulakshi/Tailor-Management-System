# MalkiTailorShop - Agent Guide

## Project Overview

**MalkiTailorShop** is a .NET Framework 4.8 Windows Forms (WinForms) desktop application for managing a tailoring business. It connects to a local Microsoft SQL Server database (`MalkiDB`) via ADO.NET with Windows Integrated Security.

## Tech Stack

| Technology | Usage |
|------------|-------|
| C# | All application logic |
| .NET Framework 4.8 | Target framework |
| Windows Forms (WinForms) | UI framework (`System.Windows.Forms`) |
| ADO.NET (`System.Data.SqlClient`) | Direct SQL data access (no ORM) |
| Microsoft SQL Server | Backend database (local instance) |
| Visual Studio 2013+ | Solution format (v12) |

## Project Structure

```
MalkiTailorShop - Copy/
├── MalkiTailorShop.sln
├── MalkiTailorShop/
│   ├── MalkiTailorShop.csproj      # .NET 4.8 WinExe project
│   ├── App.config                   # .NET 4.8 runtime config
│   ├── Program.cs                   # Entry point → runs Login form
│   ├── DB Connection/
│   │   └── DBConnection.cs          # SqlConnection helper (hardcoded connection string)
│   ├── Login.cs/.Designer.cs        # Authentication form
│   ├── Home.cs/.Designer.cs         # Home page (stub)
│   ├── AdminDashboard.cs/.Designer.cs  # Admin nav (class: Dashboard)
│   ├── TailerDashboard.cs/.Designer.cs # Tailor nav (class: Dashboard2)
│   ├── CustomerManagement .cs/.Designer.cs  # Customer CRUD
│   ├── OrderManagement.cs/.Designer.cs  # Order management (stub)
│   ├── Measurement.cs/.Designer.cs  # Body measurements (stub)
│   ├── AdvancePayment.cs/.Designer.cs  # Advance payment (stub)
│   ├── FinalPayment.cs/.Designer.cs # Final payment (stub)
│   ├── EmployeeManagement.cs/.Designer.cs # Employee CRUD (stub)
│   └── Properties/
│       ├── AssemblyInfo.cs
│       ├── Resources.resx/.Designer.cs
│       └── Settings.settings/.Designer.cs
```

## Application Flow

```
Program.Main()
  → Login form
    → auth query: SELECT ... FROM Users WHERE Username=@user AND Password=@pass
    → if username == "admin" → Dashboard (AdminDashboard)
    → else → Dashboard2 (TailerDashboard)
    → each form hides itself and shows the target form
```

## File Naming Inconsistency

The `.csproj` references `Dashboard.cs` / `Dashboard2.cs`, but actual files are `AdminDashboard.cs` / `TailerDashboard.cs`. The class names inside are `Dashboard` and `Dashboard2` respectively.

## Inferred Database Schema

Based on SQL queries and form fields:

- **Users**: `Username`, `Password`
- **Customers**: `CustomerName`, `TelephoneNo`, `Address`
- **Orders**: `OrderID`, `CustomerID`, `TailorID`, `DressType`, `OrderDate`, `DueDate`, `Price`, `Status`
- **Measurements**: Linked to Customer/Order; fields for Frock (Bust, Waist, Chest, DressLength, Shoulder, SleeveLength, ArmRound), Saree Jacket (Bust, Waist, SleeveLength, ArmRound), Uniform (Bust, Waist, DressLength, SkirtLength, SleeveLength, ArmRound)
- **AdvancePayments**: `OrderID`, `Price`, `Advance`, `AdvancePayDate`, `Balance`
- **FinalPayments**: `OrderID`, `Advance`, `BalanceAmount`, `FinalPayDate`, `Status`
- **Employees/Tailors**: `TailorID`, `TailorName`, `Age`, `TelephoneNo`, `Address`, `NICNumber`, `Status`

## Key Conventions

- **Flat-style UI**: `FlatStyle.Flat` buttons with colors (MediumSeaGreen=Save, DodgerBlue=Update, Crimson=Delete, MediumPurple=Add)
- **Emoji button icons**: (save),  (update),  (delete),  (add),  (order),  (customer),  (measurement),  (payment),  (employee),  (report)
- **Sidebar navigation**: MediumOrchid panel (305px wide) on every form
- **Forms**: 1182×753 px, partial class pattern (`Form.cs` + `Form.Designer.cs`)
- **Data access**: Parameterized SQL via `SqlCommand.Parameters.AddWithValue()` (inline in forms)
- **Form switching**: `this.Hide(); newForm.Show();` (no user controls / tabs)

## Connection String

Hardcoded in `DB Connection\DBConnection.cs:14-17`:
```
Data Source=DESKTOP-UAU0782\SQLEXPRESS; Initial Catalog=MalkiDB; Integrated Security=True
```

## Build

Open `MalkiTailorShop.sln` in Visual Studio 2013+ (or use MSBuild). No NuGet packages required.

## Implementation Status

| Form | Logic Status |
|------|-------------|
| Login | Complete (auth + role routing) |
| AdminDashboard | Complete (nav hub) |
| TailerDashboard | Complete (nav hub, no Employee/Report) |
| CustomerManagement | Partial (Save/Add wired; Update/Delete not wired) |
| OrderManagement | Stub (no save logic) |
| Measurement | Stub |
| AdvancePayment | Stub |
| FinalPayment | Stub |
| EmployeeManagement | Stub |
| Home | Stub |

## Notes

- No test infrastructure exists
- No logging framework
- No ORM (raw ADO.NET only)
- No separation of concerns (data access in forms code-behind)
- Admin sees Employee Management + Report; Tailors do not
