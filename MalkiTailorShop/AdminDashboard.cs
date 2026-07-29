using System;
using System.Windows.Forms;

namespace MalkiTailorShop
{
    public partial class AdminDashboard : Form
    {
        public AdminDashboard()
        {
            InitializeComponent();
            ResponsiveUIHelper.MakeResponsive(this);
        }
        
        private void Dashboard_Load(object sender, EventArgs e) {}
    }
}