using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dragonportal235.Data;
using Dragonportal235.Helper;
using Dragonportal235.Models;
using Dragonportal235.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Dragonportal235
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            await DataHelper.ManageDataAsync(host);
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var loggerFactory = services.GetRequiredService<ILoggerFactory>();
                try
                {
                    var context = services.GetRequiredService<ApplicationDbContext>();
                    var userManager = services.GetRequiredService<UserManager<FPUser>>();
                    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
                    var imageService = services.GetRequiredService<IImageService>();
                    await ContextSeed.SeedRolesAsync(roleManager);
                    await ContextSeed.SeedDefaultUserAsync(userManager, imageService);


                }
                catch (Exception ex)
                {
                    var logger = loggerFactory.CreateLogger<Program>();
                    logger.LogError(ex, "An error occurred seeding the DB.");
                }
            }
            host.Run();

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
