using Infrastructure.Context;
using Infrastructure.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class RoleRepository : GenericRepository<RoleEntity>
    {
        private readonly DataContext _context;

        public RoleRepository(DataContext context) : base(context) { _context = context; }
    }
}
