using Microsoft.AspNetCore.Mvc;
using ST10187895POE.Models;

namespace ST10187895POE.Controllers
{
    public class ContactUsController : Controller
    {
        
        public tblContactUsModel contactUstbl = new tblContactUsModel();

        [HttpPost]

        public ActionResult ContactUs(tblContactUsModel tblContactUs)
        {
            var result = contactUstbl.insert_ContactUs(tblContactUs);
            return RedirectToAction("ContactUs", "Home");
        }

        [HttpGet]

        public ActionResult ContactUs()
        {
            return View(contactUstbl);
        }
    }
}
