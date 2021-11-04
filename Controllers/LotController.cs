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
        IWebHostEnvironment appEnvironment;
        IFileHistoryAction fileService;
        IProductModelAction productService;

        public LotController(AuctionContext context, IUserAction userService, IWebHostEnvironment appEnvironment, IFileHistoryAction fileService, IProductModelAction productService)
        {
            DataBase = context;
            this.userService = userService;
            this.appEnvironment = appEnvironment;
            this.fileService = fileService;
            this.productService = productService;
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
            fileService.Clear(DataBase, userService, User.Identity.Name);
            DataBase.SaveChanges();
            return View(user.Products);
        }

        [HttpGet]
        public IActionResult AddLot()
        {
            FileHistoryModel tmp = fileService.Get(DataBase, userService, User.Identity.Name);
            if (tmp != null)
                modelLot.Path = tmp.Path;
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
            productService.Add(DataBase, fileService, userService, User.Identity.Name, model);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> AddFile(IFormFile uploadedFile)
        {
            if (uploadedFile != null)
                await fileService.Add(DataBase, userService, User.Identity.Name, uploadedFile, appEnvironment);
            return RedirectToAction("AddLot");
        }
        public IActionResult EditLot(int id)
        {
            int Id = 0;
            string path = null;
            UserModel user = userService.Get(DataBase, User.Identity.Name);
            foreach (FileHistoryModel element in DataBase.FileHistory)
                if (element.UserModelId == user.Id)
                {
                    Id = element.ModelId;
                    path = element.Path;
                }
            if (Id == 0)
                Id = id;
            ProductModel tmp = DataBase.Products.FirstOrDefault(x => x.Id == Id);
            LotModel model = new LotModel()
            {
                Id = tmp.Id,
                Name = tmp.Name,
                type = (int)tmp.TypeProductModelId,
                Comments = tmp.Comments,
            };
            if (path == null)
                model.Path = tmp.Path;
            else
                model.Path = path;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditFile(IFormFile uploadedFile, int id)
        {
            if (uploadedFile != null)
                await fileService.Add(DataBase, userService, User.Identity.Name, uploadedFile, appEnvironment, id);
            return RedirectToAction("EditLot");
        }

        [HttpPost]
        public IActionResult LotEdit(LotModel model)
        {
            if(ModelState.IsValid)
            {
                productService.Edit(DataBase, fileService, userService, User.Identity.Name, model);
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult RemoveLot(int id)
        {
            productService.Remove(DataBase, id);
            return RedirectToAction("Index");
        }
    }
}
