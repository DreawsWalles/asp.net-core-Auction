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
            ICollection<ProductModel> products = productService.GetCollection(DataBase, userService, User.Identity.Name);
            if (products.Count > 0)
                user.Products = products;

            fileService.Clear(DataBase, userService, User.Identity.Name);
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

        [HttpPost]
        public IActionResult AddLot(LotModel model)
        {
            productService.Add(DataBase, fileService, userService, User.Identity.Name, model);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> AddFile(IFormFile uploadedFile, LotModel model)
        {
            if (uploadedFile != null)
                await fileService.Add(DataBase, userService, User.Identity.Name, uploadedFile, appEnvironment);
            return RedirectToAction("AddLot");
        }
        public IActionResult EditLot(int id)
        {
            LotModel model;
            if (id == 0)
            {
                FileHistoryModel file = fileService.Get(DataBase, userService, User.Identity.Name);
                ProductModel product = productService.Get(DataBase, file.ModelId);
                model = new LotModel()
                {
                    Id = product.Id,
                    Name= product.Name,
                    type = (int)product.TypeProductModelId,
                    Comments= product.Comments,
                    Path = file.Path
                };
            }
            else
            {
                ProductModel product = productService.Get(DataBase, id);
                model = new LotModel()
                {
                    Id = product.Id,
                    Name = product.Name,
                    type = (int)product.TypeProductModelId,
                    Comments = product.Comments,
                    Path = product.Path
                };
            }
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
