using System.Data;
using System.Data.SqlClient;

namespace ST10187895POE.Models
{
    public class Products
    {
        public static string con_string = "Server=tcp:mikes-sql-23.database.windows.net,1433;Initial Catalog=KhumaloCraft;Persist Security Info=False;User ID=st10187895;Password=AbsisLowers82@;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        public static SqlConnection con = new SqlConnection(con_string);
        public int productID {  get; set; }
        public string productName { get; set; }
        public decimal productPrice { get; set; }
        public int unitsAvailable { get; set; }
        public string category {  get; set; }


        public int add_products(Products p)
        {
            try
            {
                string sql = "INSERT INTO PRODUCTS(productName, productPrice, unitsAvailable, category) VALUES(@productName, @productPrice, @unitsAvailable, @category)";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@productName", p.productName);
                cmd.Parameters.AddWithValue("@productPrice", p.productPrice);
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

        public static List<Products> Get_Products()
        {
            List<Products> products = new List<Products>();

            using (SqlConnection con = new SqlConnection(con_string))
            {
                string sql = "SELECT productID, productName, productPrice, category, unitsAvailable FROM PRODUCTS";
                SqlCommand cmd = new SqlCommand(sql, con);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Products product = new Products();
                    product.productID = Convert.ToInt32(reader["productID"]);
                    product.productName = reader["productName"].ToString();
                    product.productPrice = Convert.ToDecimal(reader["productPrice"]);
                    product.unitsAvailable = Convert.ToInt32(reader["unitsAvailable"]);
                    product.category = reader["category"].ToString();

                    products.Add(product);
                }
            }

            return products;
        }
    }
}
