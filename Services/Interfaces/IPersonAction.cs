using project.DAL;
using project.Models.Adress;
using project.Models.Person;

namespace project.Services.Interfaces
{
    public interface IPersonAction
    {
        void Edit(AuctionContext context, IUserAction service, string Login, PersonModel model, string key);
        PersonModel Get(AuctionContext context, IUserAction service, string Login);
    }
}
