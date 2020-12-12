namespace ElectricTravel.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using ElectricTravel.Data.Common.Repositories;
    using ElectricTravel.Data.Models.Location;
    using ElectricTravel.Services.Data.Contracts;
    using ElectricTravel.Services.Mapping;
    using ElectricTravel.Web.InputViewModels.Cities;
    using Microsoft.EntityFrameworkCore;

    public class CitiesService : ICitiesService
    {
        private readonly IDeletableEntityRepository<City> citiesRepository;

        public CitiesService(
            IDeletableEntityRepository<City> citiesRepository)
        {
            this.citiesRepository = citiesRepository;
        }

        public IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePairs()
        {
            return this.citiesRepository.AllAsNoTracking()
                .Select(x => new
                {
                    x.Id,
                    x.Name,
                })
                .OrderBy(x => x.Name)
                .ToList().Select(x => new KeyValuePair<string, string>(x.Id.ToString(), x.Name));
        }

        public IEnumerable<KeyValuePair<string, string>> GetAllRegionsAsKeyValuePairs()
        {
            return this.citiesRepository.AllAsNoTracking()
                .Select(x => new
                {
                    x.Region.Id,
                    x.Region.Name,
                })
                .OrderBy(x => x.Name)
                .ToList().Select(x => new KeyValuePair<string, string>(x.Id.ToString(), x.Name));
        }

        public async Task<IEnumerable<T>> GetAllCities<T>()
        {
            var cities = await this.citiesRepository.All()
                .To<T>()
                .ToListAsync();

            return cities;
        }

        public async Task<bool> CreateAsync(CreateCityInputViewModel input)
        {
            if (this.citiesRepository.AllWithDeleted().Any(x => x.Name == input.Name && x.IsDeleted == false))
            {
                return false;
            }

            var newCity = new City
            {
                Name = input.Name,
                RegionId = input.RegionId,
            };

            await this.citiesRepository.AddAsync(newCity);
            await this.citiesRepository.SaveChangesAsync();
            return true;
        }

        public async Task<T> GetCityByIdAsync<T>(int? id)
        {
            return await this.citiesRepository.All()
                 .Where(x => x.Id == id)
                 .To<T>()
                 .FirstOrDefaultAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var city = await this.citiesRepository.All()
                 .FirstOrDefaultAsync(x => x.Id == id);

            this.citiesRepository.Delete(city);
            await this.citiesRepository.SaveChangesAsync();
        }
    }
}
