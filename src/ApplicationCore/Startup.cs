using Microsoft.AspNetCore.Hosting;
using Microsoft.eShopWeb.ApplicationCore.Interfaces;
using Microsoft.eShopWeb.ApplicationCore.Services;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(Microsoft.eShopWeb.ApplicationCore.Startup))]
namespace Microsoft.eShopWeb.ApplicationCore
{
    public class Startup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                services.AddScoped<IOrderService, OrderService>();
                services.AddScoped<IBasketService, BasketService>();
            });
        }
    }
}
