namespace ElectricTravel.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using ElectricTravel.Data.Models.Advertisement;
    using ElectricTravel.Data.Seeding.Contracts;
    using Microsoft.EntityFrameworkCore.Internal;

    public class CurrencySeeder : ISeeder
    {
        public async Task SeedAsync(ElectricTravelDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Currencies.Any())
            {
                return;
            }

            await dbContext.Currencies.AddAsync(new Currency { Name = "Leva" });
            await dbContext.Currencies.AddAsync(new Currency { Name = "EUR" });
            await dbContext.Currencies.AddAsync(new Currency { Name = "USD" });
        }
    }
}
