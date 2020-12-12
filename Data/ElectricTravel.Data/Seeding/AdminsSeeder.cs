namespace ElectricTravel.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using ElectricTravel.Common;
    using ElectricTravel.Data.Models.User;
    using ElectricTravel.Data.Seeding.Contracts;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.DependencyInjection;

    public class AdminsSeeder : ISeeder
    {
        public async Task SeedAsync(ElectricTravelDbContext dbContext, IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider
                        .GetRequiredService<UserManager<ElectricTravelUser>>();

            var admin = await userManager
                .FindByEmailAsync("gosho_admin@abv.bg");

            if (admin == null)
            {
                admin = new ElectricTravelUser()
                {
                    UserName = "GoshoAdmin",
                    Email = "gosho_admin@abv.bg",
                };

                var result = await userManager
                     .CreateAsync(admin, "123456Gosho");

                if (result.Succeeded)
                {
                    await userManager
                        .AddToRoleAsync(admin, GlobalConstants.AdministratorRoleName);
                }
            }
        }
    }
}
