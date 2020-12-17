namespace ElectricTravel.Services.Data.Tests
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Threading.Tasks;

    using ElectricTravel.Data;
    using ElectricTravel.Data.Common.Repositories;
    using ElectricTravel.Data.Models.Charging;
    using ElectricTravel.Data.Repositories;
    using ElectricTravel.Services.Mapping;
    using ElectricTravel.Web.InputViewModels.ChargingStations;
    using ElectricTravel.Web.ViewModels.ChargingStations;
    using Microsoft.EntityFrameworkCore;
    using Moq;
    using Xunit;

    public class ChargingStationsServiceTests
    {
        public ChargingStationsServiceTests()
        {
            this.InitializeMapper();
        }

        [Fact]
        public async Task ChecksIfCreateAsyncCreatesEntityInDb()
        {
            var list = new List<ChargingStation>();

            var mockRepo = new Mock<IDeletableEntityRepository<ChargingStation>>();
            mockRepo.Setup(x => x.All()).Returns(list.AsQueryable());
            mockRepo.Setup(x => x.AddAsync(It.IsAny<ChargingStation>())).Callback(
                (ChargingStation station) => list.Add(station));

            var service = new ChargingStationsService(mockRepo.Object);

            var stationName = "ElDrive";
            var address = "Drujba 1";
            var cityId = 1;
            var description = "Something";
            var isFree = false;
            var workingTime = "10-22";

            var stationToAdd = new ChargingStationInputViewModel
            {
                Name = stationName,
                Address = address,
                CityId = cityId,
                Description = description,
                IsFreeOfCharge = isFree,
                WorkTime = workingTime,
            };

            await service.CreateAsync(stationToAdd);

            var listCount = list.Count();
            var expectedResult = 1;

            Assert.Equal(expectedResult, listCount);
        }

        [Fact]
        public async Task CheckIfIdIdParameterForDeleteAsyncExistInTheDb()
        {
            var list = new List<ChargingStation>();

            var mockRepo = new Mock<IDeletableEntityRepository<ChargingStation>>();
            mockRepo.Setup(x => x.All()).Returns(list.AsQueryable());
            mockRepo.Setup(x => x.AddAsync(It.IsAny<ChargingStation>())).Callback(
                (ChargingStation station) => list.Add(station));

            var service = new ChargingStationsService(mockRepo.Object);

            var stationName = "ElDrive";
            var address = "Drujba 1";
            var cityId = 1;
            var description = "Something";
            var isFree = false;
            var workingTime = "10-22";

            var stationToAdd = new ChargingStationInputViewModel
            {
                Name = stationName,
                Address = address,
                CityId = cityId,
                Description = description,
                IsFreeOfCharge = isFree,
                WorkTime = workingTime,
            };

            await service.CreateAsync(stationToAdd);

            var model = new ChargingStation();

            if (list.Count == 1)
            {
                model = list.SingleOrDefault();
            }
            else
            {
                model = null;
            }

            var actualResult = model;

            Assert.NotNull(actualResult);
        }

        [Fact]
        public async Task CheckIfDbIsEmptyDeleteAsyncShouldReturnFalse()
        {
            var options = new DbContextOptionsBuilder<ElectricTravelDbContext>()
                                .UseInMemoryDatabase(databaseName: "ChargingStationsTestDb").Options;
            using var dbContext = new ElectricTravelDbContext(options);

            using var repo = new EfDeletableEntityRepository<ChargingStation>(dbContext);
            var service = new ChargingStationsService(repo);

            var isTrue = await service.DeleteAsync(2);

            Assert.True(!isTrue);
        }

        [Fact]
        public async Task CheckThatDeleteAsyncShouldReturnTrueIfStationIsDeleted()
        {
            var options = new DbContextOptionsBuilder<ElectricTravelDbContext>()
                              .UseInMemoryDatabase(databaseName: "ChargingStationsTestDb").Options;
            using var dbContext = new ElectricTravelDbContext(options);

            using var repo = new EfDeletableEntityRepository<ChargingStation>(dbContext);
            var service = new ChargingStationsService(repo);

            var stationName = "ElDrive";
            var address = "Drujba 1";
            var cityId = 1;
            var description = "Something";
            var isFree = false;
            var workingTime = "10-22";

            var stationToAdd = new ChargingStation
            {
                Name = stationName,
                Address = address,
                CityId = cityId,
                Description = description,
                IsFreeOfCharge = isFree,
                WorkTime = workingTime,
            };

            await repo.AddAsync(stationToAdd);
            await repo.SaveChangesAsync();
            var stations = repo.All().ToList();

            var id = 0;

            if (stations.Count == 1)
            {
                var station = stations.SingleOrDefault();
                id = station.Id;
            }

            var isTrue = await service.DeleteAsync(id);

            Assert.True(isTrue);
        }

        [Fact]
        public async Task CheckIfGetAllReturns()
        {
            var options = new DbContextOptionsBuilder<ElectricTravelDbContext>()
                                  .UseInMemoryDatabase(databaseName: "ChargingStationsTestDb").Options;
            using var dbContext = new ElectricTravelDbContext(options);

            using var repo = new EfDeletableEntityRepository<ChargingStation>(dbContext);
            var service = new ChargingStationsService(repo);

            var stationName = "ElDrive";
            var address = "Drujba 1";
            var cityId = 1;
            var description = "Something";
            var isFree = false;
            var workingTime = "10-22";

            var stationToAdd = new ChargingStation
            {
                Name = stationName,
                Address = address,
                CityId = cityId,
                Description = description,
                IsFreeOfCharge = isFree,
                WorkTime = workingTime,
            };

            await repo.AddAsync(stationToAdd);
            await repo.SaveChangesAsync();

            var stations = await service.GetAll<ChargingStationViewModel>();

            var count = stations.Count();

            Assert.True(count > 0);
        }

        [Fact]
        public async Task CheckIfGetByIdReturnsViewModel()
        {
            var options = new DbContextOptionsBuilder<ElectricTravelDbContext>()
                                      .UseInMemoryDatabase(databaseName: "ChargingStationsTestDb").Options;
            using var dbContext = new ElectricTravelDbContext(options);

            using var repo = new EfDeletableEntityRepository<ChargingStation>(dbContext);
            var service = new ChargingStationsService(repo);

            var stationName = "ElDrive";
            var address = "Drujba 1";
            var cityId = 1;
            var description = "Something";
            var isFree = false;
            var workingTime = "10-22";

            var stationToAdd = new ChargingStation
            {
                Name = stationName,
                Address = address,
                CityId = cityId,
                Description = description,
                IsFreeOfCharge = isFree,
                WorkTime = workingTime,
            };

            await repo.AddAsync(stationToAdd);
            await repo.SaveChangesAsync();
            var station = repo.All().FirstOrDefault(x => x.Id == stationToAdd.Id);

            Assert.NotNull(station);
        }

        private void InitializeMapper() => AutoMapperConfig.
           RegisterMappings(Assembly.Load("ElectricTravel.Web.ViewModels"));
    }
}
