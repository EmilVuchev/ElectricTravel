namespace ElectricTravel.Data.Seeding
{
    using System;
    using System.Threading.Tasks;

    public interface ISeeder
    {
        Task SeedAsync(ElectricTravelDbContext dbContext, IServiceProvider serviceProvider);
    }
}
