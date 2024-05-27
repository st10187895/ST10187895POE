using ST10187895POE.Models;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace ST10187895POE.Controllers
{
    public class LoginController : Controller
    {

        private readonly LoginModel Login;

        public LoginController()
        {
            Login = new LoginModel();
        }

        [HttpPost]
        public ActionResult ValidateUser(string email, string password)
        {
            var loginModel = new LoginModel();
            int userID = loginModel.findUser(email, password);
            if (userID != -1)
            {
                // Store userID in session
                HttpContext.Session.SetInt32("UserID", userID);

                
                return RedirectToAction("Index", "Home");
            }
            else
            {
                // User not found, handle accordingly (e.g., show error message)
                return View("LoginFailed");
            }
        }
    }
}
