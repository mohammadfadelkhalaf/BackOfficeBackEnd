namespace WebApi.Dtos
{
    public class BatchDto
    {
        public int Id { get; set; } = 0;
        public string BatchName { get; set; }
        public int CourseId { get; set; }
        public DateTime StartDate { get; set; }
        public decimal MaxMemberCount { get; set; }
        public bool IsActive { get; set; }
        public bool IsExpire { get; set; }
    }
}
