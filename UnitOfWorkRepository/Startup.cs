using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(UnitOfWorkRepository.Startup))]
namespace UnitOfWorkRepository
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
