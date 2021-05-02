using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities.Identity;
using Infrastructure.Data;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace API
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using(var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                try{
                    var context = services.GetRequiredService<STContext>();

                    await context.Database.MigrateAsync();

                    await STContextSeed.SeedAsync(context);

                    var userManager = services.GetRequiredService<UserManager<AppUser>>();
                    var identityContex = services.GetRequiredService<AppIdentityDbContext>();
                    await identityContex.Database.MigrateAsync();
                    await AppIdentityDbContextSeed.SeedUderAsync(userManager);
                    
                }catch(Exception ex)
                {
                    
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
