namespace ElectricTravel.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    using ElectricTravel.Data.Common.Repositories;
    using ElectricTravel.Data.Models.Car;
    using ElectricTravel.Data.Models.Multimedia;
    using ElectricTravel.Services.Data.Contracts;
    using ElectricTravel.Services.Mapping;
    using ElectricTravel.Web.InputViewModels.ElectricCars;
    using ElectricTravel.Web.ViewModels.Cars;
    using Microsoft.AspNetCore.Http;
    using Microsoft.EntityFrameworkCore;
    using SixLabors.ImageSharp;
    using SixLabors.ImageSharp.Processing;

    public class CarsService : ICarsService
    {
        private readonly IDeletableEntityRepository<ElectricCar> carRepository;
        private readonly IDeletableEntityRepository<Model> carModelRepository;
        private readonly IDeletableEntityRepository<Make> carMakesRepository;
        private readonly IDeletableEntityRepository<CarType> carTypesRepository;
        private readonly IDeletableEntityRepository<ImageType> imageTypeRepository;
        private string[] allowedExtensions = new[] { "jpg", "png", "gif", "jpeg" };

        public CarsService(
            IDeletableEntityRepository<ElectricCar> carRepository,
            IDeletableEntityRepository<Model> carModelRepository,
            IDeletableEntityRepository<Make> carMakesRepository,
            IDeletableEntityRepository<CarType> carTypesRepository,
            IDeletableEntityRepository<ImageType> imageTypeRepository)
        {
            this.carRepository = carRepository;
            this.carModelRepository = carModelRepository;
            this.carMakesRepository = carMakesRepository;
            this.carTypesRepository = carTypesRepository;
            this.imageTypeRepository = imageTypeRepository;
        }

        public IEnumerable<VehicleMakeViewModel> GetMakes()
        {
            return this.carMakesRepository.AllAsNoTracking().To<VehicleMakeViewModel>().ToList();
        }

        public List<VehicleModelViewModel> GetModelsByMakeId(int makeId)
        {
            var models = this.carModelRepository.AllAsNoTracking()
                .Where(x => x.MakeId == makeId).To<VehicleModelViewModel>().ToList();
            return models;
        }

        public IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePairsById(int id)
        {
            return this.carMakesRepository.AllAsNoTracking()
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
            var carMakes = this.carMakesRepository.AllAsNoTracking()
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
            var carTypes = this.carTypesRepository.AllAsNoTracking()
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
            };

            await this.carRepository.AddAsync(car);
            await this.carRepository.SaveChangesAsync();
            return car.Id;
        }

        public async Task<bool> DeleteCarAsync(int? carId)
        {
            var car = this.carRepository.All()
                .FirstOrDefault(x => x.Id == carId);

            this.carRepository.Delete(car);
            var deletedCount = await this.carRepository.SaveChangesAsync();

            if (deletedCount == 0)
            {
                return false;
            }

            return true;
        }

        ////public async Task UploadVideosAndImages(
        ////    int carId, IEnumerable<IFormFile> videos, string videoDescription, IEnumerable<IFormFile> images, string imageType, string path)
        ////{
        ////    Directory.CreateDirectory($"{path}/carImages/");

        ////    var typeImage = this.imageTypeRepository
        ////        .AllAsNoTracking()
        ////        .FirstOrDefault(x => x.Name == imageType);

        ////    var car = this.carRepository.All().FirstOrDefault(x => x.Id == carId);

        ////    await this.UploadFile(car, path, images, imageType);
        ////    await this.UploadFile(car, path, videos, videoDescription);
        ////}

        public Task<T> EditAsync<T>(int? id)
        {
            throw new NotImplementedException();
        }

        public async Task<T> GetCarById<T>(int? id)
        {
            var car = await this.carRepository.AllAsNoTracking()
                .Where(x => x.Id == id)
                .To<T>()
                .FirstOrDefaultAsync();

            return car;
        }

        ////private async Task UploadFile(ElectricCar car, string path, IEnumerable<IFormFile> files, string imageType)
        ////{
        ////    foreach (var file in files)
        ////    {
        ////        var extension = Path.GetExtension(file.FileName).TrimStart('.');

        ////        var itemName = Guid.NewGuid().ToString();

        ////        var typeImage = this.imageTypeRepository
        ////        .AllAsNoTracking()
        ////        .FirstOrDefault(x => x.Name == imageType);

        ////        var physicalPath = string.Empty;

        ////        if (!this.allowedExtensions.Any(x => extension.EndsWith(x)))
        ////        {
        ////            throw new Exception($"Invalid image extension {extension}");
        ////        }

        ////        physicalPath = $"{path}/carImages/{itemName}.{extension}";
        ////        var dbImage = new ElectricTravel.Data.Models.Multimedia.Image
        ////        {
        ////            ElectricCarId = car.Id,
        ////            Extension = extension,
        ////            Name = itemName,
        ////            Path = $"../../car/carImages/{itemName}.{extension}",
        ////            Type = typeImage,
        ////        };

        ////        car.Images.Add(dbImage);

        ////        using var image = SixLabors.ImageSharp.Image.Load(file.OpenReadStream());
        ////        ////TODO image resize algorithm
        ////        image.Mutate(x => x.Resize(795, 300));
        ////        image.Save(physicalPath);
        ////    }

        ////    this.carRepository.Update(car);
        ////    await this.carRepository.SaveChangesAsync();
        ////}
    }
}
