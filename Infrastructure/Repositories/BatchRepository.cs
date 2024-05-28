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
    public class BatchRepository : GenericRepository<BatchEntity>
    {
        private readonly DataContext _context;

        public BatchRepository(DataContext context) : base(context) { _context = context; }
        public async Task<List<BatchEntity>> GetBatchesWithDetails()
        {
            var Batches = await _context.Batches.Include(c=>c.Course).Include(x=>x.UserCourses)
               .AsNoTracking()
               .ToListAsync();
            return Batches.ToList();
        }


    }
}
