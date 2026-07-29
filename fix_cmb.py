import re

with open('MalkiTailorShop/Measurement.cs', 'r', encoding='utf-8-sig') as f:
    content = f.read()

# Fix LoadCustomerIDs
content = content.replace('cmbCustomerID.Items.Add(reader["CustomerID"].ToString());', 'cmbCustomerID.Items.Add(reader["CustomerID"].ToString().Trim());')

# Fix LoadOrderIDs
content = content.replace('cmbOrderID.Items.Add(reader["OrderID"].ToString());', 'cmbOrderID.Items.Add(reader["OrderID"].ToString().Trim());')

# Fix cmbCustomerID_SelectedIndexChanged order id loading
content = content.replace('cmbOrderID.Items.Add(reader["OrderID"].ToString());', 'cmbOrderID.Items.Add(reader["OrderID"].ToString().Trim());') # this might replace both if identical, which is fine

# Fix the reading of values in cmbOrderID_SelectedIndexChanged
content = content.replace('cmbCustomerID.SelectedItem = reader["CustomerID"].ToString();', 'cmbCustomerID.Text = reader["CustomerID"].ToString().Trim();')
content = content.replace('TextBox2.Text = reader["TelephoneNo"].ToString();', 'TextBox2.Text = reader["TelephoneNo"].ToString().Trim();')
content = content.replace('cmbStatus.SelectedItem = reader["Status"].ToString();', 'cmbStatus.Text = reader["Status"].ToString().Trim();')
content = content.replace('dressType = reader["DressType"].ToString();', 'dressType = reader["DressType"].ToString().Trim();')
content = content.replace('cmbDressType.SelectedItem = dressType;', 'cmbDressType.Text = dressType;')

with open('MalkiTailorShop/Measurement.cs', 'w', encoding='utf-8-sig') as f:
    f.write(content)

print("Measurement.cs combobox values fixed!")
