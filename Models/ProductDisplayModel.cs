

using Microsoft.AspNetCore.Mvc;
using System.Data.Entity;
using System.Data.SqlClient;

namespace ST10187895POE.Models
{
    public class ProductDisplayModel
    {
        public int productID { get; set; }
        public string productName { get; set; }
        public decimal productPrice { get; set; }
        public string category { get; set; }
        public int unitsAvailable { get; set; }

        public ProductDisplayModel() { }

        public ProductDisplayModel(int id, string name, decimal price, string productCategory, int availability)
        {
            productID = id;
            productName = name;
            productPrice = price;
            category = productCategory;
            unitsAvailable = availability;
        }

        public static List<ProductDisplayModel> Select_Products()
        {
            List<ProductDisplayModel> products = new List<ProductDisplayModel>();

            string con_string = "Server=tcp:mikes-sql-23.database.windows.net,1433;Initial Catalog=KhumaloCraft;Persist Security Info=False;User ID=st10187895;Password=AbsisLowers82@;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            using (SqlConnection con = new SqlConnection(con_string))
            {
                string sql = "SELECT productID, productName, productPrice, category, unitsAvailable FROM PRODUCTS";
                SqlCommand cmd = new SqlCommand(sql, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        ProductDisplayModel product = new ProductDisplayModel();
                        product.productID = Convert.ToInt32(reader["productID"]);
                        product.productName = Convert.ToString(reader["productName"]);
                        product.productPrice = Convert.ToDecimal(reader["productPrice"]);
                        product.category = Convert.ToString(reader["category"]);
                        product.unitsAvailable = Convert.ToInt32(reader["unitsAvailable"]);
                        products.Add(product);
                    }
                reader.Close();
            }
            return products;
        }
        
    }
}
