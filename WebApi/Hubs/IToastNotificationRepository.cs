using Infrastructure.Dtos;

namespace WebApi.Hubs
{
    public interface IToastNotificationRepository
    {
        Task SendNotificationAsync(ToastNotificationView notification);
        Task CommonNotification(WebApi.Models.CommonNotificationView notification);
        Task ChattingNotification(ChattingNotification notification);
        Task SendNotificationToAllAsync(string methodName, object argument);
        Task SendNotificationToGroupAsync(string groupName, string methodName, object argument);
    }
}
