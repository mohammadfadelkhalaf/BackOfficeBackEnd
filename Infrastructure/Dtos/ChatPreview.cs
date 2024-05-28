namespace Infrastructure.Dtos
{
    public class ChatPreview
    {
        public string ToUserId { get; set; }
        public string FromUserId { get; set; }
        //public string ToUserName { get; set; }
        //public string FromUserName { get; set; }
        public string LastMessage { get; set; }
        public string CreationTime { get; set; }
        public string FriendName { get; set; }
        public string FriendUserId { get; set; }
        public int ureadCount { get; set; }

        public DateTime CreateOn { get; set; }
    }
}
