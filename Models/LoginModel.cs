using System.Data.SqlClient;
using System.Xml.Linq;
namespace ST10187895POE.Models
{
    public class LoginModel
    {
        public static string con_string = "Server=tcp:mikes-sql-23.database.windows.net,1433;Initial Catalog=KhumaloCraft;Persist Security Info=False;User ID=st10187895;Password=AbsisLowers82@;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        public int findUser(string email, string password)
        {
            int userId = -1;
            using (SqlConnection connection = new SqlConnection(con_string))
            {
                string sql = "SELECT userID FROM USERS WHERE userEmail = @Email AND userPassword = @password";
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@password", password);
                try
                {
                    connection.Open();
                    object result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        userId = Convert.ToInt32(result);
                    }
                }
                catch (Exception ex)
                {                   
                    throw ex;
                }
            }
            return userId;
        }
    }
}

