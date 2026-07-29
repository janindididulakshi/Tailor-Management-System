using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using MalkiTailorShop.DB_Connection;

namespace MalkiTailorShop
{
    public partial class OrderManagement : Form
    {
        private int selectedOrderID = -1;

        public OrderManagement()
        {
            InitializeComponent();
            ResponsiveUIHelper.MakeResponsive(this);
            if (Program.UserRole == "Tailor") { if (this.Controls.Find("btnEmployee", true).Length > 0) this.Controls.Find("btnEmployee", true)[0].Visible = false; if (this.Controls.Find("btnreport", true).Length > 0) this.Controls.Find("btnreport", true)[0].Visible = false; if (this.Controls.Find("btnReport", true).Length > 0) this.Controls.Find("btnReport", true)[0].Visible = false; }

            // Sidebar navigation
            // btnreport.Click         += (s, e) => { new Report().Show(); this.Hide(); };
            // btnEmployee.Click       += (s, e) => { new EmployeeManagement().Show(); this.Hide(); };
            // Btnfinalpayment.Click   += (s, e) => { new FinalPayment().Show(); this.Hide(); };
            // btnMeasurement.Click    += (s, e) => { new Measurement().Show(); this.Hide(); };
            // Btnadvancedpayment.Click+= (s, e) => { new AdvancePayment().Show(); this.Hide(); };
            // btnOrder.Click          += (s, e) => { new OrderManagement().Show(); this.Hide(); };
            // btncutomer.Click        += (s, e) => { new CustomerManagement().Show(); this.Hide(); };
            button5.Click           += (s, e) => { if (Program.UserRole == "Tailor") { new TailerDashboard().Show(); } else { new AdminDashboard().Show(); } this.Hide(); };
            // button3.Click           += (s, e) => { new Login().Show(); this.Hide(); };
            // button4.Click           += (s, e) => { new Login().Show(); this.Hide(); };
        }

        // â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
        // FORM LOAD
        // â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
        private void OrderManagement_Load(object sender, EventArgs e)
        {
            EnsureTableExists();
            LoadDropdowns();
            PositionGrid();
            LoadOrders();
            SetButtonStates(recordSelected: false);
        }

        private void PositionGrid()
        {
            int gridTop = btnSave.Bottom + 20;
            dgvOrders.Location = new Point(btnSave.Left, gridTop);
            dgvOrders.Size = new Size(
                this.ClientSize.Width - btnSave.Left - 20,
                Math.Max(150, this.ClientSize.Height - gridTop - 20)
            );
            dgvOrders.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
        }

