namespace Infrastructure.Dtos
{
    public class ChattingView
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public DateTime CreationTimestamp { get; set; }
        public DateTime LastUpdated { get; set; }
        public string FromUserId { get; set; }
        public string ToUserId { get; set; }
        public string UserId { get; set; }
        public bool Edited { get; set; }
        public bool Unread { get; set; }
        public bool Deleted { get; set; }
    }
}
