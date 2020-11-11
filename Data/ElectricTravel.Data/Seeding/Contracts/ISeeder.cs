namespace ElectricTravel.Data.Seeding.Contracts
{
    using System;
    using System.Threading.Tasks;

    public interface ISeeder
    {
        Task SeedAsync(ElectricTravelDbContext dbContext, IServiceProvider serviceProvider);
    }
}
