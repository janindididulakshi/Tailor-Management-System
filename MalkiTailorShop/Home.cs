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
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
            SetupAnalyticsUI();
            ResponsiveUIHelper.MakeResponsive(this);
            if (Program.UserRole == "Tailor") { if (this.Controls.Find("btnEmployee", true).Length > 0) this.Controls.Find("btnEmployee", true)[0].Visible = false; if (this.Controls.Find("btnreport", true).Length > 0) this.Controls.Find("btnreport", true)[0].Visible = false; if (this.Controls.Find("btnReport", true).Length > 0) this.Controls.Find("btnReport", true)[0].Visible = false; }
            
            // Wire up sidebar buttons
            if (this.Controls.Find("btnreport", true).Length > 0) this.Controls.Find("btnreport", true)[0].Click += (s, e) => { new Report().Show(); this.Hide(); };
            if (this.Controls.Find("btnEmployee", true).Length > 0) this.Controls.Find("btnEmployee", true)[0].Click += (s, e) => { new EmployeeManagement().Show(); this.Hide(); };
            if (this.Controls.Find("Btnfinalpayment", true).Length > 0) this.Controls.Find("Btnfinalpayment", true)[0].Click += (s, e) => { new FinalPayment().Show(); this.Hide(); };
            if (this.Controls.Find("btnMeasurement", true).Length > 0) this.Controls.Find("btnMeasurement", true)[0].Click += (s, e) => { new Measurement().Show(); this.Hide(); };
            if (this.Controls.Find("Btnadvancedpayment", true).Length > 0) this.Controls.Find("Btnadvancedpayment", true)[0].Click += (s, e) => { new AdvancePayment().Show(); this.Hide(); };
            if (this.Controls.Find("btnOrder", true).Length > 0) this.Controls.Find("btnOrder", true)[0].Click += (s, e) => { new OrderManagement().Show(); this.Hide(); };
            if (this.Controls.Find("btncutomer", true).Length > 0) this.Controls.Find("btncutomer", true)[0].Click += (s, e) => { new CustomerManagement().Show(); this.Hide(); };
            if (this.Controls.Find("button5", true).Length > 0) this.Controls.Find("button5", true)[0].Click += (s, e) => { new Home().Show(); this.Hide(); };
            if (this.Controls.Find("button3", true).Length > 0) this.Controls.Find("button3", true)[0].Click += (s, e) => { new Login().Show(); this.Hide(); };
            if (this.Controls.Find("button4", true).Length > 0) this.Controls.Find("button4", true)[0].Click += (s, e) => { new Login().Show(); this.Hide(); };
        }

        private void SetupAnalyticsUI() {
            this.Controls.Add(this.panelOrders);
            this.Controls.Add(this.panelCustomers);
            this.Controls.Add(this.panelRevenue);
            this.Controls.Add(this.panelEmployees);

            // Panel 1: Customers
            panelCustomers.Size = new Size(250, 130);
            panelCustomers.Location = new Point(360, 100);
            panelCustomers.BackColor = Color.MediumSeaGreen;
            lblCustomersTitle.Text = "TOTAL CUSTOMERS";
            lblCustomersTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblCustomersTitle.ForeColor = Color.White;
            lblCustomersTitle.Location = new Point(20, 20);
            lblCustomersTitle.AutoSize = true;
            panelCustomers.Controls.Add(lblCustomersTitle);
            lblTotalCustomers.Text = "0";
            lblTotalCustomers.Font = new Font("Segoe UI", 28F, FontStyle.Bold);
            lblTotalCustomers.ForeColor = Color.White;
            lblTotalCustomers.Location = new Point(15, 50);
            lblTotalCustomers.AutoSize = true;
            panelCustomers.Controls.Add(lblTotalCustomers);

            // Panel 2: Tailors
            panelEmployees.Size = new Size(250, 130);
            panelEmployees.Location = new Point(640, 100);
            panelEmployees.BackColor = Color.DodgerBlue;
            lblEmployeesTitle.Text = "TOTAL TAILORS";
            lblEmployeesTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblEmployeesTitle.ForeColor = Color.White;
            lblEmployeesTitle.Location = new Point(20, 20);
            lblEmployeesTitle.AutoSize = true;
            panelEmployees.Controls.Add(lblEmployeesTitle);
            lblTotalEmployees.Text = "0";
            lblTotalEmployees.Font = new Font("Segoe UI", 28F, FontStyle.Bold);
            lblTotalEmployees.ForeColor = Color.White;
            lblTotalEmployees.Location = new Point(15, 50);
            lblTotalEmployees.AutoSize = true;
            panelEmployees.Controls.Add(lblTotalEmployees);

            // Panel 3: Orders
            panelOrders.Size = new Size(250, 130);
            panelOrders.Location = new Point(640, 260);
            panelOrders.BackColor = Color.MediumPurple;
            lblOrdersTitle.Text = "TOTAL ORDERS";
            lblOrdersTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblOrdersTitle.ForeColor = Color.White;
            lblOrdersTitle.Location = new Point(20, 20);
            lblOrdersTitle.AutoSize = true;
            panelOrders.Controls.Add(lblOrdersTitle);
            lblTotalOrders.Text = "0";
            lblTotalOrders.Font = new Font("Segoe UI", 28F, FontStyle.Bold);
            lblTotalOrders.ForeColor = Color.White;
            lblTotalOrders.Location = new Point(15, 50);
            lblTotalOrders.AutoSize = true;
            panelOrders.Controls.Add(lblTotalOrders);

            // Panel 4: Revenue
            panelRevenue.Size = new Size(250, 130);
            panelRevenue.Location = new Point(360, 260);
            panelRevenue.BackColor = Color.Crimson;
            lblRevenueTitle.Text = "TOTAL REVENUE";
            lblRevenueTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblRevenueTitle.ForeColor = Color.White;
            lblRevenueTitle.Location = new Point(20, 20);
            lblRevenueTitle.AutoSize = true;
            panelRevenue.Controls.Add(lblRevenueTitle);
            lblTodayRevenue.Text = "Rs. 0.00";
            lblTodayRevenue.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblTodayRevenue.ForeColor = Color.White;
            lblTodayRevenue.Location = new Point(15, 50);
            lblTodayRevenue.AutoSize = true;
            panelRevenue.Controls.Add(lblTodayRevenue);
        }

        private void Home_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData() {
            try {
                using (SqlConnection con = DBConnection.GetConnection()) {
                    con.Open();
                    // Customers
                    using (var cmd = new SqlCommand("SELECT COUNT(*) FROM Customers", con)) {
                        lblTotalCustomers.Text = cmd.ExecuteScalar()?.ToString() ?? "0";
                    }
                    // Tailors
                    using (var cmd = new SqlCommand("SELECT COUNT(*) FROM Employees", con)) {
                        lblTotalEmployees.Text = cmd.ExecuteScalar()?.ToString() ?? "0";
                    }
                    // Orders
                    using (var cmd = new SqlCommand("SELECT COUNT(*) FROM Orders", con)) {
                        lblTotalOrders.Text = cmd.ExecuteScalar()?.ToString() ?? "0";
                    }
                    // Revenue
                    using (var cmd = new SqlCommand("SELECT SUM(Price) FROM Orders", con)) {
                        var rev = cmd.ExecuteScalar();
                        if (rev != DBNull.Value && rev != null) {
                            lblTodayRevenue.Text = "Rs. " + Convert.ToDecimal(rev).ToString("0.00");
                        } else {
                            lblTodayRevenue.Text = "Rs. 0.00";
                        }
                    }
                }
            } catch (Exception ex) {
                MessageBox.Show("Error loading analytics: " + ex.Message);
            }
        }
    }
}
