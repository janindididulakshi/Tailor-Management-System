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
    public partial class CustomerManagement : Form
    {
              SqlConnection con = DBConnection.GetConnection();
              public CustomerManagement()
              {
                  InitializeComponent();
            ResponsiveUIHelper.MakeResponsive(this);
            if (Program.UserRole == "Tailor") { if (this.Controls.Find("btnEmployee", true).Length > 0) this.Controls.Find("btnEmployee", true)[0].Visible = false; if (this.Controls.Find("btnreport", true).Length > 0) this.Controls.Find("btnreport", true)[0].Visible = false; if (this.Controls.Find("btnReport", true).Length > 0) this.Controls.Find("btnReport", true)[0].Visible = false; }
              }
        private void CustomerManagement_Load(object sender, EventArgs e)
        {
            LoadCustomers();
        }

        private void LoadCustomers()
        {
            try
            {
                using (SqlConnection connection = DBConnection.GetConnection())
                {
                    connection.Open();
                    SqlDataAdapter da = new SqlDataAdapter("SELECT CustomerID, CustomerName, TelephoneNo, Address FROM Customers", connection);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvCustomers.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void txttelephoneno2_TextChanged(object sender, EventArgs e)
        {
        
        }

        private void lblcustomermanagement_Click(object sender, EventArgs e)
        {
        
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = DBConnection.GetConnection())
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO Customers(CustomerName,TelephoneNo,Address) VALUES(@name,@phone,@address)", connection);
                    cmd.Parameters.AddWithValue("@name", txtcustomername.Text);
                    cmd.Parameters.AddWithValue("@phone", txttelephoneno1.Text);
                    cmd.Parameters.AddWithValue("@address", txttelephoneno2.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Customer Saved Successfully!");
                }
                LoadCustomers();
                btnadd_Click(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            txtcustomerid.Clear();
            txtcustomername.Clear();
            txttelephoneno1.Clear();
            txttelephoneno2.Clear();
            btnsave.Enabled = true;
            txtcustomername.Focus();
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtcustomerid.Text))
            {
                MessageBox.Show("Please select a customer to update.");
                return;
            }
            try
            {
                using (SqlConnection connection = DBConnection.GetConnection())
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("UPDATE Customers SET CustomerName=@name, TelephoneNo=@phone, Address=@address WHERE CustomerID=@id", connection);
                    cmd.Parameters.AddWithValue("@name", txtcustomername.Text);
                    cmd.Parameters.AddWithValue("@phone", txttelephoneno1.Text);
                    cmd.Parameters.AddWithValue("@address", txttelephoneno2.Text);
                    cmd.Parameters.AddWithValue("@id", txtcustomerid.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Customer Updated Successfully!");
                }
                LoadCustomers();
                btnadd_Click(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtcustomerid.Text))
            {
                MessageBox.Show("Please select a customer to delete.");
                return;
            }
            if (MessageBox.Show("Are you sure you want to delete this customer?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection connection = DBConnection.GetConnection())
                    {
                        connection.Open();
                        SqlCommand cmd = new SqlCommand("DELETE FROM Customers WHERE CustomerID=@id", connection);
                        cmd.Parameters.AddWithValue("@id", txtcustomerid.Text);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Customer Deleted Successfully!");
                    }
                    LoadCustomers();
                    btnadd_Click(null, null);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void dgvCustomers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvCustomers.Rows[e.RowIndex];
                txtcustomerid.Text = row.Cells["CustomerID"].Value.ToString();
                txtcustomername.Text = row.Cells["CustomerName"].Value.ToString();
                txttelephoneno1.Text = row.Cells["TelephoneNo"].Value.ToString();
                txttelephoneno2.Text = row.Cells["Address"].Value.ToString();
                btnsave.Enabled = false;
            }
        }
        private void button3_Click(object sender, EventArgs e) { new Login().Show(); this.Hide(); }
        private void button1_Click(object sender, EventArgs e) { new Login().Show(); this.Hide(); }
        private void btnreport_Click(object sender, EventArgs e) { { new Report().Show(); this.Hide(); }; }
        private void btnEmployee_Click(object sender, EventArgs e) { new EmployeeManagement().Show(); this.Hide(); }
        private void Btnfinalpayment_Click(object sender, EventArgs e) { new FinalPayment().Show(); this.Hide(); }
        private void btnMeasurement_Click(object sender, EventArgs e) { new Measurement().Show(); this.Hide(); }
        private void Btnadvancedpayment_Click(object sender, EventArgs e) { new AdvancePayment().Show(); this.Hide(); }
        private void button4_Click(object sender, EventArgs e) { if (Program.UserRole == "Tailor") { new TailerDashboard().Show(); } else { new AdminDashboard().Show(); } this.Hide(); }
        private void btnOrder_Click(object sender, EventArgs e) { new OrderManagement().Show(); this.Hide(); }
        private void btncutomer_Click(object sender, EventArgs e) { /* Already here */ }

        private void button4_Click_1(object sender, EventArgs e)
        {

        }
    }
}


