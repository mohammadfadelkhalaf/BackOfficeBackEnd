namespace WebApi.Dtos
{
    public class ChattingViewForPagination
    {
        public List<ChattingView> chats { get; set; }
        public int totalChats { get; set; }
    }
}
