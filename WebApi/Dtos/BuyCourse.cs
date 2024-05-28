namespace WebApi.Dtos
{
    public class BuyCourse
    {
        public string userId { get; set; }
        public int courseId { get; set; }
        public int batchId { get; set; }
        public double price { get; set; }
    }
}
