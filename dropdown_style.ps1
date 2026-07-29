
$f = "MalkiTailorShop\OrderManagement.Designer.cs"
$c = Get-Content $f -Raw

$c = $c.Replace("this.cmbstatus.Name = `"cmbstatus`";", "this.cmbstatus.Name = `"cmbstatus`";`r`n            this.cmbstatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;")
$c = $c.Replace("this.cmbdresstype.Name = `"cmbdresstype`";", "this.cmbdresstype.Name = `"cmbdresstype`";`r`n            this.cmbdresstype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;")
$c = $c.Replace("this.cmbtailorid.Name = `"cmbtailorid`";", "this.cmbtailorid.Name = `"cmbtailorid`";`r`n            this.cmbtailorid.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;")
$c = $c.Replace("this.cmbcustomerid.Name = `"cmbcustomerid`";", "this.cmbcustomerid.Name = `"cmbcustomerid`";`r`n            this.cmbcustomerid.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;")
$c = $c.Replace("this.cmborderid.Name = `"cmborderid`";", "this.cmborderid.Name = `"cmborderid`";`r`n            this.cmborderid.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;")

Set-Content $f $c

