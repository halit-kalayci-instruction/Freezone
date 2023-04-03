using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ChatHub(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        static List<string> connectedIds = new List<string>();
        public async Task SendMessageAsync(string message)
        {
            // Fonksiyon
            await Clients.Others.SendAsync("ReceiveMessage",message);
        }

        public override Task OnConnectedAsync()
        {
            var user = _httpContextAccessor.HttpContext.User;
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
