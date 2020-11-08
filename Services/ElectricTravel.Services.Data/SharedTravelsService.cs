namespace ElectricTravel.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using ElectricTravel.Data.Common.Repositories;
    using ElectricTravel.Data.Models.Advertisement;
    using ElectricTravel.Services.Data.Contracts;
    using ElectricTravel.Services.Mapping;
    using Microsoft.EntityFrameworkCore;

    public class SharedTravelsService : ISharedTravelsService
    {
        private readonly IDeletableEntityRepository<SharedTravelAdvert> sharedTravelsRepository;

        public SharedTravelsService(IDeletableEntityRepository<SharedTravelAdvert> sharedTravelsRepository)
        {
            this.sharedTravelsRepository = sharedTravelsRepository;
        }

        public Task DeleteByIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<T>> GetAllAsync<T>()
        {
        // var adverts = await this.sharedTravelsRepository
        //        .Update
            return null;
        }

        public async Task<IEnumerable<T>> GetRecentlyAddedAsync<T>(int count = 0)
        {
            var recentlyAddedAdvert = await this.sharedTravelsRepository
               .All()
               .OrderByDescending(x => x.CreatedOn)
               .Take(count)
               .To<T>()
               .ToListAsync();

            return recentlyAddedAdvert;
        }

        public Task<TViewModel> GetViewModelByIdAsync<TViewModel>(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
