using Microsoft.AspNetCore.Mvc;
using project.DAL;
using project.Models;
using project.Models.Product;
using project.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace project.asp.net.core.Controllers
{
    public class SinglePageController : Controller
    {
        private readonly AuctionContext dataBase;
        private readonly IProductModelAction productService;
        private readonly IUserAction userService;
        private readonly IPersonAction personService;
        public SinglePageController(AuctionContext context, IUserAction userService, IProductModelAction productService, IPersonAction personService)
        {
            dataBase = context;
            this.productService = productService;
            this.userService = userService;
            this.personService = personService;
        }
        public IActionResult ShowLot(int id)
        {
            ProductModel model = productService.Get(dataBase, userService, User.Identity.Name, id);
            model.User.PersonModel = personService.Get(dataBase, userService, User.Identity.Name);
            return View(model);
        }
        public IActionResult ShowAccount(int id)
        {
            int myId = userService.Get(dataBase, User.Identity.Name).Id;
            UserModel model = dataBase.Users.FirstOrDefault(x=> x.Id == id);
            model.PersonModel = dataBase.Persons.FirstOrDefault(x=> x.Id == model.PersonModelId);
            ViewBag.FriendShip = dataBase.Friends.FirstOrDefault(x=> (x.FriendOneId == id && x.FriendTwoId == myId) || (x.FriendOneId == myId && x.FriendTwoId == id));
            return View(model);
        }
        public IActionResult AcceptFriendship(int id)
        {
            int userId = userService.Get(dataBase, User.Identity.Name).Id;
            FriendsModel model = dataBase.Friends.FirstOrDefault(x => (x.FriendOneId == userId && x.FriendTwoId == id) || (x.FriendOneId == id && x.FriendTwoId == userId));
            model.status = 3;
            dataBase.SaveChanges();
            return RedirectToAction("ShowAccount", new { id = id });
        }
        public IActionResult DeclineFrendship(int id)
        {
            int userId = userService.Get(dataBase, User.Identity.Name).Id;
            FriendsModel model = dataBase.Friends.FirstOrDefault(x => (x.FriendOneId == userId && x.FriendTwoId == id) || (x.FriendOneId == id && x.FriendTwoId == userId));
            if (model.FriendTwoId == id)
                dataBase.Friends.Remove(model);
            else
                model.status = 2;
            dataBase.SaveChanges();
            return RedirectToAction("ShowAccount", new { id = id });
        }
        public IActionResult AddFriendship(int id)
        {
            int userId = userService.Get(dataBase, User.Identity.Name).Id;
            FriendsModel model = new FriendsModel()
            {
                FriendOneId = userId,
                FriendTwoId = id,
                status = 1
            };
            dataBase.Friends.Add(model);
            dataBase.SaveChanges();
            return RedirectToAction("ShowAccount", new { id = id });
        }
        public IActionResult RemoveFriendship(int id)
        {
            int userId = userService.Get(dataBase, User.Identity.Name).Id;
            FriendsModel model = dataBase.Friends.FirstOrDefault(x => (x.FriendOneId == userId && x.FriendTwoId == id) || (x.FriendOneId == id && x.FriendTwoId == userId));
            if (model.FriendOneId == userId && model.FriendTwoId == id)
            {
                model.FriendOneId = id;
                model.FriendTwoId = userId;
            }
            else
            {
                model.FriendOneId = userId;
                model.FriendTwoId = id;
            }
            model.status = 2;
            dataBase.SaveChanges();
            return RedirectToAction("ShowAccount", new {id = id});
        }
    }
}
