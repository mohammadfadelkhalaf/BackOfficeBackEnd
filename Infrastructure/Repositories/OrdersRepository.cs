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
    public class OrdersRepository : GenericRepository<OrderEntity>
    {
        private readonly DataContext _context;

        public OrdersRepository(DataContext context) : base(context) { _context = context; }
        public async Task<List<OrderInfo>> GetOrderWithDetails()
        {
            var userInfos = await _context.Orders
                .Include(x => x.Batch).ThenInclude(x => x.Course)
                .Include(x => x.User)
                .AsNoTracking()
                .Select(order => new OrderInfo
                {
                    Id = order.Id,
                    UserId = order.User.Id,
                    UserName = order.User.UserName,
                    Email = order.User.Email,
                    Batch = order.Batch,
                    CourseBatchId = order.BatchId,
                    PaidAmount = order.PaidAmount
                })
                .ToListAsync();
            return userInfos;
        }

        public async Task<OrderInfo> GetSingleOrderWithDetails(int id)
        {
            var userInfo = await _context.Orders
                .Include(x => x.Batch).ThenInclude(x => x.Course)
                .Include(x => x.User)
                .Where(x => x.Id == id)
                .AsNoTracking()
                .Select(order => new OrderInfo
                {
                    Id = order.Id,
                    UserId = order.User.Id,
                    UserName = order.User.UserName,
                    Email = order.User.Email,
                    Batch = order.Batch,
                    CourseBatchId = order.BatchId,
                    PaidAmount = order.PaidAmount
                })
                .FirstOrDefaultAsync();
            return userInfo;
        }

        public async Task<List<OrderInfo>> GetOrderWithDetailsByUserId(string userId)
        {
            var userInfo = await _context.Orders
                .Include(x => x.Batch).ThenInclude(x => x.Course)
                .Include(x => x.User)
                .Where(x => x.UserId == userId)
                .AsNoTracking()
                .Select(order => new OrderInfo
                {
                    Id = order.Id,
                    UserId = order.User.Id,
                    UserName = order.User.UserName,
                    Email = order.User.Email,
                    Batch = order.Batch,
                    CourseBatchId = order.BatchId,
                    PaidAmount = order.PaidAmount
                })
                .ToListAsync();
            return userInfo;
        }
    }
}
