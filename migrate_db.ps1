
$connectionString = "Server=(LocalDB)\MSSQLLocalDB;Database=MalkiDB;Integrated Security=True;"
$conn = New-Object System.Data.SqlClient.SqlConnection($connectionString)
$conn.Open()

$cmd = $conn.CreateCommand()
$cmd.CommandText = "
BEGIN TRANSACTION;
CREATE TABLE Customers_New (
    CustomerID INT PRIMARY KEY,
    CustomerName NVARCHAR(100),
    TelephoneNo NVARCHAR(50),
    Address NVARCHAR(200)
);
INSERT INTO Customers_New (CustomerID, CustomerName, TelephoneNo, Address)
SELECT CustomerID, CustomerName, TelephoneNo, Address FROM Customers;
DROP TABLE Customers;
EXEC sp_rename 'Customers_New', 'Customers';
COMMIT TRANSACTION;
"
$cmd.ExecuteNonQuery() | Out-Null
$conn.Close()
Write-Host "Database migrated."

