using Microsoft.AspNetCore.Mvc;
using project.DAL;
using project.Models;
using project.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace project.Controllers
{
    public class TenderController : Controller
    {
        AuctionContext dataBase;
        IUserAction userService;
        IProductModelAction productService;
        IPersonAction personService;
        public TenderController(AuctionContext context, IUserAction userService, IProductModelAction productService, IPersonAction personService)
        {
            dataBase = context;
            this.userService = userService;
            this.productService = productService;
            this.personService = personService;
        }
        public IActionResult CreateTenders()
        {
            int auctionId = dataBase.Auctions.Where(x => x.UserModelId == userService.Get(dataBase, User.Identity.Name).Id).ToList().Last().Id;
            List<TenderModel> tenders = dataBase.Tenders.Where(x => x.AuctionModelId == auctionId).ToList();
            foreach (TenderModel tender in tenders)
            {
                tender.Lot = dataBase.ProductAuctions.FirstOrDefault(x => x.Id == tender.LotId);
                tender.Lot.ProductModel = productService.Get(dataBase,(int)tender.Lot.ProductModelId);
            }
            List<UserModel> friends = userService.GetFriends(dataBase, User.Identity.Name).ToList();
            foreach (UserModel element in friends)
                element.PersonModel = personService.Get(dataBase, userService, element.Login);
            ViewData["Friend"] = friends;
            int userId = userService.Get(dataBase, User.Identity.Name).Id;
            List<UserModel> users = dataBase.Users.Where(x => x.Id != userId).ToList();
            foreach(UserModel element in users)
                element.PersonModel = personService.Get(dataBase, userService, element.Login);
            ViewData["Users"] = users;
            return View(tenders);
        }
        public IActionResult EditName(string model, int id)
        {
            TenderModel tender = dataBase.Tenders.FirstOrDefault(x => x.Id == id);
            tender.Name = model;
            dataBase.SaveChanges();
            return RedirectToAction("CreateTenders");
        }
        public IActionResult ChoiceModerator(string model, int id)
        {
            TenderModel tender = dataBase.Tenders.FirstOrDefault(x => x.Id==id);
            if (model != null)
                tender.ModeratorId = Convert.ToInt32(model);
            else
                tender.ModeratorId = null;
            dataBase.SaveChanges();
            return RedirectToAction("CreateTenders");
        }
    }
}
