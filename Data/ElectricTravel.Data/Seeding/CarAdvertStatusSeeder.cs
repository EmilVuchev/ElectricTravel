namespace ElectricTravel.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using ElectricTravel.Data.Models.Advertisement;
    using ElectricTravel.Data.Seeding.Contracts;
    using Microsoft.EntityFrameworkCore.Internal;

    public class CarAdvertStatusSeeder : ISeeder
    {
        public async Task SeedAsync(ElectricTravelDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.CarAdvertStatus.Any())
            {
                return;
            }

            await dbContext.CarAdvertStatus.AddAsync(new CarAdvertStatus { Name = "ForSale" });
            await dbContext.CarAdvertStatus.AddAsync(new CarAdvertStatus { Name = "Sold" });
        }
    }
}
