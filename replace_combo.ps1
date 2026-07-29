
$f = "MalkiTailorShop\OrderManagement.Designer.cs"
$c = Get-Content $f -Raw

$c = $c.Replace("this.cmborderid = new System.Windows.Forms.ComboBox();", "this.txtorderid = new System.Windows.Forms.TextBox();")

$searchBlock = @"
            // cmborderid
            // 
            this.cmborderid.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmborderid.FormattingEnabled = true;
            this.cmborderid.Location = new System.Drawing.Point(609, 88);
            this.cmborderid.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmborderid.Name = "cmborderid";
            this.cmborderid.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmborderid.Size = new System.Drawing.Size(333, 44);
            this.cmborderid.TabIndex = 92;
"@

$replaceBlock = @"
            // txtorderid
            // 
            this.txtorderid.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtorderid.Location = new System.Drawing.Point(609, 88);
            this.txtorderid.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtorderid.Name = "txtorderid";
            this.txtorderid.Size = new System.Drawing.Size(333, 41);
            this.txtorderid.TabIndex = 92;
"@

$c = $c.Replace($searchBlock, $replaceBlock)
$c = $c.Replace("this.Controls.Add(this.cmborderid);", "this.Controls.Add(this.txtorderid);")
$c = $c.Replace("internal System.Windows.Forms.ComboBox cmborderid;", "internal System.Windows.Forms.TextBox txtorderid;")

Set-Content $f $c

