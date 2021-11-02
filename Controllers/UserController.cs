﻿using Microsoft.AspNetCore.Mvc;
using project.DAL;
using project.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNet.Identity;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using project.Models.Person;
using project.Models.Adress;
using System;
using project.Services.Interfaces;
using project.Models.Product;

namespace project.Controllers
{
    public class UserController : Controller
    {
        readonly AuctionContext DataBase;
        readonly IUserAction userService;
        readonly IPersonAction personService;
        readonly IUserAdressAction adressService;
        readonly IRecipientDetailsAction bankDetailsService;
        readonly ISenderDetailsAction creditDetalisService;
        public UserController(AuctionContext context, IUserAction userService, IPersonAction personService, IUserAdressAction adressService, IRecipientDetailsAction bankDetailsService, ISenderDetailsAction creditDetalisService)
        {
            DataBase = context;
            this.userService = userService;
            this.personService = personService;
            this.adressService = adressService;
            this.bankDetailsService = bankDetailsService;
            this.creditDetalisService = creditDetalisService;
        }
        [Authorize]
        public IActionResult Index()
        {
            UserModel user = userService.Get(DataBase, User.Identity.Name);
            user.PersonModel = personService.Get(DataBase, userService, User.Identity.Name);
            user.PersonModel.Adress = adressService.Get(DataBase, personService, userService, User.Identity.Name);
            user.PersonModel.RecipientDetailsModels = bankDetailsService.Get(DataBase, personService, userService, User.Identity.Name);
            user.PersonModel.SenderDetails = creditDetalisService.Get(DataBase, personService, userService, User.Identity.Name) ;
            return View(user);
        }
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditLogin(string Login)
        {
            UserModel tmp = userService.Get(DataBase, User.Identity.Name);
            if ((tmp == null || tmp.Login == User.Identity.Name) && !string.IsNullOrEmpty(Login))
            {
                await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                userService.Edit(DataBase, User.Identity.Name, new UserModel() { Login = Login }, "Login");
                await Authenticate(Login);
            }
            return RedirectToAction("Index");
        }
        private async Task Authenticate(string userName)
        {
            // создаем один claim
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userName)
            };
            // создаем объект ClaimsIdentity
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            // установка аутентификационных куки
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        public ActionResult EditPerson()
        {
            return PartialView("_EditPerson");
        }
        public ActionResult AddAdress()
        {
            return PartialView("_AddAdress");
        }
        public ActionResult AddBankDetails()
        {
            return PartialView("_AddBankDetails");
        }
        public ActionResult AddCreditDetails()
        {
            return PartialView("_AddCreditDetails");
        }


        public async Task<IActionResult> Logout()
        {
            return RedirectToAction("Index", "Home");
        }


        public IActionResult EditPassword(string password)
        {
            if (!string.IsNullOrEmpty(password))
                userService.Edit(DataBase, User.Identity.Name, new UserModel() { Password = password }, "Password");
            return RedirectToAction("Index");
        }
        public IActionResult EditName(string name)
        {
            if (!string.IsNullOrEmpty(name))
                personService.Edit(DataBase, userService, User.Identity.Name, new PersonModel() { Name = name}, "Name");
            return RedirectToAction("Index");
        }
        public IActionResult EditSername(string name)
        {
            if (!string.IsNullOrEmpty(name))
                personService.Edit(DataBase, userService, User.Identity.Name, new PersonModel() { Sername = name}, "Sername");
            return RedirectToAction("Index");
        }
        public IActionResult EditPatronymic(string field)
        {
            if (!string.IsNullOrEmpty(field))
                personService.Edit(DataBase, userService, User.Identity.Name, new PersonModel() { Patronymic = field}, "Patronymic");
            return RedirectToAction("Index");
        }
        public IActionResult EditPhone(string field)
        {
            if (!string.IsNullOrEmpty(field))
                personService.Edit(DataBase, userService, User.Identity.Name, new PersonModel() { Phone = field}, "Phone");
            return RedirectToAction("Index");
        }
        public IActionResult EditEmail(string field)
        {
            if (!string.IsNullOrEmpty(field))
                personService.Edit(DataBase, userService, User.Identity.Name, new PersonModel() { Email = field}, "Email");
            return RedirectToAction("Index");
        }

