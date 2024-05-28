using ST10187895POE.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace ST10187895POE.Controllers
{
    public class TransactionController : Controller
    { 
        
        //public Cart userCart = new Cart();
        //[HttpPost]
        //public ActionResult AddCartItems(Cart items)
        //{
        //    var result = userCart.Add_CartItems(items);
        //    //                     ("cshtml","Folder")
        //    return RedirectToAction("MyWork", "Home");
        //}
        //public IActionResult Index()
        //{
        //    return View();
        //}
        

        //private readonly Cart getItems;

        //public TransactionController(Cart find)
        //{
        //    getItems = find;
        //}

        //public IActionResult Cart()
        //{

        //    var CartItems = new Cart();
        //    return View();
        //}

        public ActionResult OrderItem(int userID, int productID)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(Products.con_string))
                {
                    string sql = "INSERT INTO ORDERS(userID, productID) VALUES (@userID, @productID)";

                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@userID", userID);
                        cmd.Parameters.AddWithValue("@productID", productID);
                        con.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();
                        con.Close();

                        if (rowsAffected > 0)
                        {
                            return RedirectToAction("MyWork", "Home");
                        }
                        else
                        {
                            return View("OrderFailed");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }
    }
}
