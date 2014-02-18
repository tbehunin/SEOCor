using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SEOCor.Web.Startup))]
namespace SEOCor.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
