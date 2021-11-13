using project.DAL;
using project.Models;
using project.Models.Product;
using System.Collections.Generic;

namespace project.Services.Interfaces
{
    public interface IProductModelAction
    {
        void Add(AuctionContext context, IFileHistoryAction fileService, IUserAction userService, string Login, LotModel lot);
        void Edit(AuctionContext context, IFileHistoryAction fileService, IUserAction userService, string Login, LotModel lot);
        void Remove(AuctionContext context, int id);
        ProductModel Get(AuctionContext context, int id);
        ICollection<ProductModel> GetCollection(AuctionContext context, IUserAction userService, string Login);
    }
}
