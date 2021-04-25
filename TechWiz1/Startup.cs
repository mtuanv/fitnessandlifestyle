using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TechWiz1.Startup))]
namespace TechWiz1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
