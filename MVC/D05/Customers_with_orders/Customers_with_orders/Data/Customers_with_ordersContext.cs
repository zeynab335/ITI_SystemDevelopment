using Customers_with_orders.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Customers_with_orders.Data
{
    public class Customers_with_ordersContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public Customers_with_ordersContext() : base("name=Customers_with_ordersContext")
        {
        }
    
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        
    }
}
