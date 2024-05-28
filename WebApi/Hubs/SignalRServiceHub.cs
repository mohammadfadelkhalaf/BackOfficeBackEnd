using System.Text.RegularExpressions;
using Microsoft.AspNetCore.SignalR;

namespace WebApi.Hubs
{
    public class SignalRServiceHub : Hub
    {
        public override async Task OnConnectedAsync()
        {
            await base.OnConnectedAsync();
            await Clients.Client(Context.ConnectionId).SendAsync("ReceiveMessage", $"{Context.ConnectionId} has joined");
        }

        public async Task NewConnectionToGroup(string groupName)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
            await Clients.Group(groupName).SendAsync("GetNotificationForSuperAdmin",
              $"{Context.ConnectionId} has joined {groupName}");
        }

        public async Task NewConnectionToGroupWithMethodName(string groupName, string methodName)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
            await Clients.Group(groupName).SendAsync(methodName,
              $"{Context.ConnectionId} has joined {groupName}");
        }
        public async Task RemoveConnectionFromGroup(string groupName)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, groupName);
        }
    }
}
