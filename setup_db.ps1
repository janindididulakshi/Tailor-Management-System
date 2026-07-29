
$connectionString = "Server=(LocalDB)\MSSQLLocalDB;Integrated Security=True;"
$conn = New-Object System.Data.SqlClient.SqlConnection($connectionString)
$conn.Open()

$cmd = $conn.CreateCommand()
$cmd.CommandText = "IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = N'MalkiDB') CREATE DATABASE MalkiDB;"
$cmd.ExecuteNonQuery() | Out-Null

$cmd.CommandText = "USE MalkiDB;"
$cmd.ExecuteNonQuery() | Out-Null

$schema = @"
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Users]') AND type in (N'U'))
CREATE TABLE Users (
    Username NVARCHAR(50) PRIMARY KEY,
    Password NVARCHAR(50) NOT NULL
);
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Customers]') AND type in (N'U'))
CREATE TABLE Customers (
    CustomerName NVARCHAR(100),
    TelephoneNo NVARCHAR(50),
    Address NVARCHAR(200)
);
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Orders]') AND type in (N'U'))
CREATE TABLE Orders (
    OrderID INT PRIMARY KEY IDENTITY(1,1),
    CustomerID INT,
    TailorID INT,
    DressType NVARCHAR(50),
    OrderDate DATETIME,
    DueDate DATETIME,
    Price DECIMAL(18,2),
    Status NVARCHAR(50)
);
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Measurements]') AND type in (N'U'))
CREATE TABLE Measurements (
    MeasurementID INT PRIMARY KEY IDENTITY(1,1),
    OrderID INT,
    Bust DECIMAL(5,2),
    Waist DECIMAL(5,2),
    Chest DECIMAL(5,2),
    DressLength DECIMAL(5,2),
    Shoulder DECIMAL(5,2),
    SleeveLength DECIMAL(5,2),
    ArmRound DECIMAL(5,2),
    SkirtLength DECIMAL(5,2)
);
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AdvancePayments]') AND type in (N'U'))
CREATE TABLE AdvancePayments (
    PaymentID INT PRIMARY KEY IDENTITY(1,1),
    OrderID INT,
    Price DECIMAL(18,2),
    Advance DECIMAL(18,2),
    AdvancePayDate DATETIME,
    Balance DECIMAL(18,2)
);
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FinalPayments]') AND type in (N'U'))
CREATE TABLE FinalPayments (
    PaymentID INT PRIMARY KEY IDENTITY(1,1),
    OrderID INT,
    Advance DECIMAL(18,2),
    BalanceAmount DECIMAL(18,2),
    FinalPayDate DATETIME,
    Status NVARCHAR(50)
);
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Employees]') AND type in (N'U'))
CREATE TABLE Employees (
    TailorID INT PRIMARY KEY IDENTITY(1,1),
    TailorName NVARCHAR(100),
    Age INT,
    TelephoneNo NVARCHAR(50),
    Address NVARCHAR(200),
    NICNumber NVARCHAR(50),
    Status NVARCHAR(50)
);

IF NOT EXISTS (SELECT * FROM Users WHERE Username = 'admin')
INSERT INTO Users (Username, Password) VALUES ('admin', 'admin');

IF NOT EXISTS (SELECT * FROM Users WHERE Username = 'tailor')
INSERT INTO Users (Username, Password) VALUES ('tailor', 'tailor');
"@

$cmd.CommandText = $schema
$cmd.ExecuteNonQuery() | Out-Null

$conn.Close()
Write-Host "Database and tables created successfully! Added default user: admin / admin"

