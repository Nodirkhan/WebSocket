
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace ServerSide.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            Console.WriteLine("Received message: {0} - {1}", user, message);
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}
