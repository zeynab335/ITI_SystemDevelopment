using D03_API.Models;
using Microsoft.EntityFrameworkCore;

namespace D03_API.Context
{
    public class APIContext:DbContext
    {
        public APIContext(DbContextOptions options):base(options) { }

        public virtual DbSet<Department> Departments { get; set; }

        public virtual DbSet<Instructor> Instructors { get; set; }
    }
}
