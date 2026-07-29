import glob

files = glob.glob('MalkiTailorShop/**/*.Designer.cs', recursive=True)
for f in files:
    with open(f, 'r', encoding='utf-8') as file:
        content = file.read()
    
    with open(f, 'w', encoding='utf-8-sig') as file:
        file.write(content)
print("Added BOM to all Designer.cs files.")
