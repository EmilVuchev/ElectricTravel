namespace ElectricTravel.Services.Data.Tests
{
    using System.Linq;
    using System.Reflection;
    using System.Threading.Tasks;

    using ElectricTravel.Data;
    using ElectricTravel.Data.Models.Location;
    using ElectricTravel.Data.Repositories;
    using ElectricTravel.Services.Data.Contracts;
    using ElectricTravel.Services.Mapping;
    using ElectricTravel.Web.InputViewModels.Cities;
    using ElectricTravel.Web.ViewModels.Cities;
    using Microsoft.EntityFrameworkCore;
    using Xunit;

    public class CitiesServiceTests
    {
        ////public void GetCountShouldReturnCorrectNumber()
        ////{
        ////    var repository = new Mock<IDeletableEntityRepository<Setting>>();
        ////    repository.Setup(r => r.All()).Returns(new List<Setting>
        ////                                                {
        ////                                                    new Setting(),
        ////                                                    new Setting(),
        ////                                                    new Setting(),
        ////                                                }.AsQueryable());
        ////    var service = new SettingsService(repository.Object);
        ////    Assert.Equal(3, service.GetCount());
        ////    repository.Verify(x => x.All(), Times.Once);
        ////}

        private ElectricTravelDbContext dbContext;
        private EfDeletableEntityRepository<City> repository;
        private ICitiesService citiesService;

        public CitiesServiceTests()
        {
            this.InitializeMapper();
            this.dbContext = GetElectricTravelDbContext();
            this.repository = new EfDeletableEntityRepository<City>(this.dbContext);
            this.citiesService = new CitiesService(this.repository);
        }

        [Fact]
        public async Task GetAllCitiesShouldReturnCorrectCount()
        {
            SeedInDb(this.dbContext);

            var cities = await this.citiesService.GetAllCities<CityViewModel>();
            var citiesCount = cities.Count();
            Assert.Equal(1, citiesCount);
        }

        [Fact]
        public async Task CheckInCreateAsyncIfCityWithSameNameIsAlreadyInDbAndIsNotDeleted()
        {
            SeedInDb(this.dbContext);
            var model = GetExistingInDbInputModel();

            await this.citiesService.CreateAsync(model);
            var doesExist = this.repository.AllWithDeleted().Any(x => x.Name == model.Name && x.IsDeleted == false);

            Assert.True(doesExist);
        }

        [Fact]
        public async Task CheckInCreateAsyncIfCreatesCityDbModel()
        {
            SeedInDb(this.dbContext);
            var model = GetInputViewModel();

            var isCreated = await this.citiesService.CreateAsync(model);

            Assert.True(isCreated);
        }

        [Fact]
        public async Task CheckIfGetCityByIdAsyncReturnsCorrectData()
        {
            SeedInDb(this.dbContext);
            var id = 2;

            var model = await this.citiesService.GetCityByIdAsync<CityViewModel>(id);
            var modelId = model.Id;

            Assert.Equal(id, modelId);
        }

        [Fact]
        public async Task CheckIfInDeleteCityAsyncCityWithIdExist()
        {
            SeedInDb(this.dbContext);
            var id = 2;

            var model = await this.repository.All()
                 .FirstOrDefaultAsync(x => x.Id == id);

            Assert.NotNull(model);
        }

        [Fact]
        public async Task CheckIfDeleteCityAsyncDeletesModel()
        {
            SeedInDb(this.dbContext);
            var id = 1;

            await this.citiesService.DeleteAsync(id);
            var model = await this.repository.All()
                 .FirstOrDefaultAsync(x => x.Id == id);

            Assert.Null(model);
        }

        private static CreateCityInputViewModel GetExistingInDbInputModel()
        {
            var cityName = "Plovdiv";
            var regionId = 1;
            var model = new CreateCityInputViewModel { Name = cityName, RegionId = regionId };
            return model;
        }

        private static CreateCityInputViewModel GetInputViewModel()
        {
            var cityName = "Sofia";
            var regionId = 1;
            return new CreateCityInputViewModel { Name = cityName, RegionId = regionId };
        }

        private static ElectricTravelDbContext GetElectricTravelDbContext()
        {
            var options = new DbContextOptionsBuilder<ElectricTravelDbContext>()
                              .UseInMemoryDatabase(databaseName: "CitiesTestDb").Options;
            var dbContext = new ElectricTravelDbContext(options);

            return dbContext;
        }

        private static void SeedInDb(ElectricTravelDbContext dbContext)
        {
            dbContext.Regions.Add(new Region
            {
                Name = "Plovdiv Region",
            });

            dbContext.SaveChanges();

            var region = dbContext.Regions.FirstOrDefault(x => x.Name == "Plovdiv Region");

            dbContext.Cities.Add(new City
            {
                Name = "Plovdiv",
                Region = region,
            });

            dbContext.SaveChanges();
        }

        private void InitializeMapper() => AutoMapperConfig.
            RegisterMappings(Assembly.Load("ElectricTravel.Web.ViewModels"));
    }

    ///var options = new DbContextOptionsBuilder<ElectricTravelDbContext>()
    ////    .UseInMemoryDatabase(databaseName: "SettingsTestDb").Options;
    ////using var dbContext = new ElectricTravelDbContext(options);
    ////    dbContext.Settings.Add(new Setting());
    ////        dbContext.Settings.Add(new Setting());
    ////        dbContext.Settings.Add(new Setting());
    ////        await dbContext.SaveChangesAsync();

    ////        using var repository = new EfDeletableEntityRepository<Setting>(dbContext);
    ////        var service = new SettingsService(repository);
    ////Assert.Equal(3, service.GetCount());

}
