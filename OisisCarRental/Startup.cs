using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OisisCarRental.Startup))]
namespace OisisCarRental
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
