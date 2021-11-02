using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using project.DAL;
using project.Models;
using project.Models.Product;
using project.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace project.Controllers
{
    public class LotController : Controller
    {
        readonly AuctionContext DataBase;
        readonly IUserAction userService;
        LotModel modelLot = new LotModel();
        IWebHostEnvironment _appEnvironment;
        ISingletonPath path;

        public LotController(AuctionContext context, IUserAction userService, IWebHostEnvironment appEnvironment, ISingletonPath path)
        {
            DataBase = context;
            this.userService = userService;
            _appEnvironment = appEnvironment;
            this.path = path;
        }
        public IActionResult Index()
        {
            UserModel user = userService.Get(DataBase, User.Identity.Name);
            ICollection<ProductModel> products = new List<ProductModel>();
            foreach(ProductModel element in DataBase.Products)
                if(element.UserModelId == user.Id)
                    products.Add(element);
            if (products.Count > 0)
                user.Products = products;
            return View(user.Products);
        }

        [HttpGet]
        public IActionResult AddLot()
        {
            modelLot = new LotModel() { Path = path.Name };
            return View(modelLot);
        }

        private Dictionary<int, string> _products = new Dictionary<int, string>()
        {
            {1, "/image/car.svg" },
            {2, "/image/food.svg"},
            {3, "/image/jacket.svg"},
            {4, "/image/nedvizh.svg"},
            {5, "/image/culture.svg"},
            {6, "/image/tea.svg"}
        };

        [HttpPost]
        public IActionResult AddLot(LotModel model)
        {
            ProductModel tmp = new ProductModel() 
            { 
                Name = model.Name, 
                Comments = model.Comments, 
                IsBuy = false, Date = DateTime.Now, 
                UserModelId = userService.Get(DataBase, User.Identity.Name).Id, 
                TypeProductModelId = model.type
            };
            if (path.Name == null)
                tmp.Path = _products[model.type];
            else
                tmp.Path = path.Name;
            DataBase.Products.Add(tmp);
            DataBase.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> AddFile(IFormFile uploadedFile)
        {
            if (uploadedFile != null)
            {
                // путь к папке Files
                string path = "/image/" + uploadedFile.FileName;
                // сохраняем файл в папку Files в каталоге wwwroot
                using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                {
                    await uploadedFile.CopyToAsync(fileStream);
                }
                this.path.Name = path;
            }
            return RedirectToAction("AddLot");
        }
    }
}
