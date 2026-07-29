import os
import re
import glob

replacements = [
    (r'(this\.(?:btn|button|Btn)\w+\.Text\s*=\s*").*?(Report"\s*;)', r'\1📊 Report";'),
    (r'(this\.(?:btn|button|Btn)\w+\.Text\s*=\s*").*?(Employee"\s*;)', r'\1👥 Employee";'),
    (r'(this\.(?:btn|button|Btn)\w+\.Text\s*=\s*").*?(Final Payment\s*"\s*;)', r'\1💰 Final Payment";'),
    (r'(this\.(?:btn|button|Btn)\w+\.Text\s*=\s*").*?(Measurement"\s*;)', r'\1📏 Measurement";'),
    (r'(this\.(?:btn|button|Btn)\w+\.Text\s*=\s*").*?(Advance[d]? Payment"\s*;)', r'\1💵 Advance Payment";'),
    (r'(this\.(?:btn|button|Btn)\w+\.Text\s*=\s*").*?(Order"\s*;)', r'\1📦 Order";'),
    (r'(this\.(?:btn|button|Btn)\w+\.Text\s*=\s*").*?(Customer"\s*;)', r'\1👤 Customer";'),
    (r'(this\.(?:btn|button|Btn)\w+\.Text\s*=\s*").*?(Home"\s*;)', r'\1🏠 Home";'),
    (r'(this\.(?:btn|button|Btn)\w+\.Text\s*=\s*").*?(Save"\s*;)', r'\1💾 Save";'),
    (r'(this\.(?:btn|button|Btn)\w+\.Text\s*=\s*").*?(Update"\s*;)', r'\1🔄 Update";'),
    (r'(this\.(?:btn|button|Btn)\w+\.Text\s*=\s*").*?(Delete"\s*;)', r'\1🗑️ Delete";'),
    (r'(this\.(?:btn|button|Btn)\w+\.Text\s*=\s*").*?(Add"\s*;)', r'\1➕ Add";'),
]

files = glob.glob('MalkiTailorShop/**/*.Designer.cs', recursive=True)
for f in files:
    with open(f, 'r', encoding='utf-8') as file:
        content = file.read()
    
    new_content = content
    for pattern, repl in replacements:
        new_content = re.sub(pattern, repl, new_content)
        
    if new_content != content:
        with open(f, 'w', encoding='utf-8') as file:
            file.write(new_content)
        print(f"Fixed {f}")
print("Done!")
