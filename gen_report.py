import re

content = '''using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using MalkiTailorShop.DB_Connection;

namespace MalkiTailorShop
{
    public partial class Report : Form
    {
        public Report()
        {
            InitializeComponent();
            ResponsiveUIHelper.MakeResponsive(this);
            
            // Setup events
            this.Load += Report_Load;
            btnFilter.Click += btnFilter_Click;
            btnDownloadPDF.Click += btnDownloadPDF_Click;
            
            btnDownloadPDF.Text = "?? Export CSV"; // Change to CSV explicitly
            btnDownloadPDF.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            
            if (Program.UserRole == "Tailor") { if (this.Controls.Find("btnEmployee", true).Length > 0) this.Controls.Find("btnEmployee", true)[0].Visible = false; if (this.Controls.Find("btnreport", true).Length > 0) this.Controls.Find("btnreport", true)[0].Visible = false; if (this.Controls.Find("btnReport", true).Length > 0) this.Controls.Find("btnReport", true)[0].Visible = false; }
            btnHome.Click += (s, e) => { new Home().Show(); this.Hide(); };
            btnCutomer.Click += (s, e) => { new CustomerManagement().Show(); this.Hide(); };
            btnOrder.Click += (s, e) => { new OrderManagement().Show(); this.Hide(); };
            btnMeasurement.Click += (s, e) => { new Measurement().Show(); this.Hide(); };
            btnAdvancedPayment.Click += (s, e) => { new AdvancePayment().Show(); this.Hide(); };
            btnFinalPayment.Click += (s, e) => { new FinalPayment().Show(); this.Hide(); };
            btnEmployee.Click += (s, e) => { new EmployeeManagement().Show(); this.Hide(); };
            btnLogout.Click += (s, e) => { new Login().Show(); this.Hide(); };
        }

        private void Report_Load(object sender, EventArgs e)
        {
            LoadReportData(null, null);
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            LoadReportData(dtpStartDate.Value.Date, dtpEndDate.Value.Date);
        }

        private void LoadReportData(DateTime? start, DateTime? end)
        {
            try
            {
                using (SqlConnection con = DBConnection.GetConnection())
                {
                    con.Open();
                    string query = @"SELECT o.OrderID, c.CustomerName, e.TailorName, o.DressType, o.OrderDate, o.DueDate, o.Status, o.Price 
                                     FROM Orders o 
                                     LEFT JOIN Customers c ON o.CustomerID = c.CustomerID 
                                     LEFT JOIN Employees e ON o.TailorID = e.TailorID";
                    
                    if (start.HasValue && end.HasValue)
                    {
                        query += " WHERE CAST(o.OrderDate AS DATE) >= @start AND CAST(o.OrderDate AS DATE) <= @end";
                    }

                    SqlCommand cmd = new SqlCommand(query, con);
                    if (start.HasValue && end.HasValue)
                    {
                        cmd.Parameters.AddWithValue("@start", start.Value);
                        cmd.Parameters.AddWithValue("@end", end.Value);
                    }

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvReport.DataSource = dt;
                    dgvReport.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    
                    // Calculate Total Revenue
                    decimal total = 0;
                    foreach(DataRow row in dt.Rows)
                    {
                        if(row["Price"] != DBNull.Value)
                        {
                            decimal price = 0;
                            if(decimal.TryParse(row["Price"].ToString(), out price))
                            {
                                total += price;
                            }
                        }
                    }
                    lblTotalRevenue.Text = "Rs. " + total.ToString("0.00");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading report: " + ex.Message);
            }
        }

        private void btnDownloadPDF_Click(object sender, EventArgs e)
        {
            if (dgvReport.Rows.Count == 0)
            {
                MessageBox.Show("No data to export!");
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "CSV File|*.csv";
            sfd.FileName = "Report_" + DateTime.Now.ToString("yyyyMMdd") + ".csv";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    StringBuilder sb = new StringBuilder();
                    
                    // Headers
                    for (int i = 0; i < dgvReport.Columns.Count; i++)
                    {
                        sb.Append(dgvReport.Columns[i].HeaderText + ",");
                    }
                    sb.AppendLine();

                    // Rows
                    for (int i = 0; i < dgvReport.Rows.Count; i++)
                    {
                        if (!dgvReport.Rows[i].IsNewRow)
                        {
                            for (int j = 0; j < dgvReport.Columns.Count; j++)
                            {
                                string cellVal = dgvReport.Rows[i].Cells[j].Value?.ToString().Replace(",", " ") ?? "";
                                sb.Append(cellVal + ",");
                            }
                            sb.AppendLine();
                        }
                    }

                    File.WriteAllText(sfd.FileName, sb.ToString());
                    MessageBox.Show("Report downloaded successfully as CSV!", "Success");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error downloading report: " + ex.Message);
                }
            }
        }
    }
}
'''

with open('MalkiTailorShop/Report.cs', 'w', encoding='utf-8-sig') as f:
    f.write(content)

print("Report.cs fully implemented!")
