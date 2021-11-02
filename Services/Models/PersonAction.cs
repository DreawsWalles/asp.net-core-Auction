using project.DAL;
using project.Models.Adress;
using project.Models.Person;
using project.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace project.Services.Models
{
    public class PersonAction : IPersonAction
    {
        public void Edit(AuctionContext context, IUserAction service, string Login, PersonModel model, string key)
        {
            PersonModel tmp = Get(context, service, Login);
            switch(key)
            {
                case "Name":
                    tmp.Name = model.Name;
                    break;
                case "Sername":
                    tmp.Sername = model.Sername;
                    break;
                case "Patronymic":
                    tmp.Patronymic = model.Patronymic;
                    break;
                case "Email":
                    tmp.Email = model.Email;
                    break;
                case "Phone":
                    tmp.Phone = model.Phone;
                    break;
                case "Adress":
                    tmp.Adress = model.Adress;
                    break;
                case "RecipientDetails":
                    tmp.RecipientDetailsModels = model.RecipientDetailsModels;
                    break;
                case "SenderDetails":
                    tmp.SenderDetails = model.SenderDetails;
                    break;
            }
            context.SaveChanges();
        }
        public PersonModel Get(AuctionContext context, IUserAction service, string Login) => context.Persons.FirstOrDefault(x => x.Id == context.Users.FirstOrDefault(y => y.Login == Login).PersonModelId);
    }
}
