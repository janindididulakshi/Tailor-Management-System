import re

with open('MalkiTailorShop/Measurement.Designer.cs', 'r', encoding='utf-8-sig') as f:
    content = f.read()

# Change TextBox1 to cmbCustomerID
content = content.replace('internal System.Windows.Forms.TextBox TextBox1;', 'internal System.Windows.Forms.ComboBox cmbCustomerID;')
content = content.replace('this.TextBox1 = new System.Windows.Forms.TextBox();', 'this.cmbCustomerID = new System.Windows.Forms.ComboBox();')

# Update TextBox1 properties to cmbCustomerID
cmb_cid_props = '''
            // cmbCustomerID
            this.cmbCustomerID.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCustomerID.Location = new System.Drawing.Point(668, 76);
            this.cmbCustomerID.Name = "cmbCustomerID";
            this.cmbCustomerID.Size = new System.Drawing.Size(294, 28);
            this.cmbCustomerID.TabIndex = 93;
            this.cmbCustomerID.SelectedIndexChanged += new System.EventHandler(this.cmbCustomerID_SelectedIndexChanged);
'''
# We need to replace the block for TextBox1. 
# Finding the block can be tricky with simple replace, let's use regex
content = re.sub(r'// TextBox1.*?this\.TextBox1\.TabIndex = \d+;', cmb_cid_props.strip(), content, flags=re.DOTALL)
content = content.replace('this.Controls.Add(this.TextBox1);', 'this.Controls.Add(this.cmbCustomerID);')


# Change txtStatus to cmbStatus
content = content.replace('internal System.Windows.Forms.TextBox txtStatus;', 'internal System.Windows.Forms.ComboBox cmbStatus;')
content = content.replace('this.txtStatus = new System.Windows.Forms.TextBox();', 'this.cmbStatus = new System.Windows.Forms.ComboBox();')

cmb_status_props = '''
            // cmbStatus
            this.cmbStatus.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbStatus.Location = new System.Drawing.Point(668, 252);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(294, 28);
            this.cmbStatus.TabIndex = 101;
            this.cmbStatus.Items.AddRange(new object[] { "Pending", "In Progress", "Completed" });
'''
content = re.sub(r'// txtStatus.*?this\.txtStatus\.TabIndex = \d+;', cmb_status_props.strip(), content, flags=re.DOTALL)
content = content.replace('this.Controls.Add(this.txtStatus);', 'this.Controls.Add(this.cmbStatus);')


with open('MalkiTailorShop/Measurement.Designer.cs', 'w', encoding='utf-8-sig') as f:
    f.write(content)

print("Measurement.Designer.cs updated")
