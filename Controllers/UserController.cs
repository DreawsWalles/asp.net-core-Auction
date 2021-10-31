using Microsoft.AspNetCore.Mvc;
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
using project.Models.Person;

namespace project.Controllers
{
    public class UserController : Controller
    {
        AuctionContext DataBase;
        UserModel user;
        public UserController(AuctionContext context)
        {
            DataBase = context;
        }
        [Authorize]
        public IActionResult Index()
        {
            user = DataBase.Users.FirstOrDefault(u => u.Login == User.Identity.Name);
            user.PersonModel = DataBase.Persons.FirstOrDefault(u => u.Id == user.PersonModelId);
            user.PersonModel.Adress = DataBase.Adresses.FirstOrDefault(u => u.Id == user.PersonModel.AdressModelID);
            user.PersonModel.RecipientDetailsModels = DataBase.RecipientDetails.FirstOrDefault(x => x.Id == user.PersonModel.RecipientDetailsModelId);
            user.PersonModel.SenderDetails = DataBase.SenderDetails.FirstOrDefault(x => x.Id == user.PersonModel.SenderDetailsModelId);
            return View(user);
        }
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditLogin(string Login)
        {
            string name = User.Identity.Name;
            UserModel tmp = DataBase.Users.FirstOrDefault(u => u.Login == Login);
            if ((tmp == null || tmp.Login == name) && !string.IsNullOrEmpty(Login))
            {
                await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                tmp.Login = Login;
                DataBase.SaveChanges();
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
            {
                UserModel tmp = DataBase.Users.FirstOrDefault(x => x.Login == User.Identity.Name);
                tmp.Password = password;
                DataBase.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public IActionResult EditName(string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                PersonModel tmp = DataBase.Persons.FirstOrDefault(x => x.Id == DataBase.Users.FirstOrDefault(y => y.Login == User.Identity.Name).PersonModelId);
                tmp.Name = name;
                DataBase.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public IActionResult EditSername(string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                PersonModel tmp = DataBase.Persons.FirstOrDefault(x => x.Id == DataBase.Users.FirstOrDefault(y => y.Login == User.Identity.Name).PersonModelId);
                tmp.Sername = name;
                DataBase.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public IActionResult EditPatronymic(string field)
        {
            if (!string.IsNullOrEmpty(field))
            {
                PersonModel tmp = DataBase.Persons.FirstOrDefault(x => x.Id == DataBase.Users.FirstOrDefault(y => y.Login == User.Identity.Name).PersonModelId);
                tmp.Patronymic = field;
                DataBase.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public IActionResult EditPhone(string field)
        {
            if (!string.IsNullOrEmpty(field))
            {
                PersonModel tmp = DataBase.Persons.FirstOrDefault(x => x.Id == DataBase.Users.FirstOrDefault(y => y.Login == User.Identity.Name).PersonModelId);
                tmp.Phone = field;
                DataBase.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public IActionResult EditEmail(string field)
        {
            if (!string.IsNullOrEmpty(field))
            {
                PersonModel tmp = DataBase.Persons.FirstOrDefault(x => x.Id == DataBase.Users.FirstOrDefault(y=> y.Login == User.Identity.Name).PersonModelId);
                tmp.Email = field;
                DataBase.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public IActionResult EditCountry(AdressModel model)
        {
            if (!string.IsNullOrEmpty(model.Country))
            {
                AdressModel tmp = DataBase.Adresses.FirstOrDefault(y => y.Id == DataBase.Persons.FirstOrDefault(u => u.Id == DataBase.Users.FirstOrDefault(x => x.Login == User.Identity.Name).PersonModelId).AdressModelID);
                tmp.Country = model.Country;
                DataBase.SaveChanges();

            }
            return RedirectToAction("Index");
        }
        public IActionResult EditCity(AdressModel model)
        {
            if (!string.IsNullOrEmpty(model.City))
            {
                AdressModel tmp = DataBase.Adresses.FirstOrDefault(y => y.Id == DataBase.Persons.FirstOrDefault(u => u.Id == DataBase.Users.FirstOrDefault(x => x.Login == User.Identity.Name).PersonModelId).AdressModelID);
                tmp.City = model.City;
                DataBase.SaveChanges();

            }
            return RedirectToAction("Index");
        }
        public IActionResult EditStreet(AdressModel model)
        {
            if (!string.IsNullOrEmpty(model.Street))
            {
                AdressModel tmp = DataBase.Adresses.FirstOrDefault(y => y.Id == DataBase.Persons.FirstOrDefault(u => u.Id == DataBase.Users.FirstOrDefault(x => x.Login == User.Identity.Name).PersonModelId).AdressModelID);
                tmp.Street = model.Street;
                DataBase.SaveChanges();

            }
            return RedirectToAction("Index");
        }
        public IActionResult EditPostIndex(AdressModel model)
        {
            AdressModel tmp = DataBase.Adresses.FirstOrDefault(y => y.Id == DataBase.Persons.FirstOrDefault(u => u.Id == DataBase.Users.FirstOrDefault(x => x.Login == User.Identity.Name).PersonModelId).AdressModelID);
            tmp.PostIndex = model.PostIndex;
            DataBase.SaveChanges();
            return RedirectToAction("Index");
        }


        public IActionResult EditNameBank(RecipientDetailsModel model)
        {
            if(!string.IsNullOrEmpty(model.Name))
            {
                RecipientDetailsModel tmp = DataBase.RecipientDetails.FirstOrDefault(y => y.Id == DataBase.Persons.FirstOrDefault(u => u.Id == DataBase.Users.FirstOrDefault(x => x.Login == User.Identity.Name).PersonModelId).RecipientDetailsModelId);
                tmp.Name = model.Name;
                DataBase.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public IActionResult EditINN(RecipientDetailsModel model)
        {
            RecipientDetailsModel tmp = DataBase.RecipientDetails.FirstOrDefault(y => y.Id == DataBase.Persons.FirstOrDefault(u => u.Id == DataBase.Users.FirstOrDefault(x => x.Login == User.Identity.Name).PersonModelId).RecipientDetailsModelId);
            tmp.INN = model.INN;
            DataBase.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult EditKPP(RecipientDetailsModel model)
        {
            RecipientDetailsModel tmp = DataBase.RecipientDetails.FirstOrDefault(y => y.Id == DataBase.Persons.FirstOrDefault(u => u.Id == DataBase.Users.FirstOrDefault(x => x.Login == User.Identity.Name).PersonModelId).RecipientDetailsModelId);
            tmp.KPP = model.KPP;
            DataBase.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult EditAccountNumber(RecipientDetailsModel model)
        {
            RecipientDetailsModel tmp = DataBase.RecipientDetails.FirstOrDefault(y => y.Id == DataBase.Persons.FirstOrDefault(u => u.Id == DataBase.Users.FirstOrDefault(x => x.Login == User.Identity.Name).PersonModelId).RecipientDetailsModelId);
            tmp.AccountNumber = model.AccountNumber;
            DataBase.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult EditBIK(RecipientDetailsModel model)
        {
            RecipientDetailsModel tmp = DataBase.RecipientDetails.FirstOrDefault(y => y.Id == DataBase.Persons.FirstOrDefault(u => u.Id == DataBase.Users.FirstOrDefault(x => x.Login == User.Identity.Name).PersonModelId).RecipientDetailsModelId);
            tmp.BIK = model.BIK;
            DataBase.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult EditCorrespondentAccount(RecipientDetailsModel model)
        {
            RecipientDetailsModel tmp = DataBase.RecipientDetails.FirstOrDefault(y => y.Id == DataBase.Persons.FirstOrDefault(u => u.Id == DataBase.Users.FirstOrDefault(x => x.Login == User.Identity.Name).PersonModelId).RecipientDetailsModelId);
            tmp.CorrespondentAccount = model.CorrespondentAccount;
            DataBase.SaveChanges();
            return RedirectToAction("Index");
        }


        public IActionResult EditNameCredit(SenderDetailsModel model)
        {
            SenderDetailsModel tmp = DataBase.SenderDetails.FirstOrDefault(y => y.Id == DataBase.Persons.FirstOrDefault(u => u.Id == DataBase.Users.FirstOrDefault(x => x.Login == User.Identity.Name).PersonModelId).SenderDetailsModelId);
            tmp.Name = model.Name;
            DataBase.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult EditSernameCredit(SenderDetailsModel model)
        {
            SenderDetailsModel tmp = DataBase.SenderDetails.FirstOrDefault(y => y.Id == DataBase.Persons.FirstOrDefault(u => u.Id == DataBase.Users.FirstOrDefault(x => x.Login == User.Identity.Name).PersonModelId).SenderDetailsModelId);
            tmp.Sername = model.Sername;
            DataBase.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult EditNumberCart(SenderDetailsModel model)
        {
            SenderDetailsModel tmp = DataBase.SenderDetails.FirstOrDefault(y => y.Id == DataBase.Persons.FirstOrDefault(u => u.Id == DataBase.Users.FirstOrDefault(x => x.Login == User.Identity.Name).PersonModelId).SenderDetailsModelId);
            tmp.NumberCart = model.NumberCart;
            DataBase.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult EditCVC(SenderDetailsModel model)
        {
            SenderDetailsModel tmp = DataBase.SenderDetails.FirstOrDefault(y => y.Id == DataBase.Persons.FirstOrDefault(u => u.Id == DataBase.Users.FirstOrDefault(x => x.Login == User.Identity.Name).PersonModelId).SenderDetailsModelId);
            tmp.CVC = model.CVC;
            DataBase.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult EditDatetime(SenderDetailsModel model)
        {
            SenderDetailsModel tmp = DataBase.SenderDetails.FirstOrDefault(y => y.Id == DataBase.Persons.FirstOrDefault(u => u.Id == DataBase.Users.FirstOrDefault(x => x.Login == User.Identity.Name).PersonModelId).SenderDetailsModelId);
            tmp.dateTime = model.dateTime;
            DataBase.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
