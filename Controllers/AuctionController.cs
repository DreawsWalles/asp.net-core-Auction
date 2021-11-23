using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using project.DAL;
using project.Models;
using project.Models.Adress;
using project.Models.Product;
using project.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using project.asp.net.core.Models;

namespace project.Controllers
{
    public class AuctionController : Controller
    {
        AuctionContext dataBase;
        IUserAction userService;
        BiddingModel model = new BiddingModel();
        IWebHostEnvironment appEnvironment;
        IFileHistoryAction fileService;
        IProductModelAction productService;

        public AuctionController(AuctionContext context, IUserAction userService, IWebHostEnvironment appEnvironment, IFileHistoryAction fileService, IProductModelAction productService)
        {
            dataBase = context;
            this.userService = userService;
            this.appEnvironment = appEnvironment;
            this.fileService = fileService;
            this.productService = productService;
        }
        public IActionResult Index()
        {
            UserModel user = userService.Get(dataBase, User.Identity.Name);
            ICollection<AuctionModel> Auctions = new List<AuctionModel>();
            foreach (AuctionModel element in dataBase.Auctions)
                if(element.UserModelId == user.Id)
                    Auctions.Add(element);
            if (Auctions.Count > 0)
            {
                user.AuctionModels = Auctions;
                foreach (AuctionModel auction in Auctions)
                {
                    ICollection<ProductAuctionModel> products = new List<ProductAuctionModel>();
                    foreach (ProductAuctionModel element in dataBase.ProductAuctions)
                        if(element.AuctionModelId == auction.Id)
                            products.Add(element);
                    auction.AdressModel = dataBase.Adresses.FirstOrDefault(x => x.Id == auction.AdressModelId);
                    auction.ProductAuctionModels = products;
                }
            }
            fileService.Clear(dataBase, userService, User.Identity.Name);
            return View(user.AuctionModels);
        }
        public IActionResult AddAuction()
        {
            FileHistoryModel tmp = fileService.Get(dataBase, userService, User.Identity.Name);
            if (tmp != null)
                model.Path = tmp.Path;
            model.ProductModels = productService.GetCollection(dataBase, userService, User.Identity.Name);
            return View(model);
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
        public IActionResult AddAuction(BiddingModel model)
        {
            AuctionModel auction = new AuctionModel()
            {
                Name = model.Name,
                Comments = model.Comments,
                TypeProductModelId = model.Type,
                AdressModel = model.Adress,
                dateTime = model.Date,
                UserModelId = userService.Get(dataBase, User.Identity.Name).Id
            };
            FileHistoryModel fileHistory = fileService.Get(dataBase, userService, User.Identity.Name);
            if (fileHistory == null)
                auction.Path = _products[model.Type];
            else
                auction.Path = fileHistory.Path;
            dataBase.Auctions.Add(auction);
            dataBase.SaveChanges();
            int auctionId = dataBase.Auctions.Where(x => x.UserModelId == userService.Get(dataBase, User.Identity.Name).Id).ToList().Last().Id;
            ICollection<ProductModel> products = productService.GetCollection(dataBase, userService, User.Identity.Name);
            int i = 0;
            foreach(ProductModel element in products)
                if(element.Id == Convert.ToInt32(model.Products[i]))
                {
                    ProductAuctionModel tmp = new ProductAuctionModel()
                    {
                        AuctionModelId = auctionId,
                        UserModelBuyerId = userService.Get(dataBase, User.Identity.Name).Id,
                        ProductModelId = element.Id,
                    };
                    dataBase.ProductAuctions.Add(tmp);
                    TenderModel tender = new TenderModel()
                    {
                        AuctionModelId = auctionId,
                        Name = "Продажа лота: " + '\"' + element.Name + " \"",
                        Lot = tmp
                    };
                    dataBase.Tenders.Add(tender);
                    i++;
                }   
            dataBase.SaveChanges();
            return RedirectToAction("CreateTenders", "Tender");
        }

        [HttpPost]
        public async Task<IActionResult> AddFile(IFormFile uploadedFile, LotModel model)
        {
            if (uploadedFile != null)
                await fileService.Add(dataBase, userService, User.Identity.Name, uploadedFile, appEnvironment);
            return RedirectToAction("AddAuction");
        }

        public IActionResult RemoveAuction(int id)
        {
            return RedirectToAction("Index");
        }
    }
}
