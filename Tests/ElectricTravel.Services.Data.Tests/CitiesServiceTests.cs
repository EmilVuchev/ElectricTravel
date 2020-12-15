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
    using ElectricTravel.Web.ViewModels.Regions;
    using Microsoft.EntityFrameworkCore;
    using Xunit;

    public class CitiesServiceTests
    {
        private ElectricTravelDbContext dbContext;
        private EfDeletableEntityRepository<City> citiesRepository;
        private EfDeletableEntityRepository<Region> regionsRepository;
        private ICitiesService citiesService;

        public CitiesServiceTests()
        {
            this.InitializeMapper();
            this.dbContext = GetElectricTravelDbContext();
            this.citiesRepository = new EfDeletableEntityRepository<City>(this.dbContext);
            this.regionsRepository = new EfDeletableEntityRepository<Region>(this.dbContext);
            this.citiesService = new CitiesService(this.citiesRepository, this.regionsRepository);
        }

        [Fact]
        public async Task GetAllCitiesShouldReturnCorrectCount()
        {
            await SeedInDb(this.dbContext);

            var cities = await this.citiesService.GetAll<CityViewModel>();
            var citiesCount = cities.Count();

            Assert.Equal(1, citiesCount);
        }

        [Fact]
        public async Task CheckInCreateAsyncIfCityWithSameNameIsAlreadyInDbAndIsNotDeleted()
        {
            await SeedInDb(this.dbContext);
            var modelName = "Plovdiv";

            var doesExist = this.citiesRepository.AllWithDeleted().Any(x => x.Name == modelName && x.IsDeleted == false);

            Assert.True(doesExist);
        }

        [Fact]
        public async Task CheckInCreateAsyncIfCreatesCityDbModel()
        {
            var model = GetInputViewModel();

            var isCreated = await this.citiesService.CreateAsync(model);

            Assert.True(isCreated);
        }

        [Fact]
        public async Task CheckIfGetCityByIdAsyncReturnsCorrectData()
        {
            await SeedInDb(this.dbContext);
            var id = 2;

            var model = await this.citiesService.GetCityByIdAsync<CityViewModel>(id);
            var modelId = model.Id;

            Assert.Equal(id, modelId);
        }

        [Fact]
        public async Task CheckIfInDeleteCityAsyncCityWithIdExist()
        {
            await SeedInDb(this.dbContext);
            var id = 2;

            var model = await this.citiesRepository.All()
                 .FirstOrDefaultAsync(x => x.Id == id);

            Assert.NotNull(model);
        }

        [Fact]
        public async Task CheckIfDeleteCityAsyncDeletesModel()
        {
            await SeedInDb(this.dbContext);
            var id = 1;

            await this.citiesService.DeleteAsync(id);
            var model = await this.citiesRepository.All()
                 .FirstOrDefaultAsync(x => x.Id == id);

            Assert.Null(model);
        }

        [Fact]
        public async Task CheckIfGetAllRegionsAsyncReturnsCorrectCount()
        {
            if (this.dbContext.Regions.Count() == 0)
            {
                await SeedInDb(this.dbContext);
            }

            var regions = await this.regionsRepository.AllAsNoTracking()
                    .To<RegionViewModel>()
                    .ToListAsync();

            var count = regions.Count;
            var expectedResult = 1;
            Assert.Equal(expectedResult, count);
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

        private static async Task SeedInDb(ElectricTravelDbContext dbContext)
        {
            dbContext.Regions.Add(new Region
            {
                Name = "Plovdiv Region",
            });

            await dbContext.SaveChangesAsync();

            var region = await dbContext.Regions.FirstOrDefaultAsync(x => x.Name == "Plovdiv Region");

            dbContext.Cities.Add(new City
            {
                Name = "Plovdiv",
                Region = region,
            });

            await dbContext.SaveChangesAsync();
        }

        private async Task DisposeDb()
        {
            await this.dbContext.DisposeAsync();
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
