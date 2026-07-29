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
    public partial class EmployeeManagement : Form
    {
        private int selectedTailorID = -1;

        public EmployeeManagement()
        {
            InitializeComponent();
            ResponsiveUIHelper.MakeResponsive(this);
            if (Program.UserRole == "Tailor") { if (this.Controls.Find("btnEmployee", true).Length > 0) this.Controls.Find("btnEmployee", true)[0].Visible = false; if (this.Controls.Find("btnreport", true).Length > 0) this.Controls.Find("btnreport", true)[0].Visible = false; if (this.Controls.Find("btnReport", true).Length > 0) this.Controls.Find("btnReport", true)[0].Visible = false; }

            // Sidebar navigation
            // btnreport.Click += (s, e) => { new Report().Show(); this.Hide(); };
            // btnEmployee.Click += (s, e) => { new EmployeeManagement().Show(); this.Hide(); };
            // Btnfinalpayment.Click += (s, e) => { new FinalPayment().Show(); this.Hide(); };
            // btnMeasurement.Click += (s, e) => { new Measurement().Show(); this.Hide(); };
            // Btnadvancedpayment.Click += (s, e) => { new AdvancePayment().Show(); this.Hide(); };
            // btnOrder.Click += (s, e) => { new OrderManagement().Show(); this.Hide(); };
            // btncutomer.Click += (s, e) => { new CustomerManagement().Show(); this.Hide(); };
            button5.Click += (s, e) => { if (Program.UserRole == "Tailor") { new TailerDashboard().Show(); } else { new AdminDashboard().Show(); } this.Hide(); };
            // button3.Click += (s, e) => { new Login().Show(); this.Hide(); };
            // button4.Click += (s, e) => { new Login().Show(); this.Hide(); };

            // CRUD button events
            btnadd.Click   += btnadd_Click;
            button2.Click  += button2_Click;
            button1.Click  += button1_Click;

            this.Load += EmployeeManagement_Load;
        }

        // â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
        // FORM LOAD
        // â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
        private void EmployeeManagement_Load(object sender, EventArgs e)
        {
            EnsureTableExists();
            PositionGrid();
            LoadEmployees();
            SetButtonStates(recordSelected: false);
        }

        private void PositionGrid()
        {
            int gridTop = btnadd.Bottom + 20;
            dgvEmployees.Location = new Point(btnadd.Left, gridTop);
            dgvEmployees.Size = new System.Drawing.Size(
                this.ClientSize.Width - btnadd.Left - 20,
                Math.Max(150, this.ClientSize.Height - gridTop - 20)
            );
            dgvEmployees.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
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
                            SELECT * FROM INFORMATION_SCHEMA.TABLES
                            WHERE TABLE_NAME = 'Employees'
                        )
                        CREATE TABLE Employees (
                            TailorID    INT PRIMARY KEY IDENTITY(1,1),
                            TailorName  NVARCHAR(100),
                            Age         INT,
                            TelephoneNo NVARCHAR(20),
                            Address     NVARCHAR(200),
                            NICNumber   NVARCHAR(20),
                            Status      NVARCHAR(20)
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
        // LOAD / REFRESH GRID
        // â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
        private void LoadEmployees()
        {
            try
            {
                using (SqlConnection conn = DBConnection.GetConnection())
                {
                    conn.Open();
                    SqlDataAdapter da = new SqlDataAdapter(
                        "SELECT TailorID, TailorName, Age, TelephoneNo, Address, NICNumber, Status " +
                        "FROM Employees ORDER BY TailorID", conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvEmployees.DataSource = dt;

                    if (dgvEmployees.Columns.Contains("TailorID"))    dgvEmployees.Columns["TailorID"].HeaderText    = "ID";
                    if (dgvEmployees.Columns.Contains("TailorName"))  dgvEmployees.Columns["TailorName"].HeaderText  = "Tailor Name";
                    if (dgvEmployees.Columns.Contains("TelephoneNo")) dgvEmployees.Columns["TelephoneNo"].HeaderText = "Telephone";
                    if (dgvEmployees.Columns.Contains("NICNumber"))   dgvEmployees.Columns["NICNumber"].HeaderText   = "NIC";
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
        private void dgvEmployees_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow row = dgvEmployees.Rows[e.RowIndex];
            selectedTailorID         = Convert.ToInt32(row.Cells["TailorID"].Value);
            txtemployeeid.Text       = row.Cells["TailorID"].Value.ToString();
            txtemployeename.Text     = row.Cells["TailorName"].Value?.ToString();
            txtage.Text              = row.Cells["Age"].Value?.ToString();
            txttelephoneno1.Text     = row.Cells["TelephoneNo"].Value?.ToString();
            txtaddress.Text          = row.Cells["Address"].Value?.ToString();
            txtnicnumber.Text        = row.Cells["NICNumber"].Value?.ToString();
            cmbstatusEmployee.SelectedItem = row.Cells["Status"].Value?.ToString();
            SetButtonStates(recordSelected: true);
        }

        // â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
        // ADD â€” clear for new entry
        // â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
        private void btnadd_Click(object sender, EventArgs e)
        {
            selectedTailorID = -1;
            txtemployeeid.Text       = "(Auto)";
            txtemployeename.Clear();
            txtage.Clear();
            txttelephoneno1.Clear();
            txttelephoneno2.Clear();
            txtaddress.Clear();
            txtnicnumber.Clear();
            cmbstatusEmployee.SelectedIndex = -1;
            txtemployeename.Focus();
            SetButtonStates(recordSelected: false);
        }

        // â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
        // SAVE â€” INSERT new record
        // â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtemployeename.Text))
            {
                MessageBox.Show("Tailor Name is required.", "Validation");
                return;
            }
            try
            {
                using (SqlConnection conn = DBConnection.GetConnection())
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(
                        "INSERT INTO Employees (TailorName, Age, TelephoneNo, Address, NICNumber, Status) " +
                        "VALUES (@name, @age, @tel, @addr, @nic, @status)", conn);
                    cmd.Parameters.AddWithValue("@name",   txtemployeename.Text.Trim());
                    cmd.Parameters.AddWithValue("@age",    string.IsNullOrWhiteSpace(txtage.Text) ? (object)DBNull.Value : int.Parse(txtage.Text));
                    cmd.Parameters.AddWithValue("@tel",    txttelephoneno1.Text.Trim());
                    cmd.Parameters.AddWithValue("@addr",   txtaddress.Text.Trim());
                    cmd.Parameters.AddWithValue("@nic",    txtnicnumber.Text.Trim());
                    cmd.Parameters.AddWithValue("@status", cmbstatusEmployee.Text.Trim());
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Tailor saved successfully!");
                    LoadEmployees();
                    btnadd_Click(null, null);
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
            if (selectedTailorID < 0)
            {
                MessageBox.Show("Select a tailor from the grid first.", "Validation");
                return;
            }
            try
            {
                using (SqlConnection conn = DBConnection.GetConnection())
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(
                        "UPDATE Employees SET TailorName=@name, Age=@age, TelephoneNo=@tel, " +
                        "Address=@addr, NICNumber=@nic, Status=@status WHERE TailorID=@id", conn);
                    cmd.Parameters.AddWithValue("@name",   txtemployeename.Text.Trim());
                    cmd.Parameters.AddWithValue("@age",    string.IsNullOrWhiteSpace(txtage.Text) ? (object)DBNull.Value : int.Parse(txtage.Text));
                    cmd.Parameters.AddWithValue("@tel",    txttelephoneno1.Text.Trim());
                    cmd.Parameters.AddWithValue("@addr",   txtaddress.Text.Trim());
                    cmd.Parameters.AddWithValue("@nic",    txtnicnumber.Text.Trim());
                    cmd.Parameters.AddWithValue("@status", cmbstatusEmployee.Text.Trim());
                    cmd.Parameters.AddWithValue("@id",     selectedTailorID);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Tailor updated successfully!");
                    LoadEmployees();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Update Error: " + ex.Message);
            }
        }

        // â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
        // DELETE â€” accessed via key press on grid
        // â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
        private void dgvEmployees_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && selectedTailorID >= 0)
            {
                if (MessageBox.Show($"Delete tailor '{txtemployeename.Text}'?", "Confirm Delete",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    try
                    {
                        using (SqlConnection conn = DBConnection.GetConnection())
                        {
                            conn.Open();
                            new SqlCommand($"DELETE FROM Employees WHERE TailorID={selectedTailorID}", conn).ExecuteNonQuery();
                            MessageBox.Show("Tailor deleted.");
                            LoadEmployees();
                            btnadd_Click(null, null);
                        }
                    }
                    catch (Exception ex) { MessageBox.Show("Delete Error: " + ex.Message); }
                }
            }
        }

        // â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
        // BUTTON STATES
        // â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
        private void SetButtonStates(bool recordSelected)
        {
            button2.Enabled = !recordSelected;  // Save: only for new entries
            button1.Enabled = recordSelected;   // Update: only when row selected
        }

        private void EmployeeManagement_Load_1(object sender, EventArgs e)
        {

        }
    }
}






