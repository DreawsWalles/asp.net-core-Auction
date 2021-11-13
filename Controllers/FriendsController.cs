using Microsoft.AspNetCore.Mvc;
using project.DAL;
using project.Models;
using project.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace project.Controllers
{
    public class FriendsController : Controller
    {
        AuctionContext dataBase;
        IUserAction userService;
        IPersonAction personService;
        public FriendsController(AuctionContext dataBase, IUserAction userService, IPersonAction personService)
        {
            this.dataBase = dataBase;
            this.userService = userService; 
            this.personService = personService;
        }
        public IActionResult Index()
        {
            int id = userService.Get(dataBase, User.Identity.Name).Id;
            List<UserModel> users = dataBase.Users.Where(x => x.Id != id).ToList();
            foreach (UserModel element in users)
                element.PersonModel = personService.Get(dataBase, userService, element.Login);
            ViewData["Users"] = users;
            ICollection<UserModel> friends = userService.GetFriends(dataBase, User.Identity.Name);
            if(friends != null)
                foreach (UserModel element in friends)
                    element.PersonModel = personService.Get(dataBase, userService, element.Login);
            ViewData["Friends"] = dataBase.Friends.Where(x => x.FriendOneId == id || x.FriendTwoId == id).ToList();
            return View(friends);
        }
        private string[] ProcessField(string param)
        {
            string tmp = param.TrimStart().TrimEnd();
            tmp = Regex.Replace(tmp, @"\s+", " ");
            string[] result = tmp.Split(' ');
            if (result.Count() > 3)
                return null;
            return result;
        }
        [HttpPost]
        public IActionResult Search(string field)
        {
            string[] param = ProcessField(field);
            if (param == null)
                return View(null);
            int id = userService.Get(dataBase, User.Identity.Name).Id;
            ViewData["Friends"] = dataBase.Friends.Where(x => x.FriendOneId == id || x.FriendTwoId == id).ToList();
            List<UserModel> users = dataBase.Users.Where(x => x.Id != id).ToList();
            foreach (UserModel element in users)
                element.PersonModel = personService.Get(dataBase, userService, element.Login);
            List<UserModel> result = null;
            if (users.Count() > 0)
            {
                result = new List<UserModel>();
                switch (param.Count())
                {
                    case 3:
                        foreach (UserModel element in users)
                            if (((element.PersonModel.Name == param[0] && element.PersonModel.Sername == param[1]) || (element.PersonModel.Name == param[1] && element.PersonModel.Sername == param[0])) && element.PersonModel.Patronymic == param[2])
                                result.Add(element);
                        break;
                    case 2:
                        foreach(UserModel element in users)
                            if ((element.PersonModel.Name == param[0] && element.PersonModel.Sername == param[1]) || (element.PersonModel.Name == param[1] && element.PersonModel.Sername == param[0]))
                                result.Add(element);
                        break;
                    default:
                        foreach(UserModel element in users)
                            if(element.PersonModel.Name == param[0] || element.PersonModel.Sername == param[0])
                                result.Add(element);
                        break;
                }
            }

            return View(result);
        }
        public IActionResult AcceptFriendship(int id)
        {
            int userId = userService.Get(dataBase, User.Identity.Name).Id;
            FriendsModel model = dataBase.Friends.FirstOrDefault(x => (x.FriendOneId == userId && x.FriendTwoId == id) || (x.FriendOneId == id && x.FriendTwoId == userId));
            model.status = 3;
            dataBase.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult DeclineFrendship(int id)
        {
            int userId = userService.Get(dataBase, User.Identity.Name).Id;
            FriendsModel model = dataBase.Friends.FirstOrDefault(x => (x.FriendOneId == userId && x.FriendTwoId == id) || (x.FriendOneId == id && x.FriendTwoId == userId));
            if (model.FriendTwoId == id)
                dataBase.Friends.Remove(model);
            else
                model.status = 2;
            dataBase.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult AddFriendship(int id)
        {
            int userId = userService.Get(dataBase, User.Identity.Name).Id;
            FriendsModel model = new FriendsModel()
            {
                FriendOneId = userId,
                FriendTwoId = id,
                status = 1
            };
            dataBase.Friends.Add(model);
            dataBase.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult RemoveFriendship(int id)
        {
            int userId = userService.Get(dataBase, User.Identity.Name).Id;
            FriendsModel model = dataBase.Friends.FirstOrDefault(x => (x.FriendOneId == userId && x.FriendTwoId == id) || (x.FriendOneId == id && x.FriendTwoId == userId));
            if(model.FriendOneId == userId && model.FriendTwoId == id)
            {
                model.FriendOneId = id;
                model.FriendTwoId = userId;
            }
            else
            {
                model.FriendOneId = userId;
                model.FriendTwoId = id;
            }
            model.status = 2;
            dataBase.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
