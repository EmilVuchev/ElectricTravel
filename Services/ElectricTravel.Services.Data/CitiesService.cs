namespace ElectricTravel.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using ElectricTravel.Data.Common.Repositories;
    using ElectricTravel.Data.Models.Location;
    using ElectricTravel.Services.Data.Contracts;

    public class CitiesService : ICitiesService
    {
        private readonly IDeletableEntityRepository<City> citiesRepository;

        public CitiesService(IDeletableEntityRepository<City> citiesRepository)
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
                }).ToList().Select(x => new KeyValuePair<string, string>(x.Id.ToString(), x.Name));
        }
    }
}
