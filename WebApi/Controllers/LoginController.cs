using Infrastructure.Entites;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApi.Dtos;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly UserManager<UserEntity> _userManager;
        private readonly SignInManager<UserEntity> _signInManager;
        private readonly JwtTokenGenerator _jwtTokenGenerator;
        private readonly UserRepository _userRepository;

        public LoginController(UserManager<UserEntity> userManager, SignInManager<UserEntity> signInManager,JwtTokenGenerator jwtTokenGenerator,UserRepository userRepository)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginDto request)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);
            if (user == null)
            {
                return NotFound("User not found");
            }

            var result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);
            if (result.Succeeded)
            {
                var userData= await _userRepository.GetOneUserAsync(x => x.UserName == user.UserName);
                if (userData.RolesId == 3)
                    return BadRequest("User not permitted to access admin panel");
                var token= _jwtTokenGenerator.GenerateToken(userData);
                return Ok(token);
            }
            else
            {
                return BadRequest("Invalid password");
            }
        }

    }
}
