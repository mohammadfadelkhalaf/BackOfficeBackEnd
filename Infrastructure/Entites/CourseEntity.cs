using System;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Entites
{
    public class CourseEntity
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string ImageName { get; set; } = "01.jpg";
        public double Price { get; set; } = 0.0;
        public double DisCountPrice { get; set; }
        public double TotalHours { get; set; } 
        public int LikesInNumbers { get; set; }
        public double LikesInProcent { get; set; } 
        public string Author { get; set; } = null!;
        public bool IsBestSeller { get; set; }
        public bool IsFeatured { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
        public DateTime CreationDate { get; set; }
        public string CreatorId { get; set; }
        public DateTime ModificationDate { get; set; }
        public string ModifierId { get; set; }
        public ICollection<BatchEntity> Batches { get; set; }

    }
}
