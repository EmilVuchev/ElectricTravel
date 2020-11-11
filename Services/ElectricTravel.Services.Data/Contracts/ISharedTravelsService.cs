namespace ElectricTravel.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using ElectricTravel.Web.InputViewModels.SharedTravel;
    using ElectricTravel.Web.ViewModels.SharedTravels;

    public interface ISharedTravelsService
    {
        Task CreateAsync(SharedTravelCreateInputViewModel sharedTravelCreateInputModel);

        Task<IEnumerable<T>> GetAllAsync<T>();

        Task<IEnumerable<SharedTravelsViewModel>> GetRecentlyAddedAsync(int count = 0);
    }
}
