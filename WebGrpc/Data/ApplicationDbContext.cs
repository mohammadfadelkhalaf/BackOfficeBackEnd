using Microsoft.EntityFrameworkCore;
using WebGrpc.Models;

namespace WebGrpc.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Course> Courses { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
    }
}
