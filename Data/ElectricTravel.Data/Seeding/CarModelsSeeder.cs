namespace ElectricTravel.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using ElectricTravel.Data.Models.Car;
    using ElectricTravel.Data.Seeding.Contracts;

    public class CarModelsSeeder : ISeeder
    {
        public async Task SeedAsync(ElectricTravelDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Models.Any())
            {
                return;
            }

            await dbContext.Models.AddAsync(new Model { Name = "Model 3", MakeId = 1, Year = 2020 });
            await dbContext.Models.AddAsync(new Model { Name = "Model S", MakeId = 1, Year = 2020 });
            await dbContext.Models.AddAsync(new Model { Name = "ID 3", MakeId = 3, Year = 2020 });
            await dbContext.Models.AddAsync(new Model { Name = "XC40", MakeId = 2, Year = 2020 });
        }
    }
}
