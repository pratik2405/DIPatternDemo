using DIPatternDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace DIPatternDemo.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> op):base(op)
        {
            
        }
        public DbSet<Employee> ?Employees { get; set; }

        public DbSet<Student> ?Students { get; set; }
    }
}
