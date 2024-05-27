using Microsoft.AspNetCore.Mvc;
using ST10187895POE.Models;
using System.Collections.Generic;

namespace ST10187895POE.Controllers
{
    public class ProductController : Controller
    {
        public Products productTable = new Products();

        [HttpPost]
        public ActionResult AddProductsItems(Products items)
        {
            var result = productTable.add_products(items);
            //                     ("cshtml","Folder")
            return RedirectToAction("ProductsAdmin", "Home");
        }
        public IActionResult Index()
        {
            return View(productTable);
        }


        private readonly Products getProducts;

        public ProductController(Products find)
        {
            getProducts = find;   
        }

        public IActionResult MyWork()
        {
           
            var productsInfo = new Products();
            return View();
        }
    }
}
