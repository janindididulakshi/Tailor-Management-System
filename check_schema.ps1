
$conn = New-Object System.Data.SqlClient.SqlConnection("Server=(LocalDB)\MSSQLLocalDB;Database=MalkiDB;Integrated Security=True;")
$conn.Open()

Write-Host "--- Employees ---"
$cmd = $conn.CreateCommand()
$cmd.CommandText = "SELECT COLUMN_NAME FROM information_schema.columns WHERE table_name = 'Employees'"
$reader = $cmd.ExecuteReader()
while ($reader.Read()) { Write-Host $reader[0] }
$reader.Close()

Write-Host "--- Orders ---"
$cmd.CommandText = "SELECT COLUMN_NAME FROM information_schema.columns WHERE table_name = 'Orders'"
$reader = $cmd.ExecuteReader()
while ($reader.Read()) { Write-Host $reader[0] }
$conn.Close()

