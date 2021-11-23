using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using project.asp.net.core.Models;
using project.DAL;
using project.Models;
using project.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project.asp.net.core.Controllers
{
    public class MessangerController : Controller
    {
        private readonly AuctionContext dataBase;
        private IPersonAction personService { get; set; }
        private IUserAction userService { get; set; }
        public MessangerController(AuctionContext context, IUserAction userService, IPersonAction personService )
        {
            dataBase = context;
            this.userService = userService;
            this.personService = personService; 
        }
        public async Task<IActionResult> Dialog(int id)
        {
            //UserModel currentUser = await userManager.GetUserAsync(User);
            //currentUser.PersonModel = personService.Get(dataBase, userService, currentUser.Login);
            //ViewBag.CurrentUserName = currentUser.PersonModel.Name + ' ' + currentUser.PersonModel.Sername;
            //ViewBag.CurrentUserLogin = currentUser.Login;
            //List<MessageModel> messages = (List<MessageModel>)dataBase.Messages.Where(x => x.SenderId == currentUser.Id);
            return View();
        }

        public async Task<IActionResult> Create(MessageModel model, int RecipientUserId)
        {
            if(ModelState.IsValid)
            {
                model.Date = DateTime.Now;
                model.RecipientId = RecipientUserId;
                //UserModel sender = await userManager.GetUserAsync(User);
                //model.SenderId = sender.Id;
                await dataBase.Messages.AddAsync(model);
                await dataBase.SaveChangesAsync();
                return Ok();
            } 
            return BadRequest();
        }
    }
}
