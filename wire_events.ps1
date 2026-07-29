
$file = "MalkiTailorShop\CustomerManagement .Designer.cs"
$content = Get-Content $file -Raw

$buttons = @("button3", "button1", "btnreport", "btnEmployee", "Btnfinalpayment", "btnMeasurement", "Btnadvancedpayment", "button4", "btnOrder", "btncutomer")

foreach ($btn in $buttons) {
    $search = "this.$btn.UseVisualStyleBackColor = true;"
    $replace = "this.$btn.UseVisualStyleBackColor = true;`r`n            this.$btn.Click += new System.EventHandler(this.`$($btn)_Click);"
    $content = $content.Replace($search, $replace)
}

Set-Content $file $content
Write-Host "Designer updated."

