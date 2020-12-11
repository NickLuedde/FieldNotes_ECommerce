using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FieldNotes_ECommerce.WebUI.Startup))]
namespace FieldNotes_ECommerce.WebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
