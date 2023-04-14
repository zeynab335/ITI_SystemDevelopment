
using Microsoft.EntityFrameworkCore;
using Tickets.BL.Managers.TicketsManager;
using Tickets.DAL.Data.Context;
using Tickets.DAL.Repos.Developers;
using Tickets.DAL.Repos.Tickets;

namespace Tickets
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

           
            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            #region Database

            var connectionString = builder.Configuration.GetConnectionString("TicketsConn");
            builder.Services.AddDbContext<TicketsContext>(options
                => options.UseSqlServer(connectionString));

            #endregion


            #region Repos
            builder.Services.AddScoped<ITicketsRepo, TicketsRepo>();
            builder.Services.AddScoped<IDeveloperRepo, DeveloperRepo>();

            #endregion

            #region Managers
            builder.Services.AddScoped<ITicketManager, TicketManager>();

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