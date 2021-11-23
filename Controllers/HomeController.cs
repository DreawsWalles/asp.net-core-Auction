using Microsoft.AspNetCore.Mvc;
using project.Models;
using System.Collections.Generic;
using System.Linq;
using project.DAL;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace project.Controllers
{
    public class HomeController : Controller
    {
        AuctionContext DataBase;
        public HomeController(AuctionContext context)
        {
            DataBase = context;
        }
        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
                ViewBag.Lauout = "~/Views/Shared/_LayoutMainPageLog.cshtml";
            else
                ViewBag.Lauout = "~/Views/Shared/_LayoutMainPageNotLog.cshtml";
            return View();
        }
    }
}
