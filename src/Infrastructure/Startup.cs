using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.eShopWeb.ApplicationCore.Interfaces;
using Microsoft.eShopWeb.Infrastructure.Data;
using Microsoft.eShopWeb.Infrastructure.Identity;
using Microsoft.eShopWeb.Infrastructure.Logging;
using Microsoft.eShopWeb.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(Microsoft.eShopWeb.Infrastructure.Startup))]
namespace Microsoft.eShopWeb.Infrastructure
{
    public class Startup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                services.AddIdentity<ApplicationUser, IdentityRole>()
                    .AddEntityFrameworkStores<AppIdentityDbContext>()
                    .AddDefaultTokenProviders();

                services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
                services.AddScoped(typeof(IAsyncRepository<>), typeof(EfRepository<>));

                services.AddScoped<IOrderRepository, OrderRepository>();

                services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));
                services.AddTransient<IEmailSender, EmailSender>();
            });
        }
    }
}
