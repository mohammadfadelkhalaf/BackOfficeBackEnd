using System.ComponentModel.DataAnnotations;

namespace WebApi.Dtos
{
    public class CourseDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string? ImageName { get; set; }
        //nullable
        public double Price { get; set; }
        public double DisCountPrice { get; set; }
        public double Hours { get; set; }
        public int LikesInNumbers { get; set; }
        public double LikesInProcent { get; set; }
        public string? Author { get; set; }
        public bool IsBestSeller { get; set; }
        public DateTime CreationDate { get; set; }
        public string CreatorId { get; set; }
        public DateTime ModificationDate { get; set; }
        public string ModifierId { get; set; }
    }
}
