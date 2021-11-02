using project.DAL;
using project.Models.Person;

namespace project.Services.Interfaces
{
    public interface IRecipientDetailsAction
    {
        void Edit(AuctionContext context, IPersonAction personService, IUserAction userService, string Login, RecipientDetailsModel model, string key);
        void Delete(AuctionContext context, IPersonAction personService, IUserAction userService, string Login);
        RecipientDetailsModel Get(AuctionContext context, IPersonAction personService, IUserAction userService, string Login);
    }
}
