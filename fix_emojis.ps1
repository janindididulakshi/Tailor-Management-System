$files = Get-ChildItem -Path "MalkiTailorShop" -Filter "*.Designer.cs" -Recurse
foreach ($f in $files) {
    $content = [System.IO.File]::ReadAllText($f.FullName)
    
    # Define regex replacements for specific button texts
    $replacements = @{
        '(this\.(btn|button|Btn).*?\.Text\s*=\s*").*?(Report"\s*;)' = '${1}📊 Report";'
        '(this\.(btn|button|Btn).*?\.Text\s*=\s*").*?(Employee"\s*;)' = '${1}👥 Employee";'
        '(this\.(btn|button|Btn).*?\.Text\s*=\s*").*?(Final Payment\s*"\s*;)' = '${1}💰 Final Payment";'
        '(this\.(btn|button|Btn).*?\.Text\s*=\s*").*?(Measurement"\s*;)' = '${1}📏 Measurement";'
        '(this\.(btn|button|Btn).*?\.Text\s*=\s*").*?(Advance(d)? Payment"\s*;)' = '${1}💵 Advance Payment";'
        '(this\.(btn|button|Btn).*?\.Text\s*=\s*").*?(Order"\s*;)' = '${1}📦 Order";'
        '(this\.(btn|button|Btn).*?\.Text\s*=\s*").*?(Customer"\s*;)' = '${1}👤 Customer";'
        '(this\.(btn|button|Btn).*?\.Text\s*=\s*").*?(Home"\s*;)' = '${1}🏠 Home";'
        '(this\.(btn|button|Btn|btnsave).*?\.Text\s*=\s*").*?(Save"\s*;)' = '${1}💾 Save";'
        '(this\.(btn|button|Btn|btnupdate).*?\.Text\s*=\s*").*?(Update"\s*;)' = '${1}🔄 Update";'
        '(this\.(btn|button|Btn|btndelete).*?\.Text\s*=\s*").*?(Delete"\s*;)' = '${1}🗑️ Delete";'
        '(this\.(btn|button|Btn|btnadd).*?\.Text\s*=\s*").*?(Add"\s*;)' = '${1}➕ Add";'
    }

    $newContent = $content
    foreach ($key in $replacements.Keys) {
        $newContent = [System.Text.RegularExpressions.Regex]::Replace($newContent, $key, $replacements[$key])
    }
    
    if ($content -ne $newContent) {
        [System.IO.File]::WriteAllText($f.FullName, $newContent, [System.Text.Encoding]::UTF8)
        Write-Host "Fixed emojis in $($f.Name)"
    }
}
Write-Host "Done fixing emojis."
