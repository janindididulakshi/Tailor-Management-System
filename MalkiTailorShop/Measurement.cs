using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using MalkiTailorShop.DB_Connection;

namespace MalkiTailorShop
{
    public partial class Measurement : Form
    {
        public Measurement()
        {
            InitializeComponent();
            this.Load += Measurement_Load;
            
            button1.Click += button1_Click;
            button2.Click += button2_Click;
            button3.Click += button3_Click;
            button4.Click += button4_Click;


            
            ResponsiveUIHelper.MakeResponsive(this);
            
            TextBox2.ReadOnly = true;
             // DressType comes from Order

            if (Program.UserRole == "Tailor") { if (this.Controls.Find("btnEmployee", true).Length > 0) this.Controls.Find("btnEmployee", true)[0].Visible = false; if (this.Controls.Find("btnreport", true).Length > 0) this.Controls.Find("btnreport", true)[0].Visible = false; if (this.Controls.Find("btnReport", true).Length > 0) this.Controls.Find("btnReport", true)[0].Visible = false; }
            // btnreport.Click += (s, e) => { new Report().Show(); this.Hide(); };
            // btnEmployee.Click += (s, e) => { new EmployeeManagement().Show(); this.Hide(); };
            // Btnfinalpayment.Click += (s, e) => { new FinalPayment().Show(); this.Hide(); };
            // btnMeasurement.Click += (s, e) => { new Measurement().Show(); this.Hide(); };
            // Btnadvancedpayment.Click += (s, e) => { new AdvancePayment().Show(); this.Hide(); };
            // btnOrder.Click += (s, e) => { new OrderManagement().Show(); this.Hide(); };
            // btncutomer.Click += (s, e) => { new CustomerManagement().Show(); this.Hide(); };
            button7.Click += (s, e) => { if (Program.UserRole == "Tailor") { new TailerDashboard().Show(); } else { new AdminDashboard().Show(); } this.Hide(); };
            // button5.Click += (s, e) => { new Login().Show(); this.Hide(); };
            // button6.Click += (s, e) => { new Login().Show(); this.Hide(); };
        }

        private void Measurement_Load(object sender, EventArgs e)
        {
            EnsureTableExists();
            LoadCustomerIDs();
            LoadOrderIDs();
            SetButtonStates(recordSelected: false);
        }

