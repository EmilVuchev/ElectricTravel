namespace ElectricTravel.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using ElectricTravel.Web.InputViewModels.SharedTravel;
    using ElectricTravel.Web.ViewModels.SharedTravels;

    public interface ISharedTravelsService
    {
        Task<string> CreateAsync(SharedTravelCreateInputViewModel input, string userId);

        Task<IEnumerable<T>> GetAllAsync<T>();

        Task<IEnumerable<SharedTravelsViewModel>> GetRecentlyAddedAsync(int count = 0);

        Task<IEnumerable<T>> GetAllByAuthorId<T>(string id);

        Task<TViewModel> GetViewModelByIdAsync<TViewModel>(string id);
    }
}
