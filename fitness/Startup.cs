using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(fitness.Startup))]
namespace fitness
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
