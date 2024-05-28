using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entites
{
    public class ChatEntity
    {
        [Key]
        public int Id { get; set; }

        public string Message { get; set; }

        public DateTime CreationTimestamp { get; set; }

        public DateTime LastUpdated { get; set; }

        [ForeignKey(nameof(FromUser))]
        public string FromUserId { get; set; }
        public UserEntity FromUser { get; set; }

        [ForeignKey(nameof(ToUser))]
        public string ToUserId { get; set; }
        public UserEntity ToUser { get; set; }

        [ForeignKey(nameof(User))]
        public string UserId { get; set; }
        public UserEntity User { get; set; }

        public bool Edited { get; set; }

        public bool Unread { get; set; }

        public bool Deleted { get; set; }
    }
}