        private void EnsureTableExists()
        {
            try
            {
                using (SqlConnection conn = DBConnection.GetConnection())
                {
                    conn.Open();
                    string sql = @"
                        IF NOT EXISTS (
                            SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Measurements'
                        )
                        CREATE TABLE Measurements (
                            MeasurementID INT PRIMARY KEY IDENTITY(1,1),
                            OrderID       INT UNIQUE,
                            Bust          NVARCHAR(20),
                            Waist         NVARCHAR(20),
                            Chest         NVARCHAR(20),
                            DressLength   NVARCHAR(20),
                            Shoulder      NVARCHAR(20),
                            SleeveLength  NVARCHAR(20),
                            ArmRound      NVARCHAR(20),
                            SkirtLength   NVARCHAR(20)
                        )";
                    new SqlCommand(sql, conn).ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("DB Setup Error: " + ex.Message);
            }
        }

        private void SetButtonStates(bool recordSelected)
        {
            button2.Enabled = !recordSelected;  // Save: new record only
            button1.Enabled = recordSelected;   // Update: existing
            button3.Enabled = recordSelected;   // Delete: existing
        }

        
        private void LoadCustomerIDs()
        {
            try
            {
                using (SqlConnection connection = DBConnection.GetConnection())
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("SELECT CustomerID FROM Customers", connection);
                    SqlDataReader reader = cmd.ExecuteReader();
                    cmbCustomerID.Items.Clear();
                    while (reader.Read())
                    {
                        cmbCustomerID.Items.Add(reader["CustomerID"].ToString().Trim());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        public void cmbCustomerID_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCustomerID.SelectedItem == null) return;
            string customerId = cmbCustomerID.SelectedItem.ToString();
            try
            {
                using (SqlConnection connection = DBConnection.GetConnection())
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("SELECT TelephoneNo FROM Customers WHERE CustomerID = @id", connection);
                    cmd.Parameters.AddWithValue("@id", customerId);
                    object result = cmd.ExecuteScalar();
                    if (result != null) TextBox2.Text = result.ToString();

                    // Load OrderIDs for this customer
                    SqlCommand cmdOrder = new SqlCommand("SELECT OrderID FROM Orders WHERE CustomerID = @id", connection);
                    cmdOrder.Parameters.AddWithValue("@id", customerId);
                    SqlDataReader reader = cmdOrder.ExecuteReader();
                    cmbOrderID.Items.Clear();
                    while (reader.Read())
                    {
                        cmbOrderID.Items.Add(reader["OrderID"].ToString().Trim());
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoadOrderIDs()
        {
            try
            {
                using (SqlConnection connection = DBConnection.GetConnection())
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("SELECT OrderID FROM Orders", connection);
                    SqlDataReader reader = cmd.ExecuteReader();
                    cmbOrderID.Items.Clear();
                    while (reader.Read())
                    {
                        cmbOrderID.Items.Add(reader["OrderID"].ToString().Trim());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmbOrderID_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearMeasurementFields();
            if (cmbOrderID.SelectedItem == null) return;
            string orderId = cmbOrderID.SelectedItem.ToString();
            
            try
            {
                using (SqlConnection connection = DBConnection.GetConnection())
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("SELECT o.CustomerID, c.TelephoneNo, o.Status, o.DressType FROM Orders o INNER JOIN Customers c ON o.CustomerID = c.CustomerID WHERE o.OrderID = @id", connection);
                    cmd.Parameters.AddWithValue("@id", orderId);
                    SqlDataReader reader = cmd.ExecuteReader();
                    string dressType = "";
                    if (reader.Read())
                    {
                        cmbCustomerID.Text = reader["CustomerID"].ToString().Trim();
                        TextBox2.Text = reader["TelephoneNo"].ToString().Trim();
                        cmbStatus.Text = reader["Status"].ToString().Trim();
                        dressType = reader["DressType"].ToString().Trim();
                        cmbDressType.Text = dressType;
                    }
                    reader.Close();

                    SqlCommand cmdMeas = new SqlCommand("SELECT * FROM Measurements WHERE OrderID = @id", connection);
                    cmdMeas.Parameters.AddWithValue("@id", orderId);
                    SqlDataReader readerMeas = cmdMeas.ExecuteReader();
                    bool exists = readerMeas.Read();
                    if (exists)
                    {
                        if (dressType == "Frock")
                        {
                            textBox12.Text = readerMeas["Bust"].ToString();
                            textBox13.Text = readerMeas["Waist"].ToString();
                            textBox14.Text = readerMeas["Chest"].ToString();
                            textBox15.Text = readerMeas["DressLength"].ToString();
                            textBox16.Text = readerMeas["Shoulder"].ToString();
                            textBox17.Text = readerMeas["SleeveLength"].ToString();
                            textBox18.Text = readerMeas["ArmRound"].ToString();
                        }
                        else if (dressType == "Saree Jacket")
                        {
                            textBox5.Text = readerMeas["Bust"].ToString();
                            textBox6.Text = readerMeas["Waist"].ToString();
                            textBox7.Text = readerMeas["SleeveLength"].ToString();
                            textBox8.Text = readerMeas["ArmRound"].ToString();
                        }
                        else if (dressType == "Uniform")
                        {
                            textBox19.Text = readerMeas["Bust"].ToString();
                            textBox20.Text = readerMeas["Waist"].ToString();
                            textBox21.Text = readerMeas["DressLength"].ToString();
                            textBox22.Text = readerMeas["SkirtLength"].ToString();
                            textBox23.Text = readerMeas["SleeveLength"].ToString();
                            textBox24.Text = readerMeas["ArmRound"].ToString();
                        }
                        SetButtonStates(recordSelected: true);
                    }
                    else
                    {
                        SetButtonStates(recordSelected: false);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading details: " + ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e) 
        {
            cmbOrderID.SelectedIndex = -1;
            cmbCustomerID.SelectedIndex = -1;
            TextBox2.Clear();
            cmbStatus.SelectedIndex = -1;
            cmbDressType.SelectedIndex = -1;
            ClearMeasurementFields();
            button2.Enabled = true;
            button1.Enabled = false;
            button3.Enabled = false;
        }

        private void ClearMeasurementFields()
        {
            textBox12.Clear(); textBox13.Clear(); textBox14.Clear(); textBox15.Clear();
            textBox16.Clear(); textBox17.Clear(); textBox18.Clear();
            textBox5.Clear(); textBox6.Clear(); textBox7.Clear(); textBox8.Clear();
            textBox19.Clear(); textBox20.Clear(); textBox21.Clear(); textBox22.Clear();
            textBox23.Clear(); textBox24.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (cmbOrderID.SelectedItem == null) { MessageBox.Show("Select an Order ID"); return; }
            string dressType = cmbDressType.Text;
            try
            {
                using (SqlConnection connection = DBConnection.GetConnection())
                {
                    connection.Open();
                                        SqlCommand cmdOrderUpdate = new SqlCommand("UPDATE Orders SET Status=@status, DressType=@dressType WHERE OrderID=@id", connection);
                    cmdOrderUpdate.Parameters.AddWithValue("@status", cmbStatus.Text);
                    cmdOrderUpdate.Parameters.AddWithValue("@dressType", cmbDressType.Text);
                    cmdOrderUpdate.Parameters.AddWithValue("@id", cmbOrderID.SelectedItem.ToString());
                    cmdOrderUpdate.ExecuteNonQuery();

                    SqlCommand cmd = new SqlCommand("INSERT INTO Measurements (OrderID, Bust, Waist, Chest, DressLength, Shoulder, SleeveLength, ArmRound, SkirtLength) VALUES (@id, @bust, @waist, @chest, @dresslength, @shoulder, @sleevelength, @armround, @skirtlength)", connection);
                    SetMeasurementParameters(cmd, dressType);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Measurement saved successfully! Opening Advance Payment...");
                    SetButtonStates(recordSelected: true);
                    
                    // Redirect to Advance Payment
                    var advPay = new AdvancePayment();
                    advPay.Show();
                    this.Hide();
                    try { advPay.cmborderid.SelectedItem = cmbOrderID.SelectedItem; } catch { }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving: " + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cmbOrderID.SelectedItem == null) return;
            string dressType = cmbDressType.Text;
            try
            {
                using (SqlConnection connection = DBConnection.GetConnection())
                {
                    connection.Open();
                                        SqlCommand cmdOrderUpdate = new SqlCommand("UPDATE Orders SET Status=@status, DressType=@dressType WHERE OrderID=@id", connection);
                    cmdOrderUpdate.Parameters.AddWithValue("@status", cmbStatus.Text);
                    cmdOrderUpdate.Parameters.AddWithValue("@dressType", cmbDressType.Text);
                    cmdOrderUpdate.Parameters.AddWithValue("@id", cmbOrderID.SelectedItem.ToString());
                    cmdOrderUpdate.ExecuteNonQuery();

                    SqlCommand cmd = new SqlCommand("UPDATE Measurements SET Bust=@bust, Waist=@waist, Chest=@chest, DressLength=@dresslength, Shoulder=@shoulder, SleeveLength=@sleevelength, ArmRound=@armround, SkirtLength=@skirtlength WHERE OrderID=@id", connection);
                    SetMeasurementParameters(cmd, dressType);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Measurement updated successfully!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating: " + ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (cmbOrderID.SelectedItem == null) return;
            if (MessageBox.Show("Are you sure you want to delete this measurement?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection connection = DBConnection.GetConnection())
                    {
                        connection.Open();
                        SqlCommand cmd = new SqlCommand("DELETE FROM Measurements WHERE OrderID=@id", connection);
                        cmd.Parameters.AddWithValue("@id", cmbOrderID.SelectedItem.ToString());
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Measurement deleted!");
                        button4_Click(null, null);
                        SetButtonStates(recordSelected: false);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting: " + ex.Message);
                }
            }
        }

        private void SetMeasurementParameters(SqlCommand cmd, string dressType)
        {
            cmd.Parameters.AddWithValue("@id", cmbOrderID.SelectedItem.ToString());
            
            string bust = "", waist = "", chest = "", dressLength = "", shoulder = "", sleeveLength = "", armRound = "", skirtLength = "";

            if (dressType == "Frock")
            {
                bust = textBox12.Text; waist = textBox13.Text; chest = textBox14.Text;
                dressLength = textBox15.Text; shoulder = textBox16.Text;
                sleeveLength = textBox17.Text; armRound = textBox18.Text;
            }
            else if (dressType == "Saree Jacket")
            {
                bust = textBox5.Text; waist = textBox6.Text;
                sleeveLength = textBox7.Text; armRound = textBox8.Text;
            }
            else if (dressType == "Uniform")
            {
                bust = textBox19.Text; waist = textBox20.Text;
                dressLength = textBox21.Text; skirtLength = textBox22.Text;
                sleeveLength = textBox23.Text; armRound = textBox24.Text;
            }

            // Convert text to decimal for numeric DB columns; empty = DBNull
            cmd.Parameters.AddWithValue("@bust",        ToNum(bust));
            cmd.Parameters.AddWithValue("@waist",       ToNum(waist));
            cmd.Parameters.AddWithValue("@chest",       ToNum(chest));
            cmd.Parameters.AddWithValue("@dresslength", ToNum(dressLength));
            cmd.Parameters.AddWithValue("@shoulder",    ToNum(shoulder));
            cmd.Parameters.AddWithValue("@sleevelength",ToNum(sleeveLength));
            cmd.Parameters.AddWithValue("@armround",    ToNum(armRound));
            cmd.Parameters.AddWithValue("@skirtlength", ToNum(skirtLength));
        }

        /// <summary>Converts a measurement string to decimal, or DBNull if empty.</summary>
        private static object ToNum(string s)
        {
            if (string.IsNullOrWhiteSpace(s)) return DBNull.Value;
            if (decimal.TryParse(s.Trim(), out decimal d)) return d;
            return DBNull.Value;  // ignore non-numeric input gracefully
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }
    }
}





