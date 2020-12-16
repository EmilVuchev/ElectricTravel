namespace ElectricTravel.Services.Data.Tests
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Threading.Tasks;

    using ElectricTravel.Data;
    using ElectricTravel.Data.Models.Advertisement;
    using ElectricTravel.Data.Repositories;
    using ElectricTravel.Services.Mapping;
    using ElectricTravel.Web.ViewModels.TypeTravels;
    using Microsoft.EntityFrameworkCore;
    using Xunit;

    public class TypeOfTravelServiceTests
    {
        public TypeOfTravelServiceTests()
        {
            this.InitializeMapper();
        }

        [Fact]
        public async Task CheckIfGetAllReturnsCorrectCount()
        {
            var list = new List<TypeTravel>();

            var options = new DbContextOptionsBuilder<ElectricTravelDbContext>()
                             .UseInMemoryDatabase(databaseName: "TypesTestDb").Options;
            using var dbContext = new ElectricTravelDbContext(options);

            using var repo = new EfDeletableEntityRepository<TypeTravel>(dbContext);
            var service = new TypeOfTravelService(repo);

            var typeName = "Weekly";
            await service.CreateAsync(typeName);

            var travelTypes = await service.GetAll<TypeTravelViewModel>();

            var expectedResult = 1;
            var actualResult = travelTypes.Count();

            Assert.Equal(expectedResult, actualResult);
        }

        private void InitializeMapper() => AutoMapperConfig.
           RegisterMappings(Assembly.Load("ElectricTravel.Web.ViewModels"));
    }
}
