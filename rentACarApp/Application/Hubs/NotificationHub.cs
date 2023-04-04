using Application.Features.Cars.Commands.Create;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Hubs
{
    public class NotificationHub : Hub
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public NotificationHub(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public override Task OnConnectedAsync()
        {
            var user = _httpContextAccessor.HttpContext.User;
            if (!user.Identity.IsAuthenticated) throw new UnauthorizedAccessException();
            return base.OnConnectedAsync();
        }
    }
}
