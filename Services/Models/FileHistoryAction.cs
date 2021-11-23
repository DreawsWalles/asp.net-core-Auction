using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using project.DAL;
using project.Models;
using project.Services.Interfaces;
using System.IO;
using System.Threading.Tasks;
using project.asp.net.core.Models;

namespace project.Services.Models
{
    public class FileHistoryAction : IFileHistoryAction
    {
        public async Task Add(AuctionContext context, IUserAction userService, string Login, IFormFile uploadedFile, IWebHostEnvironment appEnvironment, int id = 0)
        {
            string path = "/image/" + uploadedFile.FileName;
            // сохраняем файл в папку Files в каталоге wwwroot
            using (var fileStream = new FileStream(appEnvironment.WebRootPath + path, FileMode.Create))
            {
                await uploadedFile.CopyToAsync(fileStream);
            }
            FileHistoryModel tmp = new FileHistoryModel()
            {
                Path = path,
                UserModelId = userService.Get(context, Login).Id,
                ModelId = id
            };
            context.FileHistory.Add(tmp);
            context.SaveChanges();
        }

        public void Clear(AuctionContext context, IUserAction userService, string Login)
        {
            UserModel user = userService.Get(context, Login);
            foreach(FileHistoryModel element in context.FileHistory)
                if(element.UserModelId == user.Id)
                    context.FileHistory.Remove(element);
            context.SaveChanges();
        }

        public FileHistoryModel Get(AuctionContext context, IUserAction userService, string Login)
        {
            FileHistoryModel result = null;
            UserModel user = userService.Get(context, Login);
            foreach(FileHistoryModel element in context.FileHistory)
                if(element.UserModelId == user.Id)
                    result = element;
            return result;
        }
    }
}
