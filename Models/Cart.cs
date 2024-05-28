using ST10187895POE.Controllers;
using System.Data.SqlClient;

namespace ST10187895POE.Models
{
    public class Cart
    {
        public static string con_string = "Server=tcp:mikes-sql-23.database.windows.net,1433;Initial Catalog=KhumaloCraft;Persist Security Info=False;User ID=st10187895;Password=AbsisLowers82@;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        public static SqlConnection con = new SqlConnection(con_string);

        public string productName {  get; set; }
        public decimal productPrice { get; set; }
        public int Add_CartItems(Cart c)
        {
            try
            {
                
                string sql = "INSERT INTO PendingOrder(productName,prouctPrice) VALUES(@productName,@productPrice)";
                SqlCommand cmd = new SqlCommand(sql, con);
                    
                cmd.Parameters.AddWithValue("@productName", c.productName);
                cmd.Parameters.AddWithValue("@ProductPrice", c.productPrice);

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

        public static List<Cart> Get_CartItems()
        {
            List<Cart> CartItems = new List<Cart>();

            using (SqlConnection con = new SqlConnection(con_string))
            {
                string sql = "SELECT productName, productPrice FROM pendingOrder";
                SqlCommand cmd = new SqlCommand(sql, con);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Cart product = new Cart();
                    product.productName = reader["productName"].ToString();
                    product.productPrice = Convert.ToDecimal(reader["productPrice"]);

                    CartItems.Add(product);
                }
            }

            return CartItems;
        }
    }
}
