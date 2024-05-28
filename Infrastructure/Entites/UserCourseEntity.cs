using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entites
{
    public class UserCourseEntity
    {
        [Key]
        public int Id { get; set; }
        public int BatchId { get; set; }
        public string UserId { get; set; }
        public bool IsCompleted { get; set; }
        public bool IsFullyPaid { get; set; }
        public DateTime CreationDate { get; set; }
        public string CreatorId { get; set; }
        public DateTime ModificationDate { get; set; }
        public string ModifierId { get; set; }
        public BatchEntity Batch { get; set; }
        public UserEntity User { get; set; }
    }
}
