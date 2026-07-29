
$connectionString = "Server=(LocalDB)\MSSQLLocalDB;Database=MalkiDB;Integrated Security=True;"
$conn = New-Object System.Data.SqlClient.SqlConnection($connectionString)
$conn.Open()

$cmd = $conn.CreateCommand()
$cmd.CommandText = "
IF NOT EXISTS (SELECT * FROM sys.columns WHERE Name = N'CustomerID' AND Object_ID = Object_ID(N'Customers'))
BEGIN
    ALTER TABLE Customers ADD CustomerID INT IDENTITY(1,1) PRIMARY KEY;
END
"
$cmd.ExecuteNonQuery() | Out-Null
$conn.Close()
Write-Host "Database updated."