        // â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
        // AUTO-CREATE TABLE
        // â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
        private void EnsureTableExists()
        {
            try
            {
                using (SqlConnection conn = DBConnection.GetConnection())
                {
                    conn.Open();
                    string sql = @"
                        IF NOT EXISTS (
                            SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Orders'
                        )
                        CREATE TABLE Orders (
                            OrderID    INT PRIMARY KEY IDENTITY(1,1),
                            CustomerID INT,
                            TailorID   INT,
                            DressType  NVARCHAR(50),
                            OrderDate  DATE,
                            DueDate    DATE,
                            Price      DECIMAL(10,2),
                            Status     NVARCHAR(30)
                        )";
                    new SqlCommand(sql, conn).ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("DB Setup Error: " + ex.Message);
            }
        }

        // â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
        // LOAD DROPDOWNS
        // â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
        private void LoadDropdowns()
        {
            try
            {
                using (SqlConnection conn = DBConnection.GetConnection())
                {
                    conn.Open();

                    // Customer IDs
                    cmbcustomerid.Items.Clear();
                    var r1 = new SqlCommand("SELECT CustomerID FROM Customers ORDER BY CustomerID", conn).ExecuteReader();
                    while (r1.Read()) cmbcustomerid.Items.Add(r1["CustomerID"].ToString());
                    r1.Close();

                    // Tailor IDs
                    cmbtailorid.Items.Clear();
                    var r2 = new SqlCommand("SELECT TailorID FROM Employees ORDER BY TailorID", conn).ExecuteReader();
                    while (r2.Read()) cmbtailorid.Items.Add(r2["TailorID"].ToString());
                    r2.Close();

                    // Dress Types
                    if (cmbdresstype.Items.Count == 0)
                    {
                        cmbdresstype.Items.Add("Frock");
                        cmbdresstype.Items.Add("Saree Jacket");
                        cmbdresstype.Items.Add("Uniform");
                    }

                    // Statuses
                    if (cmbstatus.Items.Count == 0)
                    {
                        cmbstatus.Items.Add("Pending");
                        cmbstatus.Items.Add("Processing");
                        cmbstatus.Items.Add("Completed");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading dropdowns: " + ex.Message);
            }
        }

        // â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
        // LOAD / REFRESH GRID
        // â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
        private void LoadOrders()
        {
            try
            {
                using (SqlConnection conn = DBConnection.GetConnection())
                {
                    conn.Open();
                    SqlDataAdapter da = new SqlDataAdapter(
                        "SELECT OrderID, CustomerID, TailorID, DressType, OrderDate, DueDate, Price, Status " +
                        "FROM Orders ORDER BY OrderID DESC", conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvOrders.DataSource = dt;
                    if (dgvOrders.Columns.Contains("OrderID"))    dgvOrders.Columns["OrderID"].HeaderText    = "Order ID";
                    if (dgvOrders.Columns.Contains("CustomerID")) dgvOrders.Columns["CustomerID"].HeaderText = "Customer";
                    if (dgvOrders.Columns.Contains("TailorID"))   dgvOrders.Columns["TailorID"].HeaderText   = "Tailor";
                    if (dgvOrders.Columns.Contains("DressType"))  dgvOrders.Columns["DressType"].HeaderText  = "Dress";
                    if (dgvOrders.Columns.Contains("OrderDate"))  dgvOrders.Columns["OrderDate"].HeaderText  = "Order Date";
                    if (dgvOrders.Columns.Contains("DueDate"))    dgvOrders.Columns["DueDate"].HeaderText    = "Due Date";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Load Error: " + ex.Message);
            }
        }

        // â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
        // GRID ROW CLICK â€” populate fields
        // â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
        private void dgvOrders_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow row = dgvOrders.Rows[e.RowIndex];
            selectedOrderID = Convert.ToInt32(row.Cells["OrderID"].Value);
            txtorderid.Text = selectedOrderID.ToString();

            string custId = row.Cells["CustomerID"].Value?.ToString();
            string tailorId = row.Cells["TailorID"].Value?.ToString();
            string dressType = row.Cells["DressType"].Value?.ToString();

            cmbcustomerid.SelectedItem = cmbcustomerid.Items.Contains(custId) ? custId : null;
            cmbtailorid.SelectedItem   = cmbtailorid.Items.Contains(tailorId) ? tailorId : null;
            cmbdresstype.SelectedItem  = cmbdresstype.Items.Contains(dressType) ? dressType : null;
            txtprice.Text = row.Cells["Price"].Value?.ToString();

            if (row.Cells["OrderDate"].Value != DBNull.Value && row.Cells["OrderDate"].Value != null)
                DateTimePicker1.Value = Convert.ToDateTime(row.Cells["OrderDate"].Value);
            if (row.Cells["DueDate"].Value != DBNull.Value && row.Cells["DueDate"].Value != null)
                DateTimePicker2.Value = Convert.ToDateTime(row.Cells["DueDate"].Value);

            string status = row.Cells["Status"].Value?.ToString();
            cmbstatus.SelectedItem = cmbstatus.Items.Contains(status) ? status : null;

            SetButtonStates(recordSelected: true);
        }

        // â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
        // SAVE â€” INSERT and navigate to Measurement
        // â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs()) return;
            try
            {
                using (SqlConnection conn = DBConnection.GetConnection())
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(
                        "INSERT INTO Orders (CustomerID, TailorID, DressType, OrderDate, DueDate, Price, Status) " +
                        "OUTPUT INSERTED.OrderID " +
                        "VALUES (@cust, @tailor, @dress, @odate, @ddate, @price, @status)", conn);
                    SetOrderParams(cmd);
                    int newOrderID = (int)cmd.ExecuteScalar();
                    MessageBox.Show($"âœ… Order #{newOrderID} saved! Opening Measurement...");
                    LoadOrders();
                    // Navigate to Measurement with the new Order ID pre-selected
                    var meas = new Measurement();
                    meas.Show();
                    this.Hide();
                    // Pre-select order in Measurement if cmbOrderID exists
                    try { meas.cmbOrderID.SelectedItem = newOrderID.ToString(); } catch { }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Save Error: " + ex.Message);
            }
        }

        // â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
        // UPDATE â€” UPDATE existing record
        // â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
        private void button1_Click(object sender, EventArgs e)
        {
            if (selectedOrderID < 0) { MessageBox.Show("Select an order from the grid first."); return; }
            if (!ValidateInputs()) return;
            try
            {
                using (SqlConnection conn = DBConnection.GetConnection())
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(
                        "UPDATE Orders SET CustomerID=@cust, TailorID=@tailor, DressType=@dress, " +
                        "OrderDate=@odate, DueDate=@ddate, Price=@price, Status=@status WHERE OrderID=@id", conn);
                    SetOrderParams(cmd);
                    cmd.Parameters.AddWithValue("@id", selectedOrderID);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("âœ… Order updated successfully!");
                    LoadOrders();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Update Error: " + ex.Message);
            }
        }

        // â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
        // DELETE
        // â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedOrderID < 0) { MessageBox.Show("Select an order from the grid first."); return; }
            if (MessageBox.Show($"Delete Order #{selectedOrderID}?", "Confirm",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;
            try
            {
                using (SqlConnection conn = DBConnection.GetConnection())
                {
                    conn.Open();
                    new SqlCommand($"DELETE FROM Orders WHERE OrderID={selectedOrderID}", conn).ExecuteNonQuery();
                    MessageBox.Show("ðŸ—‘ï¸ Order deleted.");
                    LoadOrders();
                    ClearFields();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Delete Error: " + ex.Message);
            }
        }

        // â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
        // HELPERS
        // â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
        private void SetOrderParams(SqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("@cust",   cmbcustomerid.SelectedItem?.ToString() ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@tailor", cmbtailorid.SelectedItem?.ToString()   ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@dress",  cmbdresstype.SelectedItem?.ToString()  ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@odate",  DateTimePicker1.Value.Date);
            cmd.Parameters.AddWithValue("@ddate",  DateTimePicker2.Value.Date);
            cmd.Parameters.AddWithValue("@price",  string.IsNullOrWhiteSpace(txtprice.Text) ? (object)DBNull.Value : decimal.Parse(txtprice.Text));
            cmd.Parameters.AddWithValue("@status", cmbstatus.SelectedItem?.ToString() ?? (object)DBNull.Value);
        }

        private bool ValidateInputs()
        {
            if (cmbcustomerid.SelectedItem == null) { MessageBox.Show("Please select a Customer ID.", "Validation"); return false; }
            if (cmbdresstype.SelectedItem  == null) { MessageBox.Show("Please select a Dress Type.", "Validation");  return false; }
            return true;
        }

        private void ClearFields()
        {
            selectedOrderID = -1;
            txtorderid.Clear();
            cmbcustomerid.SelectedIndex = -1;
            cmbtailorid.SelectedIndex   = -1;
            cmbdresstype.SelectedIndex  = -1;
            cmbstatus.SelectedIndex     = -1;
            txtprice.Clear();
            DateTimePicker1.Value = DateTime.Today;
            DateTimePicker2.Value = DateTime.Today;
            SetButtonStates(recordSelected: false);
        }

        private void SetButtonStates(bool recordSelected)
        {
            btnSave.Enabled   = !recordSelected;
            btnUpdate.Enabled = recordSelected;
            btnDelete.Enabled = recordSelected;
        }
    }
}




