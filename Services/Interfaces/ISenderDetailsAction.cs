using project.DAL;
using project.Models;
using project.Models.Person;

namespace project.Services.Interfaces
{
    public interface ISenderDetailsAction
    {
        void Edit(AuctionContext context, IPersonAction personService, IUserAction userService, string Login, SenderDetailsModel model, string key);
        void Delete(AuctionContext context, IPersonAction personService, IUserAction userService, string Login);
        SenderDetailsModel Get(AuctionContext context, IPersonAction personService, IUserAction userService, string Login);

    }
}
