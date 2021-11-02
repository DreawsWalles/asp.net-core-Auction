using project.DAL;
using project.Models.Person;
using project.Services.Interfaces;
using System.Linq;

namespace project.Services.Models
{
    public class SenderDetailsAction : ISenderDetailsAction
    {
        public void Delete(AuctionContext context, IPersonAction personService, IUserAction userService, string Login)
        {
            context.SenderDetails.Remove(Get(context, personService, userService, Login));
            context.SaveChanges();
        }

        public void Edit(AuctionContext context, IPersonAction personService, IUserAction userService, string Login, SenderDetailsModel model, string key)
        {
            SenderDetailsModel tmp = Get(context, personService, userService, Login);
            switch(key)
            {
                case "Name":
                    tmp.Name = model.Name;
                    break;
                case "Sername":
                    tmp.Sername = model.Sername;
                    break;
                case "NumberCart":
                    tmp.NumberCart = model.NumberCart;
                    break;
                case "CVC":
                    tmp.CVC = model.CVC;
                    break;
                case "dateTime":
                    tmp.dateTime = model.dateTime;
                    break;
            }
            context.SaveChanges();
        }

        public SenderDetailsModel Get(AuctionContext context, IPersonAction personService, IUserAction userService, string Login) =>
            context.SenderDetails.FirstOrDefault(x => x.Id == personService.Get(context, userService, Login).SenderDetailsModelId);
    }
}
