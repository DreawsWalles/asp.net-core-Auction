using Microsoft.AspNetCore.Mvc;
using project.DAL;

namespace project.Controllers
{
    public class TenderController : Controller
    {
        AuctionContext dataBase;
        public TenderController(AuctionContext context)
        {
            dataBase = context;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
