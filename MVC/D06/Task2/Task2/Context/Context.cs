using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Task2.Models;

namespace Task2
{
    public class Context:DbContext
    {
        public Context() :base("Conn") { }

        public DbSet<User> Users { get; set; }
    }
}