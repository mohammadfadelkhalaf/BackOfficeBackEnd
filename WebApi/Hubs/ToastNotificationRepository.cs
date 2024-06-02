using Microsoft.AspNetCore.SignalR;
using Infrastructure.Dtos;

namespace WebApi.Hubs
{
    public class ToastNotificationRepository: IToastNotificationRepository
    {
        private readonly IHubContext<SignalRServiceHub> _hubContext;
        public ToastNotificationRepository(IHubContext<SignalRServiceHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public async Task SendNotificationAsync(ToastNotificationView notification)
        {
            await SendNotificationToGroupAsync(notification.GroupName, notification.MethodName, notification);
        }

        public async Task CommonNotification(WebApi.Models.CommonNotificationView notification)
        {
            await SendNotificationToGroupAsync(notification.GroupName, notification.MethodName, notification);
        }
        public async Task ChattingNotification(ChattingNotification notification)
        {
            await SendNotificationToGroupAsync(notification.GroupName, notification.MethodName, notification);
        }

        public async Task TestNotification(ChattingNotification notification)
        {
            await SendNotificationToGroupAsync("Shahed", "Test", notification);
        }
        public async Task SendNotificationToAllAsync(string methodName, object argument)
        {
            await _hubContext.Clients.All.SendAsync(methodName, argument);
        }

        public async Task SendNotificationToGroupAsync(string groupName, string methodName, object argument)
        {
            try
            {
                await _hubContext.Clients.Group(groupName).SendAsync(methodName, argument);
            }
            catch (Exception ex)
            {

                throw;
            }

        }
    }
}
