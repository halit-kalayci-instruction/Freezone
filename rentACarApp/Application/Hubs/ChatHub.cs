using Freezone.Core.Security.Entities;
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

        static List<string> connectedUsers = new List<string>();
        public async Task SendMessageAsync(string message)
        {
            // Fonksiyon
            await Clients.Others.SendAsync("ReceiveMessage",message);
        }

        public override Task OnConnectedAsync()
        {
            var user = _httpContextAccessor.HttpContext.User;
            if (!user.Identity.IsAuthenticated) throw new UnauthorizedAccessException();
            connectedIds.Add(Context.ConnectionId);
            connectedUsers.Add(user.Identity.Name);
            Clients.All.SendAsync("UserListChanged", connectedUsers);
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            var user = _httpContextAccessor.HttpContext.User;
            connectedIds.Remove(Context.ConnectionId);
            connectedUsers.Remove(user.Identity.Name);
            Clients.All.SendAsync("UserListChanged", connectedUsers);
            return base.OnDisconnectedAsync(exception);
        }
    }
}
