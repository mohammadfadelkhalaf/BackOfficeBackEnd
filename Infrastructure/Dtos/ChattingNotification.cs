namespace Infrastructure.Dtos
{
    public class ChattingNotification
    {
        public string Id { get; set; }
        public string GroupName { get; set; }
        public string MethodName { get; set; }
        public string Message { get; set; }
        public DateTime CreationTimestamp { get; set; }
        public DateTime LastUpdated { get; set; }
        public string FromUserId { get; set; }
        public string ToUserId { get; set; }
        public string UserId { get; set; }
        public bool Edited { get; set; }
        public bool Unread { get; set; }
        public string ReportChatFromUserId { get; set; }
        public string ReportChatReportId { get; set; }
        public string ReportChatToUserId { get; set; }
        public bool Deleted { get; set; }
    }
}
