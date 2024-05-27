using Microsoft.AspNetCore.Mvc;
using ST10187895POE.Models;

namespace ST10187895POE.Controllers
{
    public class UserController : Controller
    {
        public Usertbl userTable = new Usertbl();

        [HttpPost]
        public ActionResult SignUpUser(Usertbl users)
        {
            var result = userTable.insert_User(users);
            //                     ("cshtml","Folder")
            return RedirectToAction("Index", "Home");
        }
        public IActionResult Index()
        {
            return View(userTable);
        }

        //public IActionResult SignUp()
        //{
        //    return View();
        //}
    }
}
