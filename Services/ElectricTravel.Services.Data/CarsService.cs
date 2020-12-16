namespace ElectricTravel.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using ElectricTravel.Data.Common.Repositories;
    using ElectricTravel.Data.Models.Car;
    using ElectricTravel.Data.Models.Multimedia;
    using ElectricTravel.Services.Data.Contracts;
    using ElectricTravel.Services.Mapping;
    using ElectricTravel.Web.InputViewModels.ElectricCars;
    using ElectricTravel.Web.ViewModels.Cars;
    using Microsoft.EntityFrameworkCore;

    public class CarsService : ICarsService
    {
        private readonly IDeletableEntityRepository<ElectricCar> carRepository;
        private readonly IDeletableEntityRepository<Model> carModelRepository;
        private readonly IDeletableEntityRepository<Make> carMakeRepository;
        private readonly IDeletableEntityRepository<CarType> carTypeRepository;
        private readonly IDeletableEntityRepository<Image> imageRepository;
        private string[] allowedExtensions = new[] { "jpg", "png", "gif", "jpeg" };

        public CarsService(
            IDeletableEntityRepository<ElectricCar> carRepository,
            IDeletableEntityRepository<Model> carModelRepository,
            IDeletableEntityRepository<Make> carMakeRepository,
            IDeletableEntityRepository<CarType> carTypeRepository,
            IDeletableEntityRepository<Image> imageRepository)
        {
            this.carRepository = carRepository;
            this.carModelRepository = carModelRepository;
            this.carMakeRepository = carMakeRepository;
            this.carTypeRepository = carTypeRepository;
            this.imageRepository = imageRepository;
        }

        public IEnumerable<VehicleMakeViewModel> GetMakes()
        {
            return this.carMakeRepository.AllAsNoTracking().To<VehicleMakeViewModel>().ToList();
        }

        public List<VehicleModelViewModel> GetModelsByMakeId(int makeId)
        {
            var models = this.carModelRepository.AllAsNoTracking()
                .Where(x => x.MakeId == makeId).To<VehicleModelViewModel>().ToList();
            return models;
        }

        public IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePairsById(int id)
        {
            return this.carMakeRepository.AllAsNoTracking()
                .Where(x => x.CarTypes.Any(y => y.CarTypeId == id))
                .Select(x => new
                {
                    x.Id,
                    x.Name,
                })
                .OrderBy(x => x.Name)
                .ToList().Select(x => new KeyValuePair<string, string>(x.Id.ToString(), x.Name));
        }

        public async Task<IEnumerable<T>> GetCarsByUserId<T>(string userId)
        {
            var cars = await this.carRepository.AllAsNoTracking()
               .Where(x => x.UserId == userId)
               .To<T>()
               .ToListAsync();

            return cars;
        }

        public IEnumerable<KeyValuePair<string, string>> GetAllCarMakesAsKeyValuePairs()
        {
            var carMakes = this.carMakeRepository.AllAsNoTracking()
                .Select(x => new
                {
                    x.Id,
                    x.Name,
                })
                .OrderBy(x => x.Name)
                .ToList().Select(x => new KeyValuePair<string, string>(x.Id.ToString(), x.Name));

            return carMakes;
        }

        public IEnumerable<KeyValuePair<string, string>> GetAllCarModelsAsKeyValuePairs()
        {
            var carMode = this.carModelRepository.AllAsNoTracking()
                .Select(x => new
                {
                    x.Id,
                    x.Name,
                }).ToList();

            var carModels = this.carModelRepository.AllAsNoTracking()
                .Select(x => new
                {
                    x.Id,
                    x.Name,
                })
                .OrderBy(x => x.Name)
                .ToList().Select(x => new KeyValuePair<string, string>(x.Id.ToString(), x.Name));

            return carModels;
        }

        public IEnumerable<KeyValuePair<string, string>> GetAllCarTypesAsKeyValuePairs()
        {
            var carTypes = this.carTypeRepository.AllAsNoTracking()
                .Select(x => new
                {
                    x.Id,
                    x.Name,
                })
                .OrderBy(x => x.Name)
                .ToList().Select(x => new KeyValuePair<string, string>(x.Id.ToString(), x.Name));

            return carTypes;
        }

        public async Task<int> CreateCarAsync(ElectricCarInputViewModel input, string userId)
        {
            var car = new ElectricCar
            {
                Acceleration = input.Acceleration,
                Battery = input.Battery,
                Color = input.Color,
                Doors = input.Doors,
                Drive = input.Drive,
                ElectricityConsumption = input.ElectricityConsumption,
                HorsePower = input.HorsePower,
                Kilometres = input.Kilometres,
                LuggageCapacity = input.LuggageCapacity,
                MakeId = input.CarMakeId,
                ModelId = input.CarModelId,
                Range = input.Range,
                Seats = input.Seats,
                TopSpeed = input.TopSpeed,
                UserId = userId,
                Year = input.Year,
                CarTypeId = input.CarTypeId,
                Description = input.Description,
            };

            await this.carRepository.AddAsync(car);
            await this.carRepository.SaveChangesAsync();
            return car.Id;
        }

        public async Task<bool> DeleteCarAsync(int? carId)
        {
            var car = this.carRepository.All()
                .FirstOrDefault(x => x.Id == carId);

            var images = await this.imageRepository.All()
                .Where(x => x.ElectricCarId == carId)
                .ToListAsync();

            if (images != null)
            {
                foreach (var image in images)
                {
                    this.imageRepository.Delete(image);
                    await this.imageRepository.SaveChangesAsync();
                }
            }

            this.carRepository.Delete(car);
            var deletedCount = await this.carRepository.SaveChangesAsync();

            if (deletedCount == 0)
            {
                return false;
            }

            return true;
        }

        public async Task<ElectricCarEditInputViewModel> GetCarByIdForEdit(int? id)
        {
            var car = await this.carRepository.AllAsNoTracking()
                   .Where(x => x.Id == id)
                   .Select(x => new ElectricCarEditInputViewModel
                   {
                       Id = x.Id,
                       Seats = x.Seats,
                       TopSpeed = x.TopSpeed,
                       Acceleration = x.Acceleration,
                       Battery = x.Battery,
                       Color = x.Color,
                       Description = x.Description,
                       Doors = x.Doors,
                       Drive = x.Drive,
                       ElectricityConsumption = x.ElectricityConsumption,
                       HorsePower = x.HorsePower,
                       Kilometres = x.Kilometres,
                       LuggageCapacity = x.LuggageCapacity,
                       Range = x.Range,
                       Year = x.Year,
                       //MakeName = x.Make.Name,
                       //ModelName = x.Model.Name,
                   })
                   .FirstOrDefaultAsync();

            return car;
        }

        public async Task<T> GetCarById<T>(int? id)
        {
            var car = await this.carRepository.AllAsNoTracking()
                .Where(x => x.Id == id)
                .To<T>()
                .FirstOrDefaultAsync();

            return car;
        }

        public async Task UpdateAsync(int id, ElectricCarEditInputViewModel input, string userId)
        {
            var car = await this.carRepository.All()
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();

            car.Acceleration = input.Acceleration;
            car.Battery = input.Battery;
            car.CarTypeId = input.CarTypeId;
            car.Color = input.Color;
            car.Description = input.Description;
            car.Doors = input.Doors;
            car.Drive = input.Drive;
            car.ElectricityConsumption = input.ElectricityConsumption;
            car.HorsePower = input.HorsePower;
            car.Kilometres = input.Kilometres;
            car.LuggageCapacity = input.LuggageCapacity;
            car.MakeId = input.CarMakeId;
            car.ModelId = input.CarModelId;
            car.Range = input.Range;
            car.Seats = input.Seats;
            car.TopSpeed = input.TopSpeed;
            car.UserId = userId;
            car.Year = input.Year;
            car.CarTypeId = input.CarTypeId;

            this.carRepository.Update(car);
            await this.carRepository.SaveChangesAsync();
        }
    }
}
