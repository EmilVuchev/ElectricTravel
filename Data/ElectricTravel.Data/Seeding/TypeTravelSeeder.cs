﻿namespace ElectricTravel.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using ElectricTravel.Data.Models.Advertisement;
    using ElectricTravel.Data.Seeding.Contracts;

    public class TypeTravelSeeder : ISeeder
    {
        public async Task SeedAsync(ElectricTravelDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.TypeTravels.Any())
            {
                return;
            }

            await dbContext.TypeTravels.AddAsync(new TypeTravel { Name = "SingleTrip" });
            await dbContext.TypeTravels.AddAsync(new TypeTravel { Name = "WeeklyTrip" });
            await dbContext.TypeTravels.AddAsync(new TypeTravel { Name = "MonthlyTrip" });
        }
    }
}
