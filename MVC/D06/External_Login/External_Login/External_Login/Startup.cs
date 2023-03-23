using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(External_Login.Startup))]
namespace External_Login
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
