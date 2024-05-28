using Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class EmailController : Controller
    {
        private readonly UserRepository _userRepository;

        public EmailController(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> EmailConfirmed(string email)
        {
            ViewBag.Email = email;
            var user=await _userRepository.GetOneUserAsync(x => x.Email == email);
            if (user is not null)
            {
                user.EmailConfirmed = true;
                await _userRepository.UPdateOneAsync(x => x.Email == email,user);
            }
            return View();
        }
    }
}
