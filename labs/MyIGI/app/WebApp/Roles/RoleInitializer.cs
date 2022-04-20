using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace WebApp.Roles
{
    public static class RoleInitializer
    {
        public static async Task InitializeAsync(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {

            var rolesName = new List<string>()
            {
                "Admin", "Moder", "User"
            };

            async void Action(string roleName)
            {
                if (await roleManager.FindByNameAsync(roleName) == null)
                {
                    await roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }
            rolesName.ForEach(Action);
            if (await userManager.FindByNameAsync("eduard@gmail.com") == null)
            {
                await CreateAdmin(userManager);
            }
            else
            {
                await DeleteAdmin(userManager);
                await CreateAdmin(userManager);
            }
        }

        private static async Task CreateAdmin(UserManager<IdentityUser> userManager)
        {
            var admin = new IdentityUser()
            {
                Email = "eduard@gmail.com",
                UserName = "eduard@gmail.com"
            };
            var result = await userManager.CreateAsync(admin, "Qwerty123_");
            Console.WriteLine(result.Succeeded);
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(admin, "Admin");
                var token = await userManager.GenerateEmailConfirmationTokenAsync(admin);
                await userManager.ConfirmEmailAsync(admin, token);
            }
        }

        private static async Task DeleteAdmin(UserManager<IdentityUser> userManager)
        {
            var admin = await userManager.FindByEmailAsync("eduard@gmail.com");
            var result = await userManager.DeleteAsync(admin);
            if (result.Succeeded)
            {
                Console.WriteLine("Succeeded");
            }
        }

        public static async Task ConfigureRoles(this IServiceCollection serviceCollection)
        {
            var serviceProvider = serviceCollection.BuildServiceProvider();
            var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
            var rolesManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            await InitializeAsync(userManager, rolesManager);
        }
    }
}