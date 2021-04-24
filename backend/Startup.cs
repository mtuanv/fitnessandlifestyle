using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(backend.Startup))]
namespace backend
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
