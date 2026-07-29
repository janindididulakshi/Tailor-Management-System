import glob
import re

files = glob.glob('MalkiTailorShop/**/*.Designer.cs', recursive=True)

for f in files:
    with open(f, 'r', encoding='utf-8-sig') as file:
        content = file.read()
    
    # Fix the double "this.this."
    content = content.replace('this.this.', 'this.')
    
    # Fix the font replacement properly
    content = re.sub(
        r'(this\.(?:btn\w+|button\d+)\.Font = new System\.Drawing\.Font\()"Microsoft Sans Serif"(, 12F, System\.Drawing\.FontStyle\.Bold)',
        r'\1"Segoe UI"\2',
        content
    )
                     
    with open(f, 'w', encoding='utf-8-sig') as file:
        file.write(content)

print("Fixed regex bug.")
