
$f1 = "MalkiTailorShop\CustomerManagement .Designer.cs"
$c1 = Get-Content $f1 -Raw
$c1 = $c1.Replace("`$(button3)_Click", "button3_Click")
$c1 = $c1.Replace("`$(button1)_Click", "button1_Click")
$c1 = $c1.Replace("`$(btnreport)_Click", "btnreport_Click")
$c1 = $c1.Replace("`$(btnEmployee)_Click", "btnEmployee_Click")
$c1 = $c1.Replace("`$(Btnfinalpayment)_Click", "Btnfinalpayment_Click")
$c1 = $c1.Replace("`$(btnMeasurement)_Click", "btnMeasurement_Click")
$c1 = $c1.Replace("`$(Btnadvancedpayment)_Click", "Btnadvancedpayment_Click")
$c1 = $c1.Replace("`$(button4)_Click", "button4_Click")
$c1 = $c1.Replace("`$(btnOrder)_Click", "btnOrder_Click")
$c1 = $c1.Replace("`$(btncutomer)_Click", "btncutomer_Click")
Set-Content $f1 $c1

$f2 = "MalkiTailorShop\CustomerManagement .cs"
$c2 = Get-Content $f2 -Raw
$c2 = $c2.Replace("        private void button3_Click", "        }`r`n        private void button3_Click")
Set-Content $f2 $c2

