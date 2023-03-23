using Microsoft.EntityFrameworkCore;
using Task2.Model;

namespace Task2.DataContext
{
    public class StuContext : DbContext
    {
        public StuContext(DbContextOptions<StuContext> options) : base(options) { }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }


    }
}
