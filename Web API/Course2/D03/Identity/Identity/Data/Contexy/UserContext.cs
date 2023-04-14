using Identity.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Identity.Data.Contexy
{
    public class UserContext:IdentityDbContext<Manager>
    {

        public UserContext(DbContextOptions<UserContext> options)
      : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // change tables names 
            builder.Entity<Manager>().ToTable("Manager");
            builder.Entity<IdentityUserClaim<string>>().ToTable("ManagerClaims");


        }
    }
}