        public IActionResult EditCountry(AdressModel model)
        {
            if (!string.IsNullOrEmpty(model.Country))
                adressService.Edit(DataBase, personService, userService, User.Identity.Name, model, "Country");
            return RedirectToAction("Index");
        }
        public IActionResult EditCity(AdressModel model)
        {
            if (!string.IsNullOrEmpty(model.City))
                adressService.Edit(DataBase, personService, userService, User.Identity.Name, model, "City");
            return RedirectToAction("Index");
        }
        public IActionResult EditStreet(AdressModel model)
        {
            if (!string.IsNullOrEmpty(model.Street))
                adressService.Edit(DataBase, personService, userService, User.Identity.Name, model, "Street");
            return RedirectToAction("Index");
        }
        public IActionResult EditPostIndex(AdressModel model)
        {
            adressService.Edit(DataBase, personService, userService, User.Identity.Name, model, "PostIndex");
            return RedirectToAction("Index");
        }


        public IActionResult EditNameBank(RecipientDetailsModel model)
        {
            if (!string.IsNullOrEmpty(model.Name))
                bankDetailsService.Edit(DataBase, personService, userService, User.Identity.Name, model, "Name");
            return RedirectToAction("Index");
        }
        public IActionResult EditINN(RecipientDetailsModel model)
        {
            bankDetailsService.Edit(DataBase, personService, userService, User.Identity.Name, model, "INN");
            return RedirectToAction("Index");
        }
        public IActionResult EditKPP(RecipientDetailsModel model)
        {
            bankDetailsService.Edit(DataBase, personService, userService, User.Identity.Name, model, "KPP");
            return RedirectToAction("Index");
        }
        public IActionResult EditAccountNumber(RecipientDetailsModel model)
        {
            bankDetailsService.Edit(DataBase, personService, userService, User.Identity.Name, model, "AccountNumber");
            return RedirectToAction("Index");
        }
        public IActionResult EditBIK(RecipientDetailsModel model)
        {
            bankDetailsService.Edit(DataBase, personService, userService, User.Identity.Name, model, "BIK");
            return RedirectToAction("Index");
        }
        public IActionResult EditCorrespondentAccount(RecipientDetailsModel model)
        {
            bankDetailsService.Edit(DataBase, personService, userService, User.Identity.Name, model, "CorrespondentAccount");
            return RedirectToAction("Index");
        }


        public IActionResult EditNameCredit(SenderDetailsModel model)
        {
            creditDetalisService.Edit(DataBase, personService, userService, User.Identity.Name, model, "Name");
            return RedirectToAction("Index");
        }
        public IActionResult EditSernameCredit(SenderDetailsModel model)
        {
            creditDetalisService.Edit(DataBase, personService, userService, User.Identity.Name, model, "Sername");
            return RedirectToAction("Index");
        }
        public IActionResult EditNumberCart(SenderDetailsModel model)
        {
            creditDetalisService.Edit(DataBase, personService, userService, User.Identity.Name, model, "NumberCart");
            return RedirectToAction("Index");
        }
        public IActionResult EditCVC(SenderDetailsModel model)
        {
            creditDetalisService.Edit(DataBase, personService, userService, User.Identity.Name, model, "CVC");
            return RedirectToAction("Index");
        }
        public IActionResult EditDatetime(SenderDetailsModel model)
        {
            creditDetalisService.Edit(DataBase, personService, userService, User.Identity.Name, model, "dateTime");
            return RedirectToAction("Index");
        }

        public ActionResult RemoveAdress()
        {
            adressService.Delete(DataBase, personService, userService, User.Identity.Name);
            return RedirectToAction("Index");
        }
        public ActionResult RemoveBankDetails()
        {
            bankDetailsService.Delete(DataBase, personService, userService, User.Identity.Name);
            return RedirectToAction("Index");
        }
        public ActionResult CreditDetails()
        {
            creditDetalisService.Delete(DataBase, personService, userService, User.Identity.Name);
            return RedirectToAction("Index");
        }

        public IActionResult Back()
        {
            return RedirectToAction("Index");
        }

        public IActionResult Lot()
        {
            return RedirectToAction("Index", "Lot");
        }
    }
}
