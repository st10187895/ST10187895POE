using System.Data.SqlClient;

namespace ST10187895POE.Models
{
    public class Usertbl
    {
        public static string con_string = "Server=tcp:mikes-sql-23.database.windows.net,1433;Initial Catalog=KhumaloCraft;Persist Security Info=False;User ID=st10187895;Password=AbsisLowers82@;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        public static SqlConnection con = new SqlConnection(con_string);
        public string name {  get; set; }  
        public string surname { get; set; } 
        public string email { get; set; }
        public string password { get; set; }

        public int insert_User(Usertbl m)
        {
            try
            {
                string sql = "INSERT INTO USERS(userName, userSurname, userEmail, userPassword) VALUES(@name, @surname, @email, @password)";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@name", m.name);
                cmd.Parameters.AddWithValue("@surname", m.surname);
                cmd.Parameters.AddWithValue("@email", m.email);
                cmd.Parameters.AddWithValue("@password", m.password);
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
