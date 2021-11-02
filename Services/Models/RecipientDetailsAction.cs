using project.DAL;
using project.Models.Person;
using project.Services.Interfaces;
using System.Linq;

namespace project.Services.Models
{
    public class RecipientDetailsAction : IRecipientDetailsAction
    {
        public void Delete(AuctionContext context, IPersonAction personService, IUserAction userService, string Login)
        {
            context.RecipientDetails.Remove(Get(context, personService, userService, Login));
            context.SaveChanges();
        }

        public void Edit(AuctionContext context, IPersonAction personService, IUserAction userService, string Login, RecipientDetailsModel model, string key)
        {
            RecipientDetailsModel tmp = Get(context, personService, userService, Login);
            switch(key)
            {
                case "Name":
                    tmp.Name = model.Name;
                    break;
                case "INN":
                    tmp.INN = model.INN;
                    break;
                case "KPP":
                    tmp.KPP = model.KPP;
                    break;
                case "AccountNumber":
                    tmp.AccountNumber = model.AccountNumber;
                    break;
                case "BIK":
                    tmp.BIK = model.BIK;
                    break;
                case "CorrespondentAccount":
                    tmp.CorrespondentAccount = model.CorrespondentAccount;
                    break;
            }
            context.SaveChanges();
        }

        public RecipientDetailsModel Get(AuctionContext context, IPersonAction personService, IUserAction userService, string Login)=>
            context.RecipientDetails.FirstOrDefault(x => x.Id == personService.Get(context, userService, Login).RecipientDetailsModelId);
    }
}
