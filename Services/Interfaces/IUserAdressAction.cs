using project.DAL;
using project.Models.Adress;

namespace project.Services.Interfaces
{
    public interface IUserAdressAction
    {
        void Edit(AuctionContext context, IPersonAction personService, IUserAction userService, string Login, AdressModel model, string key);
        void Delete(AuctionContext context, IPersonAction personService, IUserAction userService, string Login);
        AdressModel Get(AuctionContext context, IPersonAction personService, IUserAction userService, string Login);
    }
}
