using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AuditControlSystem.Startup))]
namespace AuditControlSystem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
