using Infrastructure.Context;
using Infrastructure.Entites;
using Infrastructure.Factories;
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class UserRepository:GenericRepository<UserEntity>
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context):base(context) { _context = context; }

        public  async Task<IEnumerable<UserEntity>> GetAllUserListAsync()
        {
            try
            {
                IEnumerable<UserEntity> result = await _context.Users.Include(a=>a.Address).Include(x=>x.Roles).ToListAsync();

                return result;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public  async Task<UserEntity> GetOneUserAsync(Expression<Func<UserEntity, bool>> predict)
        {
            try
            {
                var result = await _context.Set<UserEntity>().Include(a => a.Address).Include(x => x.Roles).FirstOrDefaultAsync(predict);
                
                return result;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

       
    }
}
