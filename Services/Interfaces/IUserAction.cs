using project.DAL;
using project.Models;
using System.Collections.Generic;

namespace project.Services.Interfaces
{
    public interface IUserAction
    {
        void Add(AuctionContext context, RegisterModel model);
        void Edit(AuctionContext context,string Login, UserModel model, string key);
        UserModel Get(AuctionContext context, string Login);
        UserModel Get(AuctionContext context, LoginModel model);
        ICollection<UserModel> GetFriends(AuctionContext context, string Login);
    }
}
