using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProblemShare.Web.Startup))]
namespace ProblemShare.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
