namespace ElectricTravel.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using ElectricTravel.Data.Common.Repositories;
    using ElectricTravel.Data.Models.Advertisement;
    using ElectricTravel.Services.Data.Contracts;

    public class TypeOfTravelService : ITypeOfTravelService
    {
        private readonly IDeletableEntityRepository<TypeTravel> typeTravelRepository;

        public TypeOfTravelService(IDeletableEntityRepository<TypeTravel> typeTravelRepository)
        {
            this.typeTravelRepository = typeTravelRepository;
        }

        public IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePairs()
        {
            return this.typeTravelRepository.AllAsNoTracking()
                .Select(x => new
                {
                    x.Id,
                    x.Name,
                }).ToList().Select(x => new KeyValuePair<string, string>(x.Id.ToString(), x.Name));
        }
    }
}
