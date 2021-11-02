using project.DAL;
using project.Models.Adress;
using project.Services.Interfaces;
using System.Linq;

namespace project.Services.Models
{
    public class UserAdressAction : IUserAdressAction
    {
        public void Delete(AuctionContext context, IPersonAction personService, IUserAction userService, string Login)
        {
            context.Adresses.Remove(Get(context, personService, userService, Login));
            context.SaveChanges();
        }

        public void Edit(AuctionContext context, IPersonAction personService, IUserAction userService, string Login, AdressModel model, string key)
        {
            AdressModel tmp = Get(context, personService, userService, Login);
            switch(key)
            {
                case "Country":
                    tmp.Country = model.Country;
                    break;
                case "City":
                    tmp.City = model.City;
                    break;
                case "Street":
                    tmp.Street = model.Street;
                    break;
                case "PostIndex":
                    tmp.PostIndex = model.PostIndex;
                    break;
            }
            context.SaveChanges();
        }

        public AdressModel Get(AuctionContext context, IPersonAction personService, IUserAction userService, string Login) =>
            context.Adresses.FirstOrDefault(x => x.Id == personService.Get(context, userService, Login).AdressModelID);
    }
}
