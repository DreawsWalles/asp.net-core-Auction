using Microsoft.AspNetCore.Mvc;
using project.DAL;
using project.Models.Person;
using System.Linq;

namespace project.Controllers
{
    public class SenderDetailsController : Controller
    {
        AuctionContext DataBase;
        public SenderDetailsController(AuctionContext context)
        {
            DataBase = context;
        }
        [HttpGet]
        public IActionResult AddDetails()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddDetails(SenderDetailsModel model)
        {
            if (ModelState.IsValid)
            {
                PersonModel person = DataBase.Persons.FirstOrDefault(u => u.Id == DataBase.Users.FirstOrDefault(i => i.Login == User.Identity.Name).PersonModelId);
                person.SenderDetails = model;
                DataBase.SaveChanges();
                return RedirectToAction("Index", "User");
            }
            return View();
        }
    }
}
