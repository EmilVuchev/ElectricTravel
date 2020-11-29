namespace ElectricTravel.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using ElectricTravel.Data.Models.Car;
    using ElectricTravel.Data.Seeding.Contracts;

    public class CarMakesSeeder : ISeeder
    {
        public async Task SeedAsync(ElectricTravelDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Makes.Any())
            {
                return;
            }

            await dbContext.Makes.AddAsync(new Make { Name = "Tesla" });
            await dbContext.Makes.AddAsync(new Make { Name = "Volvo" });
            await dbContext.Makes.AddAsync(new Make { Name = "Volkswagen" });
        }
    }
}
