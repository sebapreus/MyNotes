using Microsoft.Owin;
using MyNotes;
using Owin;

[assembly: OwinStartupAttribute(typeof(Startup))]
namespace MyNotes
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
