namespace WebApi.Dtos
{
    public class CommonNotificationView
    {
        public string Id { get; set; }
        public string MethodName { get; set; }
        public string GroupName { get; set; }
        public string Message { get; set; }

        public string? Descriptions { get; set; }

        public string NotificationType { get; set; }

        public string NotificationFor { get; set; }
        public string ContentId { get; set; }
        public string FromUserId { get; set; }
        public string FromUserName { get; set; }
        public string? RestaurantId { get; set; }
        public bool IsRead { get; set; }
    }
}
