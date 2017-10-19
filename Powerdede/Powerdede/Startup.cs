using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Powerdede.Startup))]
namespace Powerdede
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
