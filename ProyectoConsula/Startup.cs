using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProyectoConsula.Startup))]
namespace ProyectoConsula
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
