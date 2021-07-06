using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(SoftToyShop.Areas.Identity.IdentityHostingStartup))]
namespace SoftToyShop.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}