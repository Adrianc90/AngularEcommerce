using System.Linq;
using System.Threading.Tasks;
using Core.Entities.Identity;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Identity
{
    public class AppIdentityDbContextSeed
    {
        public static async Task SeedUserAsync(UserManager<AppUser> userManager)
        {
            if (!userManager.Users.Any())
            {
                var user = new AppUser
                {
                    DisplayName = "manager",
                    Email = "manager@test.com",
                    UserName = "manager",
                    Address = new Address
                    {
                        FirstName = "manager",
                        LastName = "manager",
                        Street = "manager",
                        City = "manager",
                        State = "manager",
                        ZipCode = "manager"
                    }
                };

                await userManager.CreateAsync(user, "Pa$$w0rd");
            }
        }
    }
}