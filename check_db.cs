using System;
using System.Data.SqlClient;

class Program {
    static void Main() {
        string conString = @""Data Source=DESKTOP-UAU0782\SQLEXPRESS; Initial Catalog=MalkiDB; Integrated Security=True"";
        try {
            using (SqlConnection con = new SqlConnection(conString)) {
                con.Open();
                SqlCommand cmd = new SqlCommand(""SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE='BASE TABLE'"", con);
                using (SqlDataReader reader = cmd.ExecuteReader()) {
                    while (reader.Read()) {
                        Console.WriteLine(reader.GetString(0));
                    }
                }
            }
        } catch (Exception ex) {
            Console.WriteLine(ex.Message);
        }
    }
}
