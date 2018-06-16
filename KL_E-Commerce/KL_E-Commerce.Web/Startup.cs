using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(KL_E_Commerce.Web.Startup))]
namespace KL_E_Commerce.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
