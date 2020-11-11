namespace ElectricTravel.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using ElectricTravel.Data.Models.Charging;
    using ElectricTravel.Data.Seeding.Contracts;

    public class CategorySeeder : ISeeder
    {
        public async Task SeedAsync(ElectricTravelDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Categories.Any())
            {
                return;
            }

            await dbContext.Categories.AddAsync(new Category { Name = "AC" });
            await dbContext.Categories.AddAsync(new Category { Name = "DC" });
        }
    }
}
