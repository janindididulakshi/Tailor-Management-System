with open('MalkiTailorShop/Home.cs', 'r', encoding='utf-8-sig') as f:
    content = f.read()

prefix = '''using System;
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
'''

with open('MalkiTailorShop/Home.cs', 'w', encoding='utf-8-sig') as f:
    f.write(prefix + content)

print("Fixed Home.cs")
