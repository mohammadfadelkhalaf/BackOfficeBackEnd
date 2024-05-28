namespace WebApi.Models
{
    public class NotificationView
    {
        public string Id { get; set; }

        public string Message { get; set; }

        public string? Descriptions { get; set; }
        public string? restaurantImage { get; set; }
        public string? Link { get; set; }

        public string NotificationType { get; set; }

        public string NotificationFor { get; set; }
        public string ContentId { get; set; }
        public string CreatorId { get; set; }
        public string? RestaurantId { get; set; }
        public string? FromUserName { get; set; }
        public string? ForUserName { get; set; }
        public bool IsRead { get; set; }

        public bool? IsExpired { get; set; }

        public DateTime? ExpiredDate { get; set; }
    }
}
