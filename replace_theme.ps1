$files = Get-ChildItem -Path "MalkiTailorShop" -Filter "*.Designer.cs" -Recurse
foreach ($f in $files) {
    $content = Get-Content $f.FullName -Raw
    $newContent = $content -replace "System\.Drawing\.Color\.MediumOrchid", "System.Drawing.Color.White" -replace "ForeColor = System\.Drawing\.Color\.White", "ForeColor = System.Drawing.Color.Black"
    if ($content -ne $newContent) {
        Set-Content $f.FullName $newContent
    }
}
Write-Host "Replaced colors in Designer files."
