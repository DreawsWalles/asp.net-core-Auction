using Microsoft.AspNetCore.Mvc;
using project.Models;
using System.Collections.Generic;
using System.Linq;
using project.DAL;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using project.Models.Person;
using System;
using project.Services.Interfaces;

namespace project.Controllers
{
    public class AccountController : Controller
    {
        AuctionContext DataBase;
        IUserAction userService;
        public AccountController(AuctionContext DataBase, IUserAction userService)
        {
            this.DataBase = DataBase;
            this.userService = userService;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        int Hash(string word)
        {
            int asciisum = 0;
            int tmp;
            for (int i = 0; i < word.Length; i++)
            {
                asciisum *= 199;
                tmp = word[i];
                asciisum += Math.Abs(tmp);
                asciisum %= 4049;
            }
            return asciisum % 10000;
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model)
        {
            UserModel user = userService.Get(DataBase, model);
            if (user != null)
            {
                await Authenticate(model.Login);
                return RedirectToAction("Index", "User");
            }
            ModelState.AddModelError("", "Неверный логин и(или) пароль");
            return View(model);
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
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }        

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                UserModel user = userService.Get(DataBase, model.Login);
                if (user == null)
                {
                    userService.Add(DataBase, model);
                    await Authenticate(model.Login);
                    return RedirectToAction("Index", "User");
                }
                ModelState.AddModelError("", "Пользователь с данным логином уже существует");
            }
            return View(model);
        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
        [AcceptVerbs("GET", "POST")]
        public JsonResult VerifyLogin(string Login)
        {
            if (string.IsNullOrEmpty(Login))
                return Json("Данное поле обязательно к заполнению");
            UserModel user = DataBase.Users.FirstOrDefault(u => u.Login == Login);
            if (user != null)
                return Json("Пользователь с данным логином уже существует");
            return Json(true);
        }
    }
}
