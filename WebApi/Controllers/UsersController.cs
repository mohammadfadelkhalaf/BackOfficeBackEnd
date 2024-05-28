using Infrastructure.Context;
using Infrastructure.Entites;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.Hosting;
using WebApi.Dtos;
using static Grpc.Core.Metadata;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly ILogger<UsersController> _logger;
        private readonly UserRepository _userRepository;
        private readonly EmailServices _emailServices;

        public UsersController(DataContext context, ILogger<UsersController> logger, UserRepository userRepository)
        {
            _context = context;
            _logger = logger;
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userRepository.GetAllUserListAsync();

            List<UserWithDetailsDto> userLists = new();
            if (users.Count() > 0)

                foreach (var item in users)
                {
                    var user = new UserWithDetailsDto
                    {
                        UserName = item.UserName,
                        Address = item.Address,
                        Email = item.Email,
                        Id = item.Id,
                        EmailConfirmed = item.EmailConfirmed,
                        FirstName = item.FirstName,
                        LastName = item.LastName,
                        Bio = item.Bio == null ? "N/A" : item.Bio,
                        ProfileImage = item.ProfileImage,
                        Orders = item.Orders,
                        UserCourses = item.UserCourses,
                        CurrentBalance=(double)item.CurrentBalance,
                        RoleId= item.RolesId,
                        RoleName=item.Roles.RoleName
                    };
                    userLists.Add(user);

                }
            return Ok(userLists);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var Course = await _userRepository.GetOneAsync(x => x.Id == id);
            if (Course != null)

                return Ok(Course.ContentResult);
            return NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var response = await _userRepository.DeleteOneAsync(x => x.Id == id);
            if (response.StausCode == Infrastructure.Models.StatusCode.Ok)
                return Ok();
            return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, UserDto userEntity)
        {
            var user = new UserEntity
            {
                UserName = userEntity.UserName,
                Email = userEntity.Email,
                Id = userEntity.Id,
                EmailConfirmed = userEntity.EmailConfirmed,
                FirstName = userEntity.FirstName,
                LastName = userEntity.LastName,
                Bio = userEntity.Bio == null ? "N/A" : userEntity.Bio,
                ProfileImage = userEntity.ProfileImage,
                CurrentBalance= userEntity.CurrentBalance,
                RolesId = userEntity.RoleId,
            };
            var response = await _userRepository.UPdateOneAsync(x => x.Id == id, user);
            if (response.StausCode == Infrastructure.Models.StatusCode.Ok)
                return Ok("Updated");
            return NotFound();
        }

    }
}
