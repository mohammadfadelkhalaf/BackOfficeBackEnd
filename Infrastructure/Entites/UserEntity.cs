using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entites
{
    public class UserEntity : IdentityUser
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string? ProfileImage { get; set; } = "profile2.jpg";
        public string? Bio { get; set; }
        public double? CurrentBalance { get; set; }
        public int RolesId { get; set; }

        public int? AddressId { get; set; }
        public AddressEntity? Address { get; set; }
        public ICollection<UserCourseEntity> UserCourses { get; set; }
        public ICollection<OrderEntity> Orders { get; set; }
        public ICollection<ChatEntity> SentChats { get; set; } = new List<ChatEntity>();
        public ICollection<ChatEntity> ReceivedChats { get; set; } = new List<ChatEntity>();
        public ICollection<ChatEntity> UserChats { get; set; } = new List<ChatEntity>();

        public ICollection<UserchatEntity> ToUserChat { get; set; } = new List<UserchatEntity>();
        public ICollection<UserchatEntity> FromUserChats { get; set; } = new List<UserchatEntity>();
        public RoleEntity Roles { get; set; }
    }
}
