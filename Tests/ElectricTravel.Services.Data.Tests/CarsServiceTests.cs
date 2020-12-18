namespace ElectricTravel.Services.Data.Tests
{
    using System.Linq;
    using System.Reflection;
    using System.Threading.Tasks;

    using ElectricTravel.Data;
    using ElectricTravel.Data.Models.Car;
    using ElectricTravel.Data.Models.Multimedia;
    using ElectricTravel.Data.Repositories;
    using ElectricTravel.Services.Data.Contracts;
    using ElectricTravel.Services.Mapping;
    using ElectricTravel.Web.InputViewModels.ElectricCars;
    using ElectricTravel.Web.ViewModels.Cars;
    using Microsoft.EntityFrameworkCore;
    using Xunit;

    public class CarsServiceTests
    {
        private readonly ElectricTravelDbContext dbContext;
        private readonly EfDeletableEntityRepository<ElectricCar> carsRepo;
        private readonly EfDeletableEntityRepository<Model> modelsRepo;
        private readonly EfDeletableEntityRepository<Make> makesRepo;
        private readonly EfDeletableEntityRepository<CarType> carTypesRepo;
        private readonly EfDeletableEntityRepository<Image> imagesRepo;
        private readonly ICarsService carsService;

        public CarsServiceTests()
        {
            this.InitializeMapper();
            this.dbContext = InitializeDbContext();

            InitializeRepositories(
                this.dbContext,
                out this.carsRepo,
                out this.makesRepo,
                out this.modelsRepo,
                out this.carTypesRepo,
                out this.imagesRepo);

            this.carsService = InitializeService(
                this.carsRepo, this.makesRepo, this.modelsRepo, this.carTypesRepo, this.imagesRepo);
        }

        [Fact]
        public async Task GetMakesShouldReturnCorrectResult()
        {
            var make = new Make
            {
                Name = "Tesla",
            };

            await this.makesRepo.AddAsync(make);
            await this.makesRepo.SaveChangesAsync();

            var makes = this.carsService.GetMakes();

            Assert.NotNull(makes);
        }

        [Fact]
        public async Task GetModelsByMakeId()
        {
            var make = new Make
            {
                Name = "Tesla",
            };

            await this.makesRepo.AddAsync(make);
            await this.makesRepo.SaveChangesAsync();

            var makeId = make.Id;

            var model = new Model
            {
                MakeId = makeId,
                Name = "Model 3",
                Year = 2018,
            };

            await this.modelsRepo.AddAsync(model);
            await this.modelsRepo.SaveChangesAsync();

            var models = this.carsService.GetModelsByMakeId(makeId);

            var actualResult = models.Count;
            var expectedResult = 1;

            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public async Task GetCarsByUserIdShouldReturnCorrectResult()
        {
            var userId = "asdasdqwe";

            var car = new ElectricCar
            {
                UserId = userId,
            };

            await this.carsRepo.AddAsync(car);
            await this.carsRepo.SaveChangesAsync();

            var cars = await this.carsService.GetCarsByUserId<AllCarsViewModel>(userId);

            Assert.NotNull(cars);
        }

        [Fact]
        public async Task CreateCarAsyncShouldReturnValidCarId()
        {
            var userId = "asdasdqwe";

            var car = new ElectricCarInputViewModel
            {
                Acceleration = "2.1",
                Seats = 4,
                TopSpeed = 260,
                Battery = "100 kWh",
                CarMakeId = 1,
                CarModelId = 1,
                CarTypeId = 1,
                Doors = 4,
                Drive = "AWD",
                ElectricityConsumption = "10/100",
                HorsePower = 200,
                Kilometres = 20,
                LuggageCapacity = 120,
                Range = 500,
                Year = 2017,
            };

            var id = await this.carsService.CreateCarAsync(car, userId);

            Assert.True(id > 0);
        }

        [Fact]
        public async Task GetCarByIdForEditShouldReturnCar()
        {
            var car = new ElectricCar
            {
                Acceleration = "2.1",
                Seats = 4,
                TopSpeed = 260,
                Battery = "100 kWh",
                MakeId = 1,
                ModelId = 1,
                CarTypeId = 1,
                Doors = 4,
                Drive = "AWD",
                ElectricityConsumption = "10/100",
                HorsePower = 200,
                Kilometres = 20,
                LuggageCapacity = 120,
                Range = 500,
                Year = 2017,
            };

            await this.carsRepo.AddAsync(car);
            await this.carsRepo.SaveChangesAsync();

            var carFromDb = await this.carsService.GetCarByIdForEdit(car.Id);

            Assert.NotNull(carFromDb);
        }

        [Fact]
        public async Task GetCarByIdShouldReturnCar()
        {
            var car = new ElectricCar
            {
                Acceleration = "2.1",
                Seats = 4,
                TopSpeed = 260,
                Battery = "100 kWh",
                MakeId = 1,
                ModelId = 1,
                CarTypeId = 1,
                Doors = 4,
                Drive = "AWD",
                ElectricityConsumption = "10/100",
                HorsePower = 200,
                Kilometres = 20,
                LuggageCapacity = 120,
                Range = 500,
                Year = 2017,
            };

            await this.carsRepo.AddAsync(car);
            await this.carsRepo.SaveChangesAsync();

            var carFromDb = await this.carsService.GetCarById<CarViewModel>(car.Id);

            Assert.NotNull(carFromDb);
        }

        [Fact]
        public async Task DeleteCarAsyncShouldReturnSomeResult()
        {
            var car = new ElectricCar
            {
                Acceleration = "2.1",
                Seats = 4,
                TopSpeed = 260,
                Battery = "100 kWh",
                MakeId = 1,
                ModelId = 1,
                CarTypeId = 1,
                Doors = 4,
                Drive = "AWD",
                ElectricityConsumption = "10/100",
                HorsePower = 200,
                Kilometres = 20,
                LuggageCapacity = 120,
                Range = 500,
                Year = 2017,
            };

            await this.carsRepo.AddAsync(car);
            await this.carsRepo.SaveChangesAsync();

            var carFromDb = this.carsRepo.All()
               .FirstOrDefault(x => x.Id == car.Id);

            Assert.NotNull(carFromDb);
        }

        [Fact]
        public async Task DeleteAsyncShouldFindCarImages()
        {
            var carId = 1;

            var imageToAdd = new Image
            {
                ElectricCarId = carId,
                Extension = "jpeg",
                Name = "MyPic",
                TypeId = 1,
                UserId = "asdqwe",
                Path = "../images",
            };

            await this.imagesRepo.AddAsync(imageToAdd);
            await this.imagesRepo.SaveChangesAsync();

            var images = await this.imagesRepo.All()
                .Where(x => x.ElectricCarId == carId)
                .ToListAsync();

            var expectedResult = 1;
            var actualResult = images.Count;

            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public async Task DeleteAsyncShouldDeleteCarImages()
        {
            var carId = 1;

            var imageToAdd = new Image
            {
                ElectricCarId = carId,
                Extension = "jpeg",
                Name = "MyPic",
                TypeId = 1,
                UserId = "asdqwe",
                Path = "../images",
            };

            await this.imagesRepo.AddAsync(imageToAdd);
            await this.imagesRepo.SaveChangesAsync();

            this.imagesRepo.Delete(imageToAdd);
            await this.imagesRepo.SaveChangesAsync();

            var images = await this.imagesRepo.All()
                .Where(x => x.ElectricCarId == carId)
                .ToListAsync();

            var actualResult = images.Count;
            var expectedResult = 0;

            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public async Task DeleteAsyncShouldReturnFalseIfCarDoesNotExistInDb()
        {
            var carId = 1;

            var isDeleted = await this.carsService.DeleteCarAsync(carId);

            Assert.False(isDeleted);
        }

        [Fact]
        public async Task DeleteAsyncShouldReturnTrueIfCarIsDeleted()
        {
            var car = new ElectricCar
            {
                Acceleration = "2.1",
                Seats = 4,
                TopSpeed = 260,
                Battery = "100 kWh",
                MakeId = 1,
                ModelId = 1,
                CarTypeId = 1,
                Doors = 4,
                Drive = "AWD",
                ElectricityConsumption = "10/100",
                HorsePower = 200,
                Kilometres = 20,
                LuggageCapacity = 120,
                Range = 500,
                Year = 2017,
            };

            await this.carsRepo.AddAsync(car);
            await this.carsRepo.SaveChangesAsync();

            var isDeleted = await this.carsService.DeleteCarAsync(car.Id);

            Assert.True(isDeleted);
        }

        private static ElectricTravelDbContext InitializeDbContext()
        {
            var options = new DbContextOptionsBuilder<ElectricTravelDbContext>()
                                 .UseInMemoryDatabase(databaseName: "CarsTestDb").Options;
            var dbContext = new ElectricTravelDbContext(options);

            return dbContext;
        }

        private static void InitializeRepositories(
            ElectricTravelDbContext dbContext,
            out EfDeletableEntityRepository<ElectricCar> carsRepo,
            out EfDeletableEntityRepository<Make> makesRepo,
            out EfDeletableEntityRepository<Model> modelsRepo,
            out EfDeletableEntityRepository<CarType> carTypesRepo,
            out EfDeletableEntityRepository<Image> imagesRepo)
        {
            carsRepo = new EfDeletableEntityRepository<ElectricCar>(dbContext);
            makesRepo = new EfDeletableEntityRepository<Make>(dbContext);
            modelsRepo = new EfDeletableEntityRepository<Model>(dbContext);
            carTypesRepo = new EfDeletableEntityRepository<CarType>(dbContext);
            imagesRepo = new EfDeletableEntityRepository<Image>(dbContext);
        }

        private static ICarsService InitializeService(
            EfDeletableEntityRepository<ElectricCar> carsRepo,
            EfDeletableEntityRepository<Make> makesRepo,
            EfDeletableEntityRepository<Model> modelsRepo,
            EfDeletableEntityRepository<CarType> carTypesRepo,
            EfDeletableEntityRepository<Image> imageRepo)
        {
            var service = new CarsService(carsRepo, modelsRepo, makesRepo, carTypesRepo, imageRepo);
            return service;
        }

        private void InitializeMapper() => AutoMapperConfig.
           RegisterMappings(Assembly.Load("ElectricTravel.Web.ViewModels"));
    }
}
