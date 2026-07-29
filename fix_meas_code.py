import re

with open('MalkiTailorShop/Measurement.cs', 'r', encoding='utf-8-sig') as f:
    content = f.read()

# Make TextBoxes ReadOnly in Constructor
setup_readonly = '''
            ResponsiveUIHelper.MakeResponsive(this);
            TextBox1.ReadOnly = true;
            TextBox2.ReadOnly = true;
            cmbDressType.Enabled = false; // DressType comes from Order
'''
content = content.replace('ResponsiveUIHelper.MakeResponsive(this);', setup_readonly)

# Update the SQL query in cmbOrderID_SelectedIndexChanged
old_query = 'SELECT c.CustomerID, c.TelephoneNo FROM Customers c INNER JOIN Orders o ON c.CustomerID = o.CustomerID WHERE o.OrderID = @id'
new_query = 'SELECT c.CustomerID, c.TelephoneNo, o.Status, o.DressType FROM Customers c INNER JOIN Orders o ON c.CustomerID = o.CustomerID WHERE o.OrderID = @id'
content = content.replace(old_query, new_query)

# Update the data reading part
old_read = '''                                TextBox1.Text = reader["CustomerID"].ToString();
                                TextBox2.Text = reader["TelephoneNo"].ToString();'''
new_read = '''                                TextBox1.Text = reader["CustomerID"].ToString();
                                TextBox2.Text = reader["TelephoneNo"].ToString();
                                txtStatus.Text = reader["Status"].ToString();
                                cmbDressType.Text = reader["DressType"].ToString();'''
content = content.replace(old_read, new_read)

# Update clear logic to also clear txtStatus
content = content.replace('TextBox2.Clear();', 'TextBox2.Clear();\n            txtStatus.Clear();')

with open('MalkiTailorShop/Measurement.cs', 'w', encoding='utf-8-sig') as f:
    f.write(content)

print("Measurement.cs updated")
