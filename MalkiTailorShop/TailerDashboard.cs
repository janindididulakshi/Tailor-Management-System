using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MalkiTailorShop
{
    public partial class TailerDashboard : Form
    {
        public TailerDashboard()
        {
            InitializeComponent();
            ResponsiveUIHelper.MakeResponsive(this);
            // btnFinalPayment.Click += (s, e) => { new FinalPayment().Show(); this.Hide(); };
            // btnMeasurement.Click += (s, e) => { new Measurement().Show(); this.Hide(); };
            // btnAdvancedPayment.Click += (s, e) => { new AdvancePayment().Show(); this.Hide(); };
            // btnOrder.Click += (s, e) => { new OrderManagement().Show(); this.Hide(); };
            // btnCutomer.Click += (s, e) => { new CustomerManagement().Show(); this.Hide(); };
            // btnHome.Click += (s, e) => { new TailerDashboard().Show(); this.Hide(); };
            // btnLogout.Click += (s, e) => { new Login().Show(); this.Hide(); };
            // button2.Click += (s, e) => { new Login().Show(); this.Hide(); };
            
            InitCustomControls();
            this.Load += Dashboard2_Load;
        }

        private void InitCustomControls()
        {
            this.BackColor = Color.WhiteSmoke;

            // Title
            Label title = new Label();
            title.Text = "Tailor Dashboard";
            title.Font = new Font("Segoe UI", 26F, FontStyle.Bold);
            title.ForeColor = Color.FromArgb(64, 64, 64);
            title.Location = new Point(340, 25);
            title.AutoSize = true;

            // Card 1: Total Orders
            Panel pnlOrders = new Panel();
            pnlOrders.Location = new Point(340, 90);
            pnlOrders.Size = new Size(380, 160);
            pnlOrders.BackColor = Color.MediumSeaGreen;
            pnlOrders.Padding = new Padding(15);
            Label lblOrders = new Label();
            lblOrders.Name = "lblOrders";
            lblOrders.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblOrders.ForeColor = Color.White;
            lblOrders.Dock = DockStyle.Fill;
            lblOrders.TextAlign = ContentAlignment.MiddleCenter;
            lblOrders.Text = "Loading...";
            pnlOrders.Controls.Add(lblOrders);

            // Card 2: Total Customers
            Panel pnlCustomers = new Panel();
            pnlCustomers.Location = new Point(740, 90);
            pnlCustomers.Size = new Size(380, 160);
            pnlCustomers.BackColor = Color.RoyalBlue;
            pnlCustomers.Padding = new Padding(15);
            Label lblCustomers = new Label();
            lblCustomers.Name = "lblCustomers";
            lblCustomers.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblCustomers.ForeColor = Color.White;
            lblCustomers.Dock = DockStyle.Fill;
            lblCustomers.TextAlign = ContentAlignment.MiddleCenter;
            lblCustomers.Text = "Loading...";
            pnlCustomers.Controls.Add(lblCustomers);

            this.Controls.Add(title);
            this.Controls.Add(pnlOrders);
            this.Controls.Add(pnlCustomers);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }

        private void Dashboard2_Load(object sender, EventArgs e)
        {
            try
            {
                using (System.Data.SqlClient.SqlConnection conn = MalkiTailorShop.DB_Connection.DBConnection.GetConnection())
                {
                    conn.Open();
                    
                    // Orders
                    object oCount = new System.Data.SqlClient.SqlCommand("SELECT COUNT(*) FROM Orders", conn).ExecuteScalar();
                    int orders = (oCount != null && oCount != DBNull.Value) ? Convert.ToInt32(oCount) : 0;
                    ((Label)this.Controls.Find("lblOrders", true)[0]).Text = $"Total Orders\n\n{orders}";
                    
                    // Customers
                    object cCount = new System.Data.SqlClient.SqlCommand("SELECT COUNT(*) FROM Customers", conn).ExecuteScalar();
                    int customers = (cCount != null && cCount != DBNull.Value) ? Convert.ToInt32(cCount) : 0;
                    ((Label)this.Controls.Find("lblCustomers", true)[0]).Text = $"Total Customers\n\n{customers}";
                }
            }
            catch (Exception)
            {
                // Ignore errors silently on dashboard load
            }
        }
    
}
}


