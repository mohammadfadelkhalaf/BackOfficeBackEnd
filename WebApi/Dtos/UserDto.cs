using Infrastructure.Entites;

namespace WebApi.Dtos
{
    public class UserDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ProfileImage { get; set; }
        public string Bio { get; set; }
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public double CurrentBalance { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; }

    }
    public class UserWithDetailsDto: UserDto
    {
        public AddressEntity? Address { get; set; }= new AddressEntity();
        public ICollection<UserCourseEntity> UserCourses { get; set; }=new List<UserCourseEntity>();
        public ICollection<OrderEntity> Orders { get; set; } = new List<OrderEntity>();

    }
}
