using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entites
{
    public class UserchatEntity
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey(nameof(ToUser))]
        public string ToUserId { get; set; }
        public UserEntity ToUser { get; set; }

        [ForeignKey(nameof(FromUser))]
        public string FromUserId { get; set; }
        public UserEntity FromUser { get; set; }
    }
}
