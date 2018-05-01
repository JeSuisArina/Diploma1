using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(InternalAuditSystem.Startup))]
namespace InternalAuditSystem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
