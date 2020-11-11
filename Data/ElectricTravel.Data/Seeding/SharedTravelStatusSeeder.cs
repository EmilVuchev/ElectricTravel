namespace ElectricTravel.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using ElectricTravel.Data.Models.Advertisement;
    using ElectricTravel.Data.Seeding.Contracts;

    public class SharedTravelStatusSeeder : ISeeder
    {
        public async Task SeedAsync(ElectricTravelDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.SharedTravelStatus.Any())
            {
                return;
            }

            await dbContext.SharedTravelStatus.AddAsync(new SharedTravelStatus { Name = "Active" });
            await dbContext.SharedTravelStatus.AddAsync(new SharedTravelStatus { Name = "Inactive" });
        }
    }
}
