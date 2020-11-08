namespace ElectricTravel.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ISharedTravelsService : IBaseDataService
    {
        Task<IEnumerable<T>> GetAllAsync<T>();

        Task<IEnumerable<T>> GetRecentlyAddedAsync<T>(int count = 0);
    }
}
