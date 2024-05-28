using Infrastructure.Context;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;
        private readonly RoleRepository _roleRepository;
        private readonly EmailServices _emailServices;

        public RoleController( ILogger<UsersController> logger, RoleRepository roleRepository)
        {
            _logger = logger;
            _roleRepository = roleRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRoles()
        {
            var Course = await _roleRepository.GetAllAsync();
            if (Course != null)

                return Ok(Course.ContentResult);
            return NotFound();
        }
    }
}
