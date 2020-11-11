namespace ElectricTravel.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using ElectricTravel.Data.Models.Multimedia;
    using ElectricTravel.Data.Seeding.Contracts;

    public class ImageTypeSeeder : ISeeder
    {
        public async Task SeedAsync(ElectricTravelDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.ImageTypes.Any())
            {
                return;
            }

            await dbContext.ImageTypes.AddAsync(new ImageType { Name = "UserPicture" });
            await dbContext.ImageTypes.AddAsync(new ImageType { Name = "CarExterior" });
            await dbContext.ImageTypes.AddAsync(new ImageType { Name = "CarInterior" });
            await dbContext.ImageTypes.AddAsync(new ImageType { Name = "ChargingStation" });
        }
    }
}
