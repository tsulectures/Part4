using System.Linq;
using System.Threading.Tasks;
using Core.Entities.Identity;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Identity
{
    public class AppIdentityDbContextSeed
    {
        public static async Task SeedUderAsync(UserManager<AppUser> userManager)
        {
            if(!userManager.Users.Any())
            {
                var user = new AppUser{
                    DispayName = "nika",
                    Email = "nika@test.com",
                    UserName = "nika@test.com",
                    Address = new Address{
                        FirstName = "nika",
                        LastName = "nikolaze",
                        Street = "pekini",
                        City = "Tbilisi",
                        Region = "Tbilisi",
                    }
                };
                await userManager.CreateAsync(user, "Pa$$w0rd");
            }
        }
    }
}