using Grpc.Core;
using Microsoft.EntityFrameworkCore;
using WebGrpc.Data;

namespace WebGrpc.Services
{
    public class CourseService : Courses.CoursesBase
    {
        private readonly ILogger<CourseService> _logger;
        private readonly ApplicationDbContext _context;
        public CourseService(ILogger<CourseService> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }
        public override async Task<CourseReplyList> GetCourses(CourseRequest request, ServerCallContext context)
        {
            var courses = await _context.Courses
                                        .Select(c => new CourseReply
                                        {
                                            Id = c.Id,
                                            Title = c.Title,
                                            ImageName = c.ImageName,
                                            Author = c.Author
                                        })
                                        .ToListAsync();

            var response = new CourseReplyList();
            response.Courses.AddRange(courses);

            return response;
        }
    }
}
