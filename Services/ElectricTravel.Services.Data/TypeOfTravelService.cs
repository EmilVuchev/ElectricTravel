namespace ElectricTravel.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using ElectricTravel.Data.Common.Repositories;
    using ElectricTravel.Data.Models.Advertisement;
    using ElectricTravel.Services.Data.Contracts;
    using ElectricTravel.Services.Mapping;
    using Microsoft.EntityFrameworkCore;

    public class TypeOfTravelService : ITypeOfTravelService
    {
        private readonly IDeletableEntityRepository<TypeTravel> typeTravelRepository;

        public TypeOfTravelService(IDeletableEntityRepository<TypeTravel> typeTravelRepository)
        {
            this.typeTravelRepository = typeTravelRepository;
        }

        public async Task<IEnumerable<T>> GetAll<T>()
        {
            return await this.typeTravelRepository.AllAsNoTracking()
                .To<T>()
                .ToListAsync();
        }
    }
}
