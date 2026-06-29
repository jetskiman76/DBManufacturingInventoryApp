# GB Manufacturing Equipment and Inventory Tracking System

This is a complete C# Windows Forms application targeting **.NET 10 Windows** with **MSSQL Server / LocalDB** connectivity.

## Login
- Username: `admin`     - Password: `1976`

- Username: `super`     - Password: `1976`

- Username: `employee`  - Password: `1976`

## Features
- Login screen with Login, Register, Clear, Close buttons
- Password hashing using SHA-256
- Register new users
- Dashboard navigation
- Equipment checkout and return
- Inventory search and quantity update
- Damage report creation and saving
- Saved reports with CSV export
- MSSQL database setup script
- Designer files for every form so Visual Studio can open the Windows Forms Designer
- Debug profile in `Properties/launchSettings.json`

## Setup Steps
1. Open SQL Server Management Studio or Visual Studio SQL Server Object Explorer.
2. Run `CreateDatabase.sql`.
3. Open `GBManufacturingTracker.csproj` in Visual Studio 2026 or newer.
4. Restore NuGet packages.
5. Build the project.
6. Press F5 to run.

## Connection String
The connection string is in `AppConfig.cs`:

```csharp
Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=GBManufacturingTrackerDB;Integrated Security=True;Encrypt=False;TrustServerCertificate=True
```

Change it if you are using a full SQL Server instance.

## Class Layout
- `Program.cs` starts the WinForms app.
- `AppConfig.cs` stores the database connection string.
- `Db.cs` handles database commands, scalar values, and DataTables.
- `PasswordHasher.cs` hashes and verifies passwords.
- `LoginForm.cs` / `.Designer.cs` handles login.
- `RegisterForm.cs` / `.Designer.cs` creates users.
- `DashboardForm.cs` / `.Designer.cs` opens system modules.
- `EquipmentForm.cs` / `.Designer.cs` checks equipment out and returns it.
- `InventoryForm.cs` / `.Designer.cs` searches and updates inventory.
- `DamageReportForm.cs` / `.Designer.cs` saves damaged equipment reports.
- `ReportsForm.cs` / `.Designer.cs` displays and exports reports.

## Notes
This application follows the project requirements for the GB Manufacturing Equipment and Inventory Tracking System: authentication, equipment tracking, inventory search, damage reporting, and management reports.
