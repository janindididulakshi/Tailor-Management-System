using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using MalkiTailorShop.DB_Connection;

namespace MalkiTailorShop
{
    public partial class AdvancePayment : Form
    {
        private bool isUpdating = false;

        public AdvancePayment()
        {
            InitializeComponent();
            ResponsiveUIHelper.MakeResponsive(this);
            if (Program.UserRole == "Tailor") { if (this.Controls.Find("btnEmployee", true).Length > 0) this.Controls.Find("btnEmployee", true)[0].Visible = false; if (this.Controls.Find("btnreport", true).Length > 0) this.Controls.Find("btnreport", true)[0].Visible = false; if (this.Controls.Find("btnReport", true).Length > 0) this.Controls.Find("btnReport", true)[0].Visible = false; }
            
            // Sidebar Navigation
            // btnreport.Click += (s, e) => { new Report().Show(); this.Hide(); };
            // btnEmployee.Click += (s, e) => { new EmployeeManagement().Show(); this.Hide(); };
            // Btnfinalpayment.Click += (s, e) => { new FinalPayment().Show(); this.Hide(); };
            // btnMeasurement.Click += (s, e) => { new Measurement().Show(); this.Hide(); };
            // Btnadvancedpayment.Click += (s, e) => { new AdvancePayment().Show(); this.Hide(); };
            // btnOrder.Click += (s, e) => { new OrderManagement().Show(); this.Hide(); };
            // btncutomer.Click += (s, e) => { new CustomerManagement().Show(); this.Hide(); };
            button5.Click += (s, e) => { if (Program.UserRole == "Tailor") { new TailerDashboard().Show(); } else { new AdminDashboard().Show(); } this.Hide(); };
            // button3.Click += (s, e) => { new Login().Show(); this.Hide(); };
            // button1.Click += (s, e) => { new Login().Show(); this.Hide(); };

            // Wiring internal logic
            this.Load += AdvancePayment_Load;
            cmborderid.SelectedIndexChanged += Cmborderid_SelectedIndexChanged;
            txtadvance.TextChanged += Txtadvance_TextChanged;
            button2.Click += Button2_Click;
        }

        private void AdvancePayment_Load(object sender, EventArgs e)
        {
            EnsureTableExists();
            LoadOrderIDs();
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
                            SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AdvancePayments'
                        )
                        CREATE TABLE AdvancePayments (
                            PaymentID INT PRIMARY KEY IDENTITY(1,1),
                            OrderID INT UNIQUE,
                            Price DECIMAL(10,2),
                            Advance DECIMAL(10,2),
                            AdvancePayDate DATE,
                            Balance DECIMAL(10,2)
                        )";
                    new SqlCommand(sql, conn).ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("DB Setup Error: " + ex.Message);
            }
        }

        private void LoadOrderIDs()
        {
            try
            {
                using (SqlConnection conn = DBConnection.GetConnection())
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT OrderID FROM Orders ORDER BY OrderID DESC", conn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    cmborderid.Items.Clear();
                    while (reader.Read())
                    {
                        cmborderid.Items.Add(reader["OrderID"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading orders: " + ex.Message);
            }
        }

        private void Cmborderid_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmborderid.SelectedItem == null) return;
            string orderId = cmborderid.SelectedItem.ToString();
            txtprice.Clear();
            txtadvance.Clear();
            txtbalance.Clear();
            isUpdating = false;

            try
            {
                using (SqlConnection conn = DBConnection.GetConnection())
                {
                    conn.Open();

                    // Load Price from Orders
                    SqlCommand cmdOrder = new SqlCommand("SELECT Price FROM Orders WHERE OrderID = @id", conn);
                    cmdOrder.Parameters.AddWithValue("@id", orderId);
                    object priceObj = cmdOrder.ExecuteScalar();
                    if (priceObj != null && priceObj != DBNull.Value)
                    {
                        txtprice.Text = priceObj.ToString();
                    }

                    // Check if an Advance Payment already exists
                    SqlCommand cmdAdv = new SqlCommand("SELECT Advance, AdvancePayDate, Balance FROM AdvancePayments WHERE OrderID = @id", conn);
                    cmdAdv.Parameters.AddWithValue("@id", orderId);
                    SqlDataReader reader = cmdAdv.ExecuteReader();
                    if (reader.Read())
                    {
                        isUpdating = true;
                        txtadvance.Text = reader["Advance"].ToString();
                        txtbalance.Text = reader["Balance"].ToString();
                        if (reader["AdvancePayDate"] != DBNull.Value)
                        {
                            DateTimePicker1.Value = Convert.ToDateTime(reader["AdvancePayDate"]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading order details: " + ex.Message);
            }
        }

        private void Txtadvance_TextChanged(object sender, EventArgs e)
        {
            if (decimal.TryParse(txtprice.Text, out decimal price) && decimal.TryParse(txtadvance.Text, out decimal advance))
            {
                txtbalance.Text = (price - advance).ToString("0.00");
            }
            else
            {
                txtbalance.Clear();
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (cmborderid.SelectedItem == null)
            {
                MessageBox.Show("Please select an Order ID.");
                return;
            }

            decimal price = decimal.TryParse(txtprice.Text, out decimal p) ? p : 0;
            decimal advance = decimal.TryParse(txtadvance.Text, out decimal a) ? a : 0;
            decimal balance = decimal.TryParse(txtbalance.Text, out decimal b) ? b : 0;
            string orderId = cmborderid.SelectedItem.ToString();

            try
            {
                using (SqlConnection conn = DBConnection.GetConnection())
                {
                    conn.Open();
                    SqlCommand cmd;

                    if (isUpdating)
                    {
                        cmd = new SqlCommand("UPDATE AdvancePayments SET Price=@price, Advance=@advance, AdvancePayDate=@date, Balance=@balance WHERE OrderID=@id", conn);
                    }
                    else
                    {
                        cmd = new SqlCommand("INSERT INTO AdvancePayments (OrderID, Price, Advance, AdvancePayDate, Balance) VALUES (@id, @price, @advance, @date, @balance)", conn);
                    }

                    cmd.Parameters.AddWithValue("@id", orderId);
                    cmd.Parameters.AddWithValue("@price", price);
                    cmd.Parameters.AddWithValue("@advance", advance);
                    cmd.Parameters.AddWithValue("@date", DateTimePicker1.Value.Date);
                    cmd.Parameters.AddWithValue("@balance", balance);

                    cmd.ExecuteNonQuery();
                    isUpdating = true;
                    MessageBox.Show("Advance Payment saved successfully! Opening Final Payment...");
                    
                    var finalPay = new FinalPayment();
                    finalPay.Show();
                    this.Hide();
                    try { finalPay.cmborderid.SelectedItem = cmborderid.SelectedItem; } catch { }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving payment: " + ex.Message);
            }
        }
    }
}






