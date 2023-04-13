using Freezone.Core.Security.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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

        static readonly List<string> blockedUsers = new List<string>() { "vj123lcsd", "jbas81234" };

        static List<ChatMessage> messages = new List<ChatMessage>();

        public async Task SendMessageAsync(string message)
        {
            var user = _httpContextAccessor.HttpContext.User;
            var userName = user.Identity.Name;
            var chatMessage = new ChatMessage()
            {
                SenderFullName = userName,
                Date = DateTime.Now,
                Message = message,
                SenderUserId = user.Identities.First().Claims.FirstOrDefault(i=>i.Type == ClaimTypes.NameIdentifier).Value,
                SenderId = Context.ConnectionId
            };
            messages.Add(chatMessage);
            await Clients.Others.SendAsync("ReceiveMessage", chatMessage);
            await Clients.All.SendAsync("MessagesChanged", messages);
        }

        public async Task SendNotificationAsync(string notification)
        {
            await Clients.All.SendAsync("NewNotification", notification);
        }

        // Notlar
        public async Task SendMessageAsyncExample(string message)
        {
            // Gönderen hariç tüm bağlı clientlara erişim.
            #region Others 
            await Clients.Others.SendAsync("ReceiveMessage",message);
            #endregion
            // Bağlı tüm clientlara erişim.
            #region All
            await Clients.All.SendAsync("ReceiveMessage", message);
            await Clients.AllExcept(blockedUsers).SendAsync("ReceiveMessage", message);
            #endregion
            // İsteği triggerlayan client'a erişim
            #region Caller
            await Clients.Caller.SendAsync("ReceiveMessage", message);
            #endregion
            // Önceden grupladığım ve o an ilgili grup bağlantısına sahip tüm kullanıcılara erişim.
            #region Group
            await Clients.Group("IKGrubu").SendAsync("ReceiveMessage", message);
            await Clients.OthersInGroup("IKGrubu").SendAsync("ReceiveMessage", message);
            // ["abc123","bca321","vj123lcsd", "jbas81234"]
            await Clients.GroupExcept("IKGrubu", blockedUsers).SendAsync("ReceiveMessage", message);
            #endregion
        }

        public override Task OnConnectedAsync()
        {
            var user = _httpContextAccessor.HttpContext.User;
            if (!user.Identity.IsAuthenticated) throw new UnauthorizedAccessException();
            connectedIds.Add(Context.ConnectionId);
            connectedUsers.Add(user.Identity.Name);
            Clients.All.SendAsync("UserListChanged", connectedUsers);
            // Claims.Groups = ["IKGrubu", "Yönetim"]
            #region Group İşlemleri
            // Kullanıcının TITLE_DEFINITON alanındaki Title alanı grup ismi olmalıdır.
            Groups.AddToGroupAsync(Context.ConnectionId, "IKGrubu");
            #endregion
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            var user = _httpContextAccessor.HttpContext.User;
            connectedIds.Remove(Context.ConnectionId);
            connectedUsers.Remove(user.Identity.Name);
            Clients.All.SendAsync("UserListChanged", connectedUsers);

            Groups.RemoveFromGroupAsync(Context.ConnectionId, "IKGrubu");
            return base.OnDisconnectedAsync(exception);
        }
    }
}
