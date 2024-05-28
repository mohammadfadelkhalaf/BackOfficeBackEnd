using Infrastructure.Context;
using Infrastructure.Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class CourseRepository : GenericRepository<CourseEntity>
    {
        private readonly DataContext _context;

        public CourseRepository(DataContext context) : base(context) { _context = context; }

        public async Task<List<CourseEntity>> GetCoursesWithDetails()
        {
            var Courses = await _context.Courses
               .Include(x =>
                   x.Batches
                   .Where(x => x.IsActive == true && x.IsExpire == false)
                   .OrderByDescending(x => x.StartDate))
               .AsNoTracking()
               .ToListAsync();
            return Courses.ToList();
        }

    }
}
