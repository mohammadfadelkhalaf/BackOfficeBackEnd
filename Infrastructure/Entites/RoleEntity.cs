using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entites
{
    public class RoleEntity
    {
        [Key]
        public int Id { get; set; }
        public string RoleName { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
        public DateTime CreationDate { get; set; }
        public string CreatorId { get; set; }
        public DateTime ModificationDate { get; set; }
        public string ModifierId { get; set; }
        public ICollection<UserEntity> Users { get; set; }
    }
}
