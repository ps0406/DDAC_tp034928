using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DDAC_TP034928.Startup))]
namespace DDAC_TP034928
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
