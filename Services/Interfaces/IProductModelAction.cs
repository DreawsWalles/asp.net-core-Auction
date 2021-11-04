using project.DAL;
using project.Models;
using project.Models.Product;

namespace project.Services.Interfaces
{
    public interface IProductModelAction
    {
        void Add(AuctionContext context, IFileHistoryAction fileService, IUserAction userService, string Login, LotModel lot);
        void Edit(AuctionContext context, IFileHistoryAction fileService, IUserAction userService, string Login, LotModel lot);
        void Remove(AuctionContext context, int id);
        ProductModel Get(AuctionContext context, int id);
    }
}
