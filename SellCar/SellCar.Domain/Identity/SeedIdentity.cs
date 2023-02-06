using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace SellCar.Domain.Identity
{
    public static class SeedIdentity
    {
        public static async Task Seed(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            var username = configuration["Data:AdminUser:username"];
            var email = configuration["Data:AdminUser:email"];
            var password = configuration["Data:AdminUser:password"];
            var role = configuration["Data:AdminUser:role"];

            if (await userManager.FindByNameAsync(username) == null)
            {
                await roleManager.CreateAsync(new IdentityRole(role));
                await roleManager.CreateAsync(new IdentityRole("User"));

                var admin = new User()
                {
                    UserName = username,
                    Email = email,
                    FirstName = "admin",
                    LastName = "admin",
                    EmailConfirmed = true
                };
                var user = new User
                {
                    UserName = "user",
                    Email = "user@hotmail.com",
                    FirstName = "user",
                    LastName = "user",
                    EmailConfirmed = true,
                    Id = "1",
                };
                var userResult = await userManager.CreateAsync(user, password);
                if (userResult.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "User");
                }

                var adminResult = await userManager.CreateAsync(admin, password);
                if (adminResult.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, role);
                }
            }
        }
    }
}
