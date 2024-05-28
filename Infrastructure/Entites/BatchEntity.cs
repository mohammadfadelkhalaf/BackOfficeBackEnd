using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entites
{
    public class BatchEntity
    {
        [Key]
        public int Id { get; set; }
        public string BatchName { get; set; }
        public int CourseId { get; set; }
        public DateTime StartDate { get; set; }
        public decimal MaxMemberCount { get; set; }
        public bool IsActive { get; set; }
        public bool IsExpire { get; set; }
        public CourseEntity Course { get; set; }
        public ICollection<UserCourseEntity> UserCourses { get; set; }
        public ICollection<OrderEntity> Orders { get; set; }
    }
}
