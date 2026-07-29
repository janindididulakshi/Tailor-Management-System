using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using MalkiTailorShop.DB_Connection;

namespace MalkiTailorShop
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            ResponsiveUIHelper.MakeResponsive(this);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = DBConnection.GetConnection())
                {
                    con.Open();
                    string query = "SELECT * FROM Users WHERE Username=@Username AND Password=@Password";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@Username", txtUsername.Text);
                        cmd.Parameters.AddWithValue("@Password", txtPassword.Text);

                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            sda.Fill(dt);

                            if (dt.Rows.Count > 0)
                            {
                                string username = dt.Rows[0]["Username"].ToString();
                                
                                if (username.ToLower() == "admin")
                                {
                                    Program.UserRole = "Admin";
                                    this.Hide();
                                    Home dash = new Home();
                                    dash.Show();
                                }
                                else
                                {
                                    Program.UserRole = "Tailor";
                                    this.Hide();
                                    TailerDashboard dash = new TailerDashboard();
                                    dash.Show();
                                }
                            }
                            else
                            {
                                MessageBox.Show("Invalid Username or Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void textBox1_TextChanged(object sender, EventArgs e) {}
        private void btnShowPassword_Click(object sender, EventArgs e) {}
        private void pictureBox1_Click(object sender, EventArgs e) {}
        private void Login_Load(object sender, EventArgs e) {}
        private void panel1_Paint(object sender, PaintEventArgs e) {}
    }
}
