
$f1 = "MalkiTailorShop\OrderManagement.Designer.cs"
$c1 = Get-Content $f1 -Raw
$c1 = $c1.Replace("this.btnSave.UseVisualStyleBackColor = false;", "this.btnSave.UseVisualStyleBackColor = false;`r`n            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);")
Set-Content $f1 $c1

$f2 = "MalkiTailorShop\OrderManagement.cs"
$c2 = Get-Content $f2 -Raw
$c2 = $c2.Replace("private void button1_Click(object sender, EventArgs e)", "private void btnSave_Click(object sender, EventArgs e)`r`n        {`r`n            new Measurement().Show();`r`n            this.Hide();`r`n        }`r`n`r`n        private void button1_Click(object sender, EventArgs e)")
Set-Content $f2 $c2

