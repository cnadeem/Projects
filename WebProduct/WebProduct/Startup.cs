using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebProduct.Startup))]
namespace WebProduct
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
