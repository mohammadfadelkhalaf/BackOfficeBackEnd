using Infrastructure.Context;
using Infrastructure.Entites;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Dtos;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserCoursesController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly UserCoursesRepository _userCoursesRepository;

        public UserCoursesController(DataContext context, UserCoursesRepository userCoursesRepository)
        {
            _context = context;
            _userCoursesRepository = userCoursesRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var Orders = await _userCoursesRepository.GetAllAsync();

            if (Orders != null)
                return Ok(Orders);
            return NotFound();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var Course = await _userCoursesRepository.GetOneAsync(x => x.Id == id);
            if (Course != null)
                return Ok(Course);
            return NotFound();
        }

        [HttpGet("GetCourseDetailsByUserId/{userId}")]
        public async Task<IActionResult> GetOrderDetailsByUserId(string userId)
        {
            var Course = await _userCoursesRepository.GetUserCourseWithDetails(userId);
            if (Course != null)
                return Ok(Course);
            return NotFound();
        }

        [HttpGet("GetCourseDetailsByUserIdAndBatchId/userId/{userId}/batchId/{batchId}")]
        public async Task<IActionResult> GetCourseDetailsByUserIdAndBatchId(string userId,int batchId)
        {
            var Course = await _userCoursesRepository.GetCourseDetailsByUserIdAndBatchId(userId, batchId);
            if (Course != null)
                return Ok(Course);
            return NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _userCoursesRepository.DeleteOneAsync(x => x.Id == id);
            if (response.StausCode == Infrastructure.Models.StatusCode.Ok)
                return Ok();
            return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, OrderDto entity)
        {
            //var orderentity = new OrderEntity
            //{
            //    UserId = entity.UserId,
            //    BatchId = entity.CourseBatchId,
            //    PaidAmount = entity.PaidAmount,
            //    IsActive = true,
            //    IsCancel = false,
            //    CreatorId = entity.UserId,
            //    ModifierId = entity.UserId,
            //    CreationDate = DateTime.Now,
            //    ModificationDate = DateTime.Now
            //};
            //var response = await _userCoursesRepository.UPdateOneAsync(x => x.Id == id, orderentity);
            //if (response.StausCode == Infrastructure.Models.StatusCode.Ok)
            //    return Ok("Updated");
            return NotFound();
        }


    }
}
