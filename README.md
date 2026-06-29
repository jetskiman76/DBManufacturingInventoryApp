# GB Manufacturing Tracker - WinForms .NET 10

This is a complete C# Windows Forms application for the GB Manufacturing Equipment and Inventory Tracking System.

## Features
- Login screen with Login, Register, Clear, and Close buttons
- BCrypt password hashing
- admin login: **admin1** / **1976**
- employee login: **employee** / **1976**
- super login: **super** / **1976**
- Register new users with role selection
- Equipment and inventory add, update, delete, clear, and grid view
- Checkout and return equipment
- Mark returned equipment as damaged
- Create and save damage reports
- Export damage reports to text files
- View saved reports, damage reports, overdue equipment, and export CSV reports
- MSSQL Server database script included
- Designer files included for each form so forms open in Visual Studio Designer
- Debug profile included in `Properties/launchSettings.json`

## Requirements
- Visual Studio 2026 or Visual Studio with .NET 10 SDK support
- SQL Server LocalDB or SQL Server Express
- NuGet packages restore automatically:
  - Microsoft.Data.SqlClient
  - BCrypt.Net-Next

## Setup
1. Open SQL Server Management Studio.
2. Run `Database.sql`.
3. Open `GBManufacturingTracker.csproj` in Visual Studio.
4. Restore NuGet packages if prompted.
5. Confirm the connection string in `Db.cs` matches your SQL Server:

```csharp
Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=GBManufacturingTrackerDB;Integrated Security=True;Encrypt=False;TrustServerCertificate=True
```

6. Press F5 to run.
7. Log in with:
   - Username: `admin`
   - Password: `1976`

## Form/Class Layout
- `Program.cs` - starts the application
- `Db.cs` - SQL Server helper methods
- `PasswordHasher.cs` - password hash/verify helper
- `Session.cs` - stores current logged-in user
- `LoginForm` - login UI
- `RegisterForm` - user registration UI
- `DashboardForm` - main navigation menu
- `EquipmentForm` - equipment/inventory management
- `CheckoutForm` - checkout/return workflow
- `DamageReportForm` - damage report creation and export
- `ReportsForm` - report viewing and CSV export

## Notes
The app follows a layered layout: presentation forms call helper/business code, and all persistent records are stored in the centralized MSSQL database.
