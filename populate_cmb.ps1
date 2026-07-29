
$f = "MalkiTailorShop\OrderManagement.Designer.cs"
$c = Get-Content $f -Raw
$c = $c.Replace("this.SuspendLayout();", "this.SuspendLayout();`r`n            this.Load += new System.EventHandler(this.OrderManagement_Load);")
Set-Content $f $c

