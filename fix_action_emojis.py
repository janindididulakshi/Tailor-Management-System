import glob

files = glob.glob('MalkiTailorShop/**/*.Designer.cs', recursive=True)
for f in files:
    with open(f, 'r', encoding='utf-8-sig') as file:
        content = file.read()
    
    # Fix broken Save buttons
    content = content.replace('"ðŸ’¾ Save & Next"', '"💾 Save & Next"')
    content = content.replace('" Next"', '"💾 Next"')
    
    if 'AdvancePayment' in f:
        content = content.replace('"Next"', '"💾 Next"')

    with open(f, 'w', encoding='utf-8-sig') as file:
        file.write(content)

print("Fixed broken Action button emojis.")
