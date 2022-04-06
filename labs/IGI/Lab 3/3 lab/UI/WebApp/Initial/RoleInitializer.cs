using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace WebApp.Initial
{
    public class RoleInitializer
    {
        public static async Task InitializeAsync(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {

            var rolesName = new List<string>()
            {
                "Admin", "Moder", "DefaultUser"
            };

            async void Action(string roleName)
            {
                if (await roleManager.FindByNameAsync(roleName) == null)
                {
                    await roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }
            rolesName.ForEach(Action);
            if (await userManager.FindByNameAsync("vital@gmail.com") == null)
            {
                await CreateAdmin(userManager);
            }
            
            
        }

        private static async Task CreateAdmin(UserManager<IdentityUser> userManager)
        {
            var admin = new IdentityUser()
            {
                Email = "vital@gmail.com",
                UserName = "vital@gmail.com"
            };
            var result = await userManager.CreateAsync(admin, "Qwerty123");
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(admin, "Admin");
            }
        }
    }
}