import re

with open('MalkiTailorShop/Measurement.cs', 'r', encoding='utf-8-sig') as f:
    content = f.read()

constructor_fix = '''        public Measurement()
        {
            InitializeComponent();
            this.Load += Measurement_Load;
'''
content = content.replace('''        public Measurement()
        {
            InitializeComponent();''', constructor_fix)

with open('MalkiTailorShop/Measurement.cs', 'w', encoding='utf-8-sig') as f:
    f.write(content)
