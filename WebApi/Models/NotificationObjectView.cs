namespace WebApi.Models
{
    public class NotificationObjectView
    {
        public string Id { get; set; }
        public string NotificationType { get; set; }
        public string? Descriptions { get; set; }
        public string FromUserName { get; set; }
        public string FromuserId { get; set; }
        public string NotificationForId { get; set; }
        public string ContentId { get; set; }
        public string? RestaurantId { get; set; }
        public bool IsRead { get; set; }
    }
}
