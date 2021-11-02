using Microsoft.AspNetCore.Mvc;
using project.DAL;
using project.Models.Person;
using project.Services.Interfaces;
using System.Linq;

namespace project.Controllers
{
    public class RecipientDetailsController : Controller
    {
        readonly AuctionContext DataBase;
        readonly IUserAction userService;
        readonly IPersonAction personService;
        public RecipientDetailsController(AuctionContext context, IUserAction userService, IPersonAction personService)
        {
            DataBase = context;
            this.userService = userService;
            this.personService = personService;
        }

        [HttpGet]
        public IActionResult AddDetails()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddDetails(RecipientDetailsModel model)
        {
            if (ModelState.IsValid)
            {
                personService.Edit(DataBase, userService, User.Identity.Name, new PersonModel() { RecipientDetailsModels = model}, "RecipientDetails");
                return RedirectToAction("Index", "User");
            }
            return View();
        }
    }
}
