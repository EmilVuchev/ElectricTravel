namespace ElectricTravel.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using ElectricTravel.Data.Common.Repositories;
    using ElectricTravel.Data.Models.Car;
    using ElectricTravel.Data.Models.User;
    using ElectricTravel.Services.Data.Contracts;
    using ElectricTravel.Services.Mapping;
    using ElectricTravel.Web.ViewModels.Cars;
    using Microsoft.EntityFrameworkCore;

    public class CarsService : ICarsService
    {
        private readonly IDeletableEntityRepository<ElectricCar> userCarRepository;
        private readonly IDeletableEntityRepository<Model> carModelRepository;
        private readonly IDeletableEntityRepository<Make> carMakesRepository;
        private readonly IDeletableEntityRepository<CarType> carTypesRepository;

        public CarsService(
            IDeletableEntityRepository<ElectricCar> userCarRepository,
            IDeletableEntityRepository<Model> carModelRepository,
            IDeletableEntityRepository<Make> carMakesRepository,
            IDeletableEntityRepository<CarType> carTypesRepository)
        {
            this.userCarRepository = userCarRepository;
            this.carModelRepository = carModelRepository;
            this.carMakesRepository = carMakesRepository;
            this.carTypesRepository = carTypesRepository;
        }

        public async Task<IEnumerable<CarViewModel>> GetCarsByUserId(string userId)
        {
            return await this.userCarRepository
               .AllAsNoTracking()
               .Where(x => x.UserId == userId)
               .To<CarViewModel>()
               .ToListAsync();
        }

        public IEnumerable<KeyValuePair<string, string>> GetAllCarMakesAsKeyValuePairs()
        {
            return this.carMakesRepository.AllAsNoTracking()
                .Select(x => new
                {
                    x.Id,
                    x.Name,
                })
                .OrderBy(x => x.Name)
                .ToList().Select(x => new KeyValuePair<string, string>(x.Id.ToString(), x.Name));
        }

        public IEnumerable<KeyValuePair<string, string>> GetAllCarModelsAsKeyValuePairs()
        {
            return this.carModelRepository.AllAsNoTracking()
                .Select(x => new
                {
                    x.Id,
                    x.Name,
                })
                .OrderBy(x => x.Name)
                .ToList().Select(x => new KeyValuePair<string, string>(x.Id.ToString(), x.Name));
        }

        public IEnumerable<KeyValuePair<string, string>> GetAllCarTypesAsKeyValuePairs()
        {
            return this.carTypesRepository.AllAsNoTracking()
                .Select(x => new
                {
                    x.Id,
                    x.Name,
                })
                .OrderBy(x => x.Name)
                .ToList().Select(x => new KeyValuePair<string, string>(x.Id.ToString(), x.Name));
        }
    }
}
