import re

with open('MalkiTailorShop/Measurement.cs', 'r', encoding='utf-8-sig') as f:
    content = f.read()

# Wire events in constructor
constructor_fix = '''        public Measurement()
        {
            InitializeComponent();
            this.Load += Measurement_Load;
            
            button1.Click += button1_Click;
            button2.Click += button2_Click;
            button3.Click += button3_Click;
            button4.Click += button4_Click;
'''
content = content.replace('''        public Measurement()
        {
            InitializeComponent();
            this.Load += Measurement_Load;''', constructor_fix)

# Update button2_Click to also update Orders
save_update_orders = '''                    SqlCommand cmdOrderUpdate = new SqlCommand("UPDATE Orders SET Status=@status, DressType=@dressType WHERE OrderID=@id", connection);
                    cmdOrderUpdate.Parameters.AddWithValue("@status", cmbStatus.Text);
                    cmdOrderUpdate.Parameters.AddWithValue("@dressType", cmbDressType.Text);
                    cmdOrderUpdate.Parameters.AddWithValue("@id", cmbOrderID.SelectedItem.ToString());
                    cmdOrderUpdate.ExecuteNonQuery();

                    SqlCommand cmd = new SqlCommand("INSERT INTO Measurements (OrderID, Bust, Waist, Chest, DressLength, Shoulder, SleeveLength, ArmRound, SkirtLength) VALUES (@id, @bust, @waist, @chest, @dresslength, @shoulder, @sleevelength, @armround, @skirtlength)", connection);'''

content = content.replace('SqlCommand cmd = new SqlCommand("INSERT INTO Measurements (OrderID, Bust, Waist, Chest, DressLength, Shoulder, SleeveLength, ArmRound, SkirtLength) VALUES (@id, @bust, @waist, @chest, @dresslength, @shoulder, @sleevelength, @armround, @skirtlength)", connection);', save_update_orders)

# Update button1_Click to also update Orders
update_orders = '''                    SqlCommand cmdOrderUpdate = new SqlCommand("UPDATE Orders SET Status=@status, DressType=@dressType WHERE OrderID=@id", connection);
                    cmdOrderUpdate.Parameters.AddWithValue("@status", cmbStatus.Text);
                    cmdOrderUpdate.Parameters.AddWithValue("@dressType", cmbDressType.Text);
                    cmdOrderUpdate.Parameters.AddWithValue("@id", cmbOrderID.SelectedItem.ToString());
                    cmdOrderUpdate.ExecuteNonQuery();

                    SqlCommand cmd = new SqlCommand("UPDATE Measurements SET Bust=@bust, Waist=@waist, Chest=@chest, DressLength=@dresslength, Shoulder=@shoulder, SleeveLength=@sleevelength, ArmRound=@armround, SkirtLength=@skirtlength WHERE OrderID=@id", connection);'''

content = content.replace('SqlCommand cmd = new SqlCommand("UPDATE Measurements SET Bust=@bust, Waist=@waist, Chest=@chest, DressLength=@dresslength, Shoulder=@shoulder, SleeveLength=@sleevelength, ArmRound=@armround, SkirtLength=@skirtlength WHERE OrderID=@id", connection);', update_orders)

with open('MalkiTailorShop/Measurement.cs', 'w', encoding='utf-8-sig') as f:
    f.write(content)

print("Buttons wired and order updating logic added!")
