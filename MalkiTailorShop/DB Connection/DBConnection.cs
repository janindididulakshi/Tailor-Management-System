using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace MalkiTailorShop.DB_Connection
{
    class DBConnection
    {
        public static SqlConnection GetConnection()
        {
            SqlConnection con = new SqlConnection(
            @"Data Source=(LocalDB)\MSSQLLocalDB;
              Initial Catalog=MalkiDB;
              Integrated Security=True");

            return con;
        }
    }
}

