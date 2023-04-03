using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessageAsync(string message)
        {
            // Fonksiyon
            await Clients.All.SendAsync("ReceiveMessage",message);
        }
    }
}
