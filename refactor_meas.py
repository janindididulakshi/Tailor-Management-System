import re

with open('MalkiTailorShop/Measurement.cs', 'r', encoding='utf-8-sig') as f:
    content = f.read()

# Replace TextBox1 with cmbCustomerID and txtStatus with cmbStatus
content = content.replace('TextBox1.ReadOnly = true;', '')
content = content.replace('txtStatus.Clear();', 'cmbStatus.SelectedIndex = -1;')
content = content.replace('TextBox1.Text', 'cmbCustomerID.Text')
content = content.replace('txtStatus.Text', 'cmbStatus.Text')
content = content.replace('cmbDressType.Enabled = false;', '')

# In LoadOrderIDs, maybe we don't load all order IDs by default, or maybe we do.
# Let's add LoadCustomerIDs
load_customers = '''
        private void LoadCustomerIDs()
        {
            try
            {
                using (SqlConnection connection = DBConnection.GetConnection())
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("SELECT CustomerID FROM Customers", connection);
                    SqlDataReader reader = cmd.ExecuteReader();
                    cmbCustomerID.Items.Clear();
                    while (reader.Read())
                    {
                        cmbCustomerID.Items.Add(reader["CustomerID"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        public void cmbCustomerID_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCustomerID.SelectedItem == null) return;
            string customerId = cmbCustomerID.SelectedItem.ToString();
            try
            {
                using (SqlConnection connection = DBConnection.GetConnection())
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("SELECT TelephoneNo FROM Customers WHERE CustomerID = @id", connection);
                    cmd.Parameters.AddWithValue("@id", customerId);
                    object result = cmd.ExecuteScalar();
                    if (result != null) TextBox2.Text = result.ToString();

                    // Load OrderIDs for this customer
                    SqlCommand cmdOrder = new SqlCommand("SELECT OrderID FROM Orders WHERE CustomerID = @id", connection);
                    cmdOrder.Parameters.AddWithValue("@id", customerId);
                    SqlDataReader reader = cmdOrder.ExecuteReader();
                    cmbOrderID.Items.Clear();
                    while (reader.Read())
                    {
                        cmbOrderID.Items.Add(reader["OrderID"].ToString());
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
'''
if 'private void LoadCustomerIDs()' not in content:
    content = content.replace('private void LoadOrderIDs()', load_customers + '\n        private void LoadOrderIDs()')

# Call LoadCustomerIDs in Constructor or Form_Load
content = content.replace('LoadOrderIDs();', 'LoadCustomerIDs();\n            LoadOrderIDs();')

# Update cmbOrderID_SelectedIndexChanged SQL
old_sql_1 = 'SELECT o.CustomerID, c.TelephoneNo, o.DressType FROM Orders o INNER JOIN Customers c ON o.CustomerID = c.CustomerID WHERE o.OrderID = @id'
new_sql_1 = 'SELECT o.CustomerID, c.TelephoneNo, o.Status, o.DressType FROM Orders o INNER JOIN Customers c ON o.CustomerID = c.CustomerID WHERE o.OrderID = @id'
content = content.replace(old_sql_1, new_sql_1)

old_sql_2 = 'SELECT c.CustomerID, c.TelephoneNo, o.Status, o.DressType FROM Customers c INNER JOIN Orders o ON c.CustomerID = o.CustomerID WHERE o.OrderID = @id'
content = content.replace(old_sql_2, new_sql_1)

old_read_code_1 = '''                        cmbCustomerID.Text = reader["CustomerID"].ToString();
                        TextBox2.Text = reader["TelephoneNo"].ToString();
                        dressType = reader["DressType"].ToString();
                        cmbDressType.SelectedItem = dressType;'''
new_read_code_1 = '''                        cmbCustomerID.SelectedItem = reader["CustomerID"].ToString();
                        TextBox2.Text = reader["TelephoneNo"].ToString();
                        cmbStatus.SelectedItem = reader["Status"].ToString();
                        dressType = reader["DressType"].ToString();
                        cmbDressType.SelectedItem = dressType;'''
content = content.replace(old_read_code_1, new_read_code_1)

old_read_code_2 = '''                        cmbCustomerID.Text = reader["CustomerID"].ToString();
                                TextBox2.Text = reader["TelephoneNo"].ToString();
                                cmbStatus.Text = reader["Status"].ToString();
                                cmbDressType.Text = reader["DressType"].ToString();'''
new_read_code_2 = '''                        cmbCustomerID.SelectedItem = reader["CustomerID"].ToString();
                        TextBox2.Text = reader["TelephoneNo"].ToString();
                        cmbStatus.SelectedItem = reader["Status"].ToString();
                        cmbDressType.SelectedItem = reader["DressType"].ToString();'''
content = content.replace(old_read_code_2, new_read_code_2)

# Save
with open('MalkiTailorShop/Measurement.cs', 'w', encoding='utf-8-sig') as f:
    f.write(content)

print("Measurement.cs updated!")
