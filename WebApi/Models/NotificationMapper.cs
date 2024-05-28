using Infrastructure.Dtos;

namespace WebApi.Models
{
    public static class NotificationMapper
    {
        public static NotificationView MapToNotificationForSuperAdmin(string notificationMessage, string notificationType, string notificationFor, string notificationLink, string description, string userId, string restaurantId, string conatctId)
        {
            NotificationView notification = new NotificationView()
            {
                Id = Guid.NewGuid().ToString(),
                Message = notificationMessage,
                Descriptions = description,
                Link = notificationLink,
                NotificationType = notificationType,
                NotificationFor = notificationFor,
                ContentId = conatctId,
                RestaurantId = restaurantId,
                CreatorId = userId,
                IsExpired = false,
                ExpiredDate = null,
                IsRead = false
            };

            return notification;
        }

        public static ChattingNotification ChattingViewMapToChattingNotification(ChattingView chattingView)
        {
            ChattingNotification notification = new ChattingNotification()
            {
                Id = Guid.NewGuid().ToString(),
                Message = chattingView.Message,
                GroupName = (chattingView.UserId != chattingView.FromUserId ? chattingView.FromUserId : chattingView.ToUserId),
                CreationTimestamp = chattingView.CreationTimestamp,
                Deleted = chattingView.Deleted,
                Edited = chattingView.Edited,
                FromUserId = chattingView.FromUserId,
                LastUpdated = chattingView.LastUpdated,
                MethodName = "NewChat",
                ToUserId = chattingView.ToUserId,
                Unread = chattingView.Unread,
                UserId = chattingView.UserId
            };

            return notification;
        }

        public static CommonNotificationView NotificationObjectViewMapNotification(NotificationObjectView notificationObj, string id, string msg, string MethodName)
        {
            CommonNotificationView notification = new CommonNotificationView()
            {
                Id = id,
                MethodName = MethodName,
                GroupName = notificationObj.NotificationForId,
                Message = msg,
                Descriptions = notificationObj.Descriptions,

                NotificationType = notificationObj.NotificationType,
                NotificationFor = notificationObj.NotificationForId,
                ContentId = notificationObj.ContentId,
                RestaurantId = notificationObj.RestaurantId,
                FromUserId = notificationObj.FromuserId,
                FromUserName = notificationObj.FromUserName,
                IsRead = false
            };

            return notification;
        }

    }
}
