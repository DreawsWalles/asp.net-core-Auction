using Microsoft.AspNetCore.SignalR;
using project.asp.net.core.Models;
using System.Threading.Tasks;

namespace project.asp.net.core.Hubs
{
    public class ChatHub : Hub 
    {
        public async Task SendMessage(MessageModel message) => await Clients.All.SendAsync("receiveMessage", message);
    }
}
