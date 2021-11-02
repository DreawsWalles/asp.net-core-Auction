using Microsoft.AspNetCore.Mvc;
using project.DAL;
using project.Models.Adress;
using project.Models.Person;
using project.Services.Interfaces;
using System.Linq;

namespace project.Controllers
{
    public class AdressController:Controller
    {
        readonly AuctionContext DataBase;
        readonly IPersonAction personService;
        readonly IUserAction userService;
        public AdressController(AuctionContext context, IUserAction userService, IPersonAction personService)
        {
            DataBase = context;
            this.personService = personService;
            this.userService = userService;
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
                personService.Edit(DataBase, userService, User.Identity.Name, new PersonModel() { Adress = adress}, "Adress");
                return RedirectToAction("Index", "User");
            }
            return View();
        }
    }
}
