using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(InternetProg.Startup))]
namespace InternetProg
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
         
        }
    }
}
