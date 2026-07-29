import glob
import re

files = glob.glob('MalkiTailorShop/**/*.Designer.cs', recursive=True)

for f in files:
    with open(f, 'r', encoding='utf-8-sig') as file:
        content = file.read()
    
    # Change "Century Gothic" to "Segoe UI" for labels
    content = content.replace('"Century Gothic"', '"Segoe UI"')
                     
    with open(f, 'w', encoding='utf-8-sig') as file:
        file.write(content)

print("Fixed label font.")
