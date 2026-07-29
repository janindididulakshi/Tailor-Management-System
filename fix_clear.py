import re

with open('MalkiTailorShop/Measurement.cs', 'r', encoding='utf-8-sig') as f:
    content = f.read()

content = content.replace('TextBox1.Clear();', 'cmbCustomerID.SelectedIndex = -1;')

with open('MalkiTailorShop/Measurement.cs', 'w', encoding='utf-8-sig') as f:
    f.write(content)
