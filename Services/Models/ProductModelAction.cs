using project.DAL;
using project.Models;
using project.Models.Product;
using project.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace project.Services.Models
{
    public class ProductModelAction : IProductModelAction
    {
        private Dictionary<int, string> _products = new Dictionary<int, string>()
        {
            {1, "/image/car.svg" },
            {2, "/image/food.svg"},
            {3, "/image/jacket.svg"},
            {4, "/image/nedvizh.svg"},
            {5, "/image/culture.svg"},
            {6, "/image/tea.svg"}
        };
        public void Add(AuctionContext context, IFileHistoryAction fileService, IUserAction userService, string Login, LotModel lot)
        {
            UserModel user = userService.Get(context, Login);
            ProductModel tmp = new ProductModel()
            {
                Name = lot.Name,
                Comments = lot.Comments,
                IsBuy = false,
                Date = DateTime.Now,
                UserModelId = user.Id,
                TypeProductModelId = lot.type,
                Price = lot.Price
            };
            FileHistoryModel fileHistory = fileService.Get(context, userService, Login);
            tmp.Path = fileHistory == null ? _products[lot.type] : fileHistory.Path;
            context.Products.Add(tmp);
            context.SaveChanges();
        }

        public void Edit(AuctionContext context, IFileHistoryAction fileService, IUserAction userService, string Login, LotModel lot)
        {
            UserModel user = userService.Get(context, Login);
            ProductModel tmp = Get(context, lot.Id);
            tmp.Name = lot.Name;
            tmp.Comments = lot.Comments;
            tmp.TypeProductModelId = lot.type;
            FileHistoryModel fileHistory = fileService.Get(context, userService, Login);
            if (fileHistory != null)
                tmp.Path = fileHistory.Path;
            context.SaveChanges();
        }

        public ProductModel Get(AuctionContext context, int id) => context.Products.FirstOrDefault(x => x.Id == id);

        public ICollection<ProductModel> GetCollection(AuctionContext context, IUserAction userService, string Login)
        {
            ICollection<ProductModel> result = new List<ProductModel>();
            UserModel user = userService.Get(context, Login);
            foreach (ProductModel element in context.Products)
                if (element.UserModelId == user.Id)
                    result.Add(element);
            foreach (ProductModel element in result)
                element.TypeProduct = context.TypeProducts.FirstOrDefault(x => x.Id == element.TypeProductModelId);
            return result;
        }

        public void Remove(AuctionContext context, int id)
        {
            context.Products.Remove(context.Products.FirstOrDefault(x => x.Id == id));
            context.SaveChanges();
        }
    }
}
