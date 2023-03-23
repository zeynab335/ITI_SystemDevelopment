namespace Task1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();

            //app.MapGet("/", () => "Hello World!");

            //app.MapControllerRoute("employee" , "{Controllers=employees}/{Action=Index}/{Id?}");

            app.UseRouting();
            app.UseEndpoints(endpoints => { endpoints.MapControllerRoute(name: "default", pattern: "{controller}/{action}/{id?}", defaults: new { controller = "employee", action = "Index" }); });
            app.Run();
        }
    }
}