namespace ElectricTravel.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using ElectricTravel.Data.Models.Location;
    using ElectricTravel.Data.Seeding.Contracts;

    public class RegionSeeder : ISeeder
    {
        public async Task SeedAsync(ElectricTravelDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Regions.Any())
            {
                return;
            }

            await dbContext.Regions.AddAsync(new Region { Name = "Sofia Region" });
            await dbContext.Regions.AddAsync(new Region { Name = "Plovdiv Region" });
        }
    }
}
