
$file = "MalkiTailorShop\CustomerManagement .cs"
$content = Get-Content $file -Raw

$methods = @"

        private void button3_Click(object sender, EventArgs e) { new Login().Show(); this.Hide(); }
        private void button1_Click(object sender, EventArgs e) { new Login().Show(); this.Hide(); }
        private void btnreport_Click(object sender, EventArgs e) { MessageBox.Show("Report module is under construction."); }
        private void btnEmployee_Click(object sender, EventArgs e) { new EmployeeManagement().Show(); this.Hide(); }
        private void Btnfinalpayment_Click(object sender, EventArgs e) { new FinalPayment().Show(); this.Hide(); }
        private void btnMeasurement_Click(object sender, EventArgs e) { new Measurement().Show(); this.Hide(); }
        private void Btnadvancedpayment_Click(object sender, EventArgs e) { new AdvancePayment().Show(); this.Hide(); }
        private void button4_Click(object sender, EventArgs e) { new Home().Show(); this.Hide(); }
        private void btnOrder_Click(object sender, EventArgs e) { new OrderManagement().Show(); this.Hide(); }
        private void btncutomer_Click(object sender, EventArgs e) { /* Already here */ }
"@

$search = "        }`r`n        }`r`n        }"
$replace = "        }$methods`r`n        }`r`n        }"

$content = $content.Replace($search, $replace)

Set-Content $file $content
Write-Host "Methods added."

