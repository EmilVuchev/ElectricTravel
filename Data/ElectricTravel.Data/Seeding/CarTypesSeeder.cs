namespace ElectricTravel.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using ElectricTravel.Data.Models.Car;
    using ElectricTravel.Data.Seeding.Contracts;

    public class CarTypesSeeder : ISeeder
    {
        public async Task SeedAsync(ElectricTravelDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.CarTypes.Any())
            {
                return;
            }

            await dbContext.CarTypes.AddAsync(new CarType { Name = "Sedan" });
            await dbContext.CarTypes.AddAsync(new CarType { Name = "Coupe" });
            await dbContext.CarTypes.AddAsync(new CarType { Name = "Sports car" });
            await dbContext.CarTypes.AddAsync(new CarType { Name = "Station wagon" });
            await dbContext.CarTypes.AddAsync(new CarType { Name = "Hatchback" });
            await dbContext.CarTypes.AddAsync(new CarType { Name = "Convertible" });
            await dbContext.CarTypes.AddAsync(new CarType { Name = "SUV" });
            await dbContext.CarTypes.AddAsync(new CarType { Name = "Minivan" });
        }
    }
}
