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
        static List<string> connectedIds = new List<string>();
        public async Task SendMessageAsync(string message)
        {
            // Fonksiyon
            await Clients.Others.SendAsync("ReceiveMessage",message);
        }

        public override Task OnConnectedAsync()
        {
            connectedIds.Add(Context.ConnectionId);
            Clients.All.SendAsync("UserListChanged", connectedIds);
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            connectedIds.Remove(Context.ConnectionId);
            Clients.All.SendAsync("UserListChanged", connectedIds);
            return base.OnDisconnectedAsync(exception);
        }
    }
}
