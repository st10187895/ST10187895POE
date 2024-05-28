using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ST10187895POE.Models;
using System.Diagnostics;

namespace ST10187895POE.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpContextAccessor  _httpContextAccessor; 
        public HomeController(ILogger<HomeController> logger, IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult AboutUs()
        {
            return View();
        }
        public IActionResult ContactUs()
        {
            return View();
        }

        public IActionResult MyWork()
        {
            List<Products> products = Products.Get_Products();

            int? userID = _httpContextAccessor.HttpContext.Session.GetInt32("UserID");

            ViewData["Products"] = products;
            ViewData["UserID"] = userID;
            return View();
        }
        
        public IActionResult SignUp()
        {
            return View();
        }
        public IActionResult Cart()
        {
            List<Cart> CartItems = Models.Cart.Get_CartItems();

            // Retrieve userID from session
            int? userID = _httpContextAccessor.HttpContext.Session.GetInt32("UserID");

            // Pass products and userID to the view
            ViewData["YourCart"] = CartItems;
            ViewData["UserID"] = userID;
            return View();
            
        }
        public IActionResult ProductsAdmin()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
