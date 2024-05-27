
using System.Data.SqlClient;

namespace ST10187895POE.Models
{
    public class tblContactUsModel
    {
        public static string con_string = "ConnectionString.database.windows.net,1433;Initial Catalog=KhumaloCraft;Persist Security ;User ID=\\;Password=\\;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate;Connection Timeout=30;";

        public static SqlConnection con = new SqlConnection(con_string);

        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string phoneNum { get; set; }
        public string message { get; set; }

        public int insert_ContactUs(tblContactUsModel m)
        {
            try
            {
                string sql = "INSERT INTO ContactUs(firstname, lastname, email, phoneNum, message) VALUES(@firstName, @lastName, @email, @phoneNum, @message)";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@firstName", m.firstName);
                cmd.Parameters.AddWithValue("@lastName", m.lastName);
                cmd.Parameters.AddWithValue("@email", m.email);
                cmd.Parameters.AddWithValue("@phoneNum", m.phoneNum);
                cmd.Parameters.AddWithValue("@message", m.message);
                con.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                con.Close();
                return rowsAffected;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
    }
}

