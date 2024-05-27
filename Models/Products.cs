using System.Data.SqlClient;

namespace ST10187895POE.Models
{
    public class Products
    {
        public static string con_string = "Initial Catalog=KhumaloCraft;Persist Security Info=False;User ID=\\;Password=\\;;Connection Timeout=30;";

        public static SqlConnection con = new SqlConnection(con_string);
        public string productName { get; set; }
        public decimal ProductPrice { get; set; }
        public int unitsAvailable { get; set; }
        public string category {  get; set; }


        public int add_products(Products p)
        {
            try
            {
                string sql = "INSERT INTO PRODUCTS(productName, productPrice, unitsAvailable, category) VALUES(@productName, @productPrice, @unitsAvailable, @category)";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@productName", p.productName);
                cmd.Parameters.AddWithValue("@productPrice", p.ProductPrice);
                cmd.Parameters.AddWithValue("@unitsAvailable", p.unitsAvailable);
                cmd.Parameters.AddWithValue("@category", p.category);
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
