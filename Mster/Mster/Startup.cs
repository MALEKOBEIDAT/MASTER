using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Mster.Startup))]
namespace Mster
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
