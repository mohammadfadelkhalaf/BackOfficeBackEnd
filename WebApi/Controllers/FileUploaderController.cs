using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileUploaderController : ControllerBase
    {
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _hostingEnvironment;

        public FileUploaderController(Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpPost]
        public async Task<IActionResult> postFile(IFormFile file)
        {
            try
            {
                var filePath = Path.Combine(_hostingEnvironment.ContentRootPath, "Resources/images", file.FileName);
                using var fileStream = new FileStream(filePath, FileMode.Create);
                await file.CopyToAsync(fileStream);
                return Ok(file.FileName);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message); 
            }
            
        }
    }
}
