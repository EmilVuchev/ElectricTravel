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
        private readonly IDeletableEntityRepository<Region> regionsRepository;

        public CitiesService(
            IDeletableEntityRepository<City> citiesRepository,
            IDeletableEntityRepository<Region> regionsRepository)
        {
            this.citiesRepository = citiesRepository;
            this.regionsRepository = regionsRepository;
        }

        public async Task<IEnumerable<T>> GetAll<T>()
        {
            return await this.citiesRepository.AllAsNoTracking()
                .To<T>()
                .ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAllRegions<T>()
        {
            return await this.regionsRepository.AllAsNoTracking()
                .To<T>()
                .ToListAsync();
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
