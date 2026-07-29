import re

with open('MalkiTailorShop/Measurement.Designer.cs', 'r', encoding='utf-8-sig') as f:
    content = f.read()

# Add declarations
decl = '''        internal System.Windows.Forms.Label lblStatus;
        internal System.Windows.Forms.TextBox txtStatus;
'''
content = re.sub(r'(internal System\.Windows\.Forms\.Label lblcustomerid;)', r'\1\n' + decl, content)

# Add instantiation
inst = '''            this.lblStatus = new System.Windows.Forms.Label();
            this.txtStatus = new System.Windows.Forms.TextBox();
'''
content = re.sub(r'(this\.lblcustomerid = new System\.Windows\.Forms\.Label\(\);)', r'\1\n' + inst, content)

# Add properties
props = '''
            // lblStatus
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(436, 252);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(57, 21);
            this.lblStatus.TabIndex = 100;
            this.lblStatus.Text = "Status";
            
            // txtStatus
            this.txtStatus.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStatus.Location = new System.Drawing.Point(668, 252);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ReadOnly = true;
            this.txtStatus.Size = new System.Drawing.Size(294, 27);
            this.txtStatus.TabIndex = 101;
'''
content = re.sub(r'(// lblmeasurementfield)', props + r'\n            \1', content)

# Add to controls
add_controls = '''            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.txtStatus);
'''
content = re.sub(r'(this\.Controls\.Add\(this\.lblcustomerid\);)', r'\1\n' + add_controls, content)

# Fix lblmeasurementfield location
content = re.sub(r'(this\.lblmeasurementfield\.Location = new System\.Drawing\.Point\()436, 252(\);)', r'\g<1>436, 287\g<2>', content)

with open('MalkiTailorShop/Measurement.Designer.cs', 'w', encoding='utf-8-sig') as f:
    f.write(content)

print("Measurement.Designer.cs updated")
