using Infrastructure.Context;
using Infrastructure.Dtos;
using Infrastructure.Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class UserCoursesRepository:GenericRepository<UserCourseEntity>
    {
        private readonly DataContext _context;

        public UserCoursesRepository(DataContext context) : base(context) { _context = context; }
        public async Task<List<UserCourseEntity>> GetUserCourseWithDetails(string userId)
        {
            var userInfos = await _context.UserCourses
                .Include(x=>x.Batch).ThenInclude(x=>x.Course)
                .Where(x=>x.UserId== userId)
                .ToListAsync();
            return userInfos;
        }
        public async Task<List<UserCourseEntity>> GetCourseDetailsByUserIdAndBatchId(string userId,int batchId)
        {
            var userInfos = await _context.UserCourses
                .Include(x => x.Batch).ThenInclude(x => x.Course)
                .Where(x => x.UserId == userId && x.BatchId==batchId)
                .ToListAsync();
            return userInfos;
        }
    }
}
