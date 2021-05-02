using Core.Entities.Identity;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace API.Extensions
{
    public static class IdentityServiceExtensions
    {
        public static IServiceCollection AddIdentityService(this IServiceCollection service, IConfiguration config)
        {
             var builder = service.AddIdentityCore<AppUser>();

             builder.AddEntityFrameworkStores<AppIdentityDbContext>();
             builder.AddSignInManager<SignInManager<AppUser>>();

             service.AddAuthentication();

             return service;
        }
    }
}