namespace WebApi.Dtos
{
    public class ToastNotificationView
    {
        public string Id { get; set; }
        public string NotificationType { get; set; }
        public string NotificationFor { get; set; }
        public string NotificationLink { get; set; }
        public string NotificationMessage { get; set; }
        public string Description { get; set; }
        public string ApplicationUserId { get; set; }
        public string ContentId { get; set; }
        public string ClientId { get; set; }
        public string GroupName { get; set; }
        public string MethodName { get; set; }
        public bool IsRead { get; set; }
        public string CreatorId { get; set; }
        public DateTime Creationdate { get; set; }
    }
}
