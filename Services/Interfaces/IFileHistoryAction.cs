using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using project.DAL;
using project.Models;
using System.Threading.Tasks;

namespace project.Services.Interfaces
{
    public interface IFileHistoryAction
    {
        Task Add(AuctionContext context, IUserAction userService, string Login, IFormFile uploadedFile, IWebHostEnvironment appEnvironment, int id = 0);
        void Clear(AuctionContext context, IUserAction userService, string Login);
        FileHistoryModel Get(AuctionContext context, IUserAction userService, string Login);
    }
}
