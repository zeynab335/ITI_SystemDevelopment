
using Identity.Data.Contexy;
using Identity.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

namespace Identity
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            #region Default 
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            #endregion

            #region  Database Services
            // add connectionstring 
            var connectionString = builder.Configuration.GetConnectionString("Identity");
            builder.Services.AddDbContext<UserContext>(
                options => options.UseSqlServer(connectionString)
            );

            #endregion

            #region Identity

            builder.Services.AddIdentity<Manager, IdentityRole>(options =>
            {
                options.Password.RequiredUniqueChars = 3;
                options.Password.RequireUppercase = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = false;

                options.User.RequireUniqueEmail = true;
            })
                .AddEntityFrameworkStores<UserContext>();

            #endregion

            #region Authentication
            builder.Services.AddAuthentication(options =>
            {
                // used Authenication schema
                options.DefaultAuthenticateScheme= "authentication";

                // used challenge Authentication schema ==> return status code
                options.DefaultChallengeScheme = "authentication";

            }).AddJwtBearer("authentication", options =>
            {
                // check if user is authenticated using secret key
                var secretKeyString = builder.Configuration.GetValue<string>("SecretKey") ?? string.Empty;
                var secretkeyInBytes = Encoding.ASCII.GetBytes(secretKeyString);
                var SymmetricSecurityKeyValue = new SymmetricSecurityKey(secretkeyInBytes);

                options.TokenValidationParameters = new TokenValidationParameters
                {
                    IssuerSigningKey = SymmetricSecurityKeyValue,
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            #endregion

            #region Authorization
            builder.Services.AddAuthorization(option =>
            {
                // Policy for User

                option.AddPolicy("User", policy =>
                    policy.RequireClaim(ClaimTypes.Role, "User")
                    .RequireClaim(ClaimTypes.NameIdentifier)
                );

                // Policy for Admin
                option.AddPolicy("Admin", policy =>
                    policy.RequireClaim(ClaimTypes.Role, "Admin")
                    .RequireClaim(ClaimTypes.NameIdentifier)
                );
            });
            #endregion

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}