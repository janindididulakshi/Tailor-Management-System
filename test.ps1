
$conn = New-Object System.Data.SqlClient.SqlConnection("Server=(LocalDB)\MSSQLLocalDB;Database=MalkiDB;Integrated Security=True;")
$conn.Open()
$cmd = $conn.CreateCommand()
$cmd.CommandText = "SELECT COUNT(*) FROM Customers"
$count = $cmd.ExecuteScalar()
Write-Host "Count: $count"
$conn.Close()

