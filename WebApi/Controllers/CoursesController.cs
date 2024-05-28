using Azure;
using Grpc.Core;
using Infrastructure.Context;
using Infrastructure.Entites;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Dtos;
using WebApi.Models;
using WebGrpc;
using static Grpc.Core.Metadata;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly ILogger<CoursesController> _logger;
        private readonly Courses.CoursesClient _grpcClient;
        private readonly CourseRepository _courseRepository;
        private readonly EmailServices _emailServices;

        public CoursesController(DataContext context, ILogger<CoursesController> logger, Courses.CoursesClient grpcClient,CourseRepository courseRepository, EmailServices emailServices)
        {
            _context = context;
            _logger = logger;
            _grpcClient = grpcClient;
            _courseRepository = courseRepository;
            _emailServices = emailServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var Courses = await _courseRepository.GetCoursesWithDetails();


            if (Courses.Count != 0)
                return Ok(Courses);
            return NotFound();
        }

        [HttpGet("GetCoursesGrpc")]
        public async Task<IActionResult> GetCourses()
        {
            try
            {
                var response = await _grpcClient.GetCoursesAsync(new CourseRequest());
                var courses = response.Courses.Select(c => new
                {
                    Id = c.Id,
                    Title = c.Title,
                    ImageName = c.ImageName,
                    Author = c.Author
                }).ToList();

                return Ok(courses);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
           
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var Course = await _courseRepository.GetOneAsync(x => x.Id == id);
            if (Course != null)
                return Ok(Course.ContentResult);
            return NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _courseRepository.DeleteOneAsync(x => x.Id == id);
            if (response.StausCode == Infrastructure.Models.StatusCode.Ok)
                return Ok();
            return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CourseDto entity)
        {
            var courseEntity = new CourseEntity
            {
                Id=entity.Id,
                Title = entity.Title,
                Price = entity.Price,
                DisCountPrice = entity.DisCountPrice,
                TotalHours = entity.Hours,
                //ImageName = "01.jpg",
                ImageName = entity.ImageName,
                IsBestSeller = entity.IsBestSeller,
                LikesInNumbers = entity.LikesInNumbers,
                LikesInProcent = entity.LikesInProcent,
                Author = entity.Author,
                CreatorId = entity.CreatorId,
                ModifierId = entity.ModifierId,
                CreationDate = DateTime.Now,
                ModificationDate = DateTime.Now
            };
            var response = await _courseRepository.UPdateOneAsync(x => x.Id == id, courseEntity);
            if (response.StausCode == Infrastructure.Models.StatusCode.Ok)
                return Ok("Updated");
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> CreateOneCourse(CourseDto entity)
        {
            if (ModelState.IsValid)
            {
                var courseentity = new CourseEntity
                {
                    Title = entity.Title,
                    Price = entity.Price,
                    DisCountPrice = entity.DisCountPrice,
                    TotalHours = entity.Hours,
                    //ImageName = "01.jpg",
                    ImageName = entity.ImageName,
                    IsBestSeller = entity.IsBestSeller,
                    LikesInNumbers = entity.LikesInNumbers,
                    LikesInProcent = entity.LikesInProcent,
                    Author = entity.Author,
                    CreatorId = entity.CreatorId,
                    ModifierId = entity.ModifierId,
                    CreationDate = DateTime.Now,
                    ModificationDate = DateTime.Now
                };
                await _courseRepository.CreateAsync(courseentity);

                Course course = courseentity;
                return Created("", course);
            }
            return BadRequest();
        }
    }
}
