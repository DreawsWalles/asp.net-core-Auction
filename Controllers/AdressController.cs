using Microsoft.AspNetCore.Mvc;
using project.DAL;
using project.Models.Adress;
using project.Models.Person;
using System.Linq;

namespace project.Controllers
{
    public class AdressController:Controller
    {
        AuctionContext DataBase;
        public AdressController(AuctionContext context)
        {
            DataBase = context;
        }
        [HttpGet]
        public IActionResult AddAdress()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddAdress(AdressModel adress)
        {
            if (ModelState.IsValid)
            {
                PersonModel person = DataBase.Persons.FirstOrDefault(u => u.Id == DataBase.Users.FirstOrDefault(i=> i.Login == User.Identity.Name).PersonModelId);
                person.Adress = adress;
                DataBase.SaveChanges();
                return RedirectToAction("Index", "User");
            }
            return View();
        }
    }
}
