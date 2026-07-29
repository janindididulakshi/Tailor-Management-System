import glob
import re

files = glob.glob('MalkiTailorShop/**/*.Designer.cs', recursive=True)

emoji_map = {
    '?? Home': '?? Home',
    '?? Customer': '?? Customer',
    '?? Order': '?? Order',
    '?? Measurement': '?? Measurement',
    '?? Advance Payment': '?? Advance Payment',
    '?? Final Payment': '?? Final Payment',
    '?? Employee': '?? Employee',
    '?? Report': '?? Report'
}

for f in files:
    with open(f, 'r', encoding='utf-8-sig') as file:
        content = file.read()
    
    # Fix emojis
    for old, new in emoji_map.items():
        content = content.replace('"' + old + '"', '"' + new + '"')
        
    # Replace button heights of 37 or 30 with 45 for sidebar buttons
    # Since sidebar buttons are usually named btn... or button... and have Width around 180-240
    content = re.sub(r'(this\.(?:btn\w+|button\d+)\.Size = new System\.Drawing\.Size\(\d{3}, )3[0-9](\);)', r'\g<1>45\2', content)
    
    # Change fonts to Segoe UI, 12F, Bold to prevent vertical clipping with Microsoft Sans Serif
    content = re.sub(r'this\.(?:btn\w+|button\d+)\.Font = new System\.Drawing\.Font\("Microsoft Sans Serif", 12F, System\.Drawing\.FontStyle\.Bold',
                     r'this.\g<0>'.replace('Microsoft Sans Serif', 'Segoe UI'), content)
                     
    with open(f, 'w', encoding='utf-8-sig') as file:
        file.write(content)

print("Sidebar fonts, heights, and emojis fixed.")
