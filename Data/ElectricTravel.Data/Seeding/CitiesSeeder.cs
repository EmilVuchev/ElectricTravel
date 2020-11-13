namespace ElectricTravel.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using ElectricTravel.Data.Models.Location;
    using ElectricTravel.Data.Seeding.Contracts;

    public class CitiesSeeder : ISeeder
    {
        public async Task SeedAsync(ElectricTravelDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Cities.Any())
            {
                return;
            }

            await dbContext.Cities.AddAsync(new City { Name = "Sofia", RegionId = 1 });
            await dbContext.Cities.AddAsync(new City { Name = "Plovdiv", RegionId = 2 });
        }
    }
}
