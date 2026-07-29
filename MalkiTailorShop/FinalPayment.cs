using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using MalkiTailorShop.DB_Connection;

namespace MalkiTailorShop
{
    public partial class FinalPayment : Form
    {
        private bool isUpdating = false;

        public FinalPayment()
        {
            InitializeComponent();
            ResponsiveUIHelper.MakeResponsive(this);
            if (Program.UserRole == "Tailor") { if (this.Controls.Find("btnEmployee", true).Length > 0) this.Controls.Find("btnEmployee", true)[0].Visible = false; if (this.Controls.Find("btnreport", true).Length > 0) this.Controls.Find("btnreport", true)[0].Visible = false; if (this.Controls.Find("btnReport", true).Length > 0) this.Controls.Find("btnReport", true)[0].Visible = false; }
            // btnreport.Click += (s, e) => { new Report().Show(); this.Hide(); };
            // btnEmployee.Click += (s, e) => { new EmployeeManagement().Show(); this.Hide(); };
            // Btnfinalpayment.Click += (s, e) => { new FinalPayment().Show(); this.Hide(); };
            // btnMeasurement.Click += (s, e) => { new Measurement().Show(); this.Hide(); };
            // Btnadvancedpayment.Click += (s, e) => { new AdvancePayment().Show(); this.Hide(); };
            // btnOrder.Click += (s, e) => { new OrderManagement().Show(); this.Hide(); };
            // btncutomer.Click += (s, e) => { new CustomerManagement().Show(); this.Hide(); };
            // button7.Click += (s, e) => { new Report().Show(); this.Hide(); };
            // button8.Click += (s, e) => { new EmployeeManagement().Show(); this.Hide(); };
            button5.Click += (s, e) => { if (Program.UserRole == "Tailor") { new TailerDashboard().Show(); } else { new AdminDashboard().Show(); } this.Hide(); };
            // button12.Click += (s, e) => { if (Program.UserRole == "Tailor") { new TailerDashboard().Show(); } else { new AdminDashboard().Show(); } this.Hide(); };
            // button3.Click += (s, e) => { new Login().Show(); this.Hide(); };
            // button4.Click += (s, e) => { new Login().Show(); this.Hide(); };
            // button1.Click += (s, e) => { new Login().Show(); this.Hide(); };
            // button6.Click += (s, e) => { new Login().Show(); this.Hide(); };

            this.Load += FinalPayment_Load;
            cmborderid.SelectedIndexChanged += Cmborderid_SelectedIndexChanged;
        }

        private void FinalPayment_Load(object sender, EventArgs e)
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
                            SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'FinalPayments'
                        )
                        CREATE TABLE FinalPayments (
                            FinalPaymentID INT PRIMARY KEY IDENTITY(1,1),
                            OrderID INT UNIQUE,
                            Advance DECIMAL(10,2),
                            BalanceAmount DECIMAL(10,2),
                            FinalPayDate DATE,
                            Status NVARCHAR(20)
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
            txtbalanceamount.Clear();
            cmbcompletepayment.SelectedIndex = -1;
            isUpdating = false;

            try
            {
                using (SqlConnection conn = DBConnection.GetConnection())
                {
                    conn.Open();

                    // Load Price
                    SqlCommand cmdOrder = new SqlCommand("SELECT Price FROM Orders WHERE OrderID = @id", conn);
                    cmdOrder.Parameters.AddWithValue("@id", orderId);
                    object priceObj = cmdOrder.ExecuteScalar();
                    decimal price = (priceObj != null && priceObj != DBNull.Value) ? Convert.ToDecimal(priceObj) : 0;
                    txtprice.Text = price.ToString("0.00");

                    // Load Advance Payment
                    SqlCommand cmdAdv = new SqlCommand("SELECT Advance, Balance FROM AdvancePayments WHERE OrderID = @id", conn);
                    cmdAdv.Parameters.AddWithValue("@id", orderId);
                    SqlDataReader readerAdv = cmdAdv.ExecuteReader();
                    decimal advance = 0;
                    decimal balance = price;
                    
                    if (readerAdv.Read())
                    {
                        advance = Convert.ToDecimal(readerAdv["Advance"]);
                        balance = Convert.ToDecimal(readerAdv["Balance"]);
                    }
                    readerAdv.Close();

                    txtadvance.Text = advance.ToString("0.00");
                    txtbalanceamount.Text = balance.ToString("0.00");

                    // Check if Final Payment exists
                    SqlCommand cmdFinal = new SqlCommand("SELECT FinalPayDate, Status FROM FinalPayments WHERE OrderID = @id", conn);
                    cmdFinal.Parameters.AddWithValue("@id", orderId);
                    SqlDataReader readerFinal = cmdFinal.ExecuteReader();
                    if (readerFinal.Read())
                    {
                        isUpdating = true;
                        cmbcompletepayment.SelectedItem = readerFinal["Status"].ToString();
                        if (readerFinal["FinalPayDate"] != DBNull.Value)
                        {
                            DateTimePicker1.Value = Convert.ToDateTime(readerFinal["FinalPayDate"]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading details: " + ex.Message);
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (cmborderid.SelectedItem == null)
            {
                MessageBox.Show("Please select an Order ID.");
                return;
            }

            decimal advance = decimal.TryParse(txtadvance.Text, out decimal a) ? a : 0;
            decimal balance = decimal.TryParse(txtbalanceamount.Text, out decimal b) ? b : 0;
            string status = cmbcompletepayment.SelectedItem?.ToString() ?? "Pending";
            string orderId = cmborderid.SelectedItem.ToString();

            try
            {
                using (SqlConnection conn = DBConnection.GetConnection())
                {
                    conn.Open();
                    SqlCommand cmd;

                    if (isUpdating)
                    {
                        cmd = new SqlCommand("UPDATE FinalPayments SET Advance=@adv, BalanceAmount=@bal, FinalPayDate=@date, Status=@status WHERE OrderID=@id", conn);
                    }
                    else
                    {
                        cmd = new SqlCommand("INSERT INTO FinalPayments (OrderID, Advance, BalanceAmount, FinalPayDate, Status) VALUES (@id, @adv, @bal, @date, @status)", conn);
                    }

                    cmd.Parameters.AddWithValue("@id", orderId);
                    cmd.Parameters.AddWithValue("@adv", advance);
                    cmd.Parameters.AddWithValue("@bal", balance);
                    cmd.Parameters.AddWithValue("@date", DateTimePicker1.Value.Date);
                    cmd.Parameters.AddWithValue("@status", status);

                    cmd.ExecuteNonQuery();
                    isUpdating = true;
                    MessageBox.Show("Final Payment saved successfully!");
                    
                    // Update Order Status directly
                    if (status == "Completed")
                    {
                        SqlCommand cmdStatus = new SqlCommand("UPDATE Orders SET Status='Completed' WHERE OrderID=@id", conn);
                        cmdStatus.Parameters.AddWithValue("@id", orderId);
                        cmdStatus.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving final payment: " + ex.Message);
            }
        }

        private void FinalPayment_Load_1(object sender, EventArgs e)
        {

        }

        private void DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}





