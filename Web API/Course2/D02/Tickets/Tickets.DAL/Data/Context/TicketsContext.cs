using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tickets.DAL.Data.Models;

namespace Tickets.DAL.Data.Context
{
    public class TicketsContext: DbContext
    {
        // inject options
        public TicketsContext(DbContextOptions<TicketsContext> options):base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Developer> Developers { get; set; }
        public DbSet<Department> Departments { get; set; }


    }
}
