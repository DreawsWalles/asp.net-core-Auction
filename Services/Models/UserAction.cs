using project.DAL;
using project.Models;
using project.Models.Person;
using project.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity;

namespace project.Services.Models
{
    public class UserAction : IUserAction
    {
        public void Add(AuctionContext context, RegisterModel model)
        {
            context.Users.Add(new UserModel()
            {
                Login = model.Login,
                Password = new PasswordHasher<UserModel>().HashPassword(new UserModel(), model.Password),
                Money = 0,
                PersonModel = new PersonModel()
                {
                    Name = model.Name,
                    Sername = model.Sername,
                    Patronymic = model.Patronymic,
                    Email = model.Email,
                    Phone = model.Phone,
                    Adress = null,
                    RecipientDetailsModels = null,
                    SenderDetails = null,
                    AdressModelID = null,
                    RecipientDetailsModelId = null,
                    SenderDetailsModelId = null
                }
            }); ;
            context.SaveChanges();
        }

        public void Edit(AuctionContext context, string Login,  UserModel model, string key)
        {
            UserModel tmp = Get(context, Login);
            switch (key)
            {
                case "Password":
                    tmp.Password = new PasswordHasher<UserModel>().HashPassword(new UserModel(), model.Password);
                    break;
                case "Login":
                    tmp.Login = model.Login;
                    break;
                case "Image":
                    tmp.FilePath = model.FilePath;
                    break;
                case "Cash":
                    tmp.Money = model.Money;
                    break;
            }
            context.SaveChanges();
        }

        public UserModel Get(AuctionContext context, string Login) => context.Users.FirstOrDefault(x=> x.Login == Login);
        public UserModel Get(AuctionContext context, LoginModel model)
        {
            var tmp = new PasswordHasher<UserModel>().VerifyHashedPassword(new UserModel(), Get(context, model.Login).Password, model.Password);
            return tmp == PasswordVerificationResult.Success ? Get(context, model.Login) : null;
        }

        public ICollection<UserModel> GetFriends(AuctionContext context, string Login)
        {
            UserModel user = Get(context, Login);
            ICollection<UserModel> friends = new List<UserModel>();
            foreach (FriendsModel friend in context.Friends)
                if (friend.status == 3)
                    if (user.Id == friend.FriendOneId)
                        friends.Add(context.Users.FirstOrDefault(x => x.Id == friend.FriendTwoId));
                    else if(user.Id == friend.FriendTwoId)
                        friends.Add(context.Users.FirstOrDefault(x => x.Id == friend.FriendOneId));
            if (friends.Count > 0)
                return friends;
            return null;
        }
    }
}
