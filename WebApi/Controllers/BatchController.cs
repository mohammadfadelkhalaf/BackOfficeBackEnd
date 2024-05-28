using Infrastructure.Context;
using Infrastructure.Entites;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Dtos;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BatchController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly ILogger<CoursesController> _logger;
        private readonly BatchRepository _batchRepository;
        private readonly EmailServices _emailServices;

        public BatchController(DataContext context, ILogger<CoursesController> logger, BatchRepository batchRepository, EmailServices emailServices)
        {
            _context = context;
            _logger = logger;
            _batchRepository = batchRepository;
            _emailServices = emailServices;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var Courses = await _batchRepository.GetBatchesWithDetails();

            if (Courses.Count()>0)
                return Ok(Courses);
            return NotFound();
        }
         

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var Course = await _batchRepository.GetOneAsync(x => x.Id == id);
            if (Course != null)
                return Ok(Course);
            return NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _batchRepository.DeleteOneAsync(x => x.Id == id);
            if (response.StausCode == Infrastructure.Models.StatusCode.Ok)
                return Ok();
            return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, BatchDto entity)
        {
            var batchEntity = new BatchEntity
            {
                Id=entity.Id,
                BatchName = entity.BatchName,
                CourseId = entity.CourseId,
                StartDate = entity.StartDate,
                IsActive = entity.IsActive,
                IsExpire = entity.IsExpire,
                MaxMemberCount = entity.MaxMemberCount
            };
            var response = await _batchRepository.UPdateOneAsync(x => x.Id == id, batchEntity);
            if (response.StausCode == Infrastructure.Models.StatusCode.Ok)
                return Ok("Updated");
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> CreateOneCourse(BatchDto entity)
        {
            if (ModelState.IsValid)
            {
                var batchEntity = new BatchEntity
                {
                    BatchName = entity.BatchName,
                    CourseId = entity.CourseId,
                    StartDate=entity.StartDate,
                    IsActive=entity.IsActive,
                    IsExpire=entity.IsExpire,
                    MaxMemberCount= entity.MaxMemberCount
                };
                await _batchRepository.CreateAsync(batchEntity);

                return Created("", batchEntity);
            }
            return BadRequest();
        }
    }
}
