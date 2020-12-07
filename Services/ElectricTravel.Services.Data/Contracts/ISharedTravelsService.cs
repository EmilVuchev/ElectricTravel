namespace ElectricTravel.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using ElectricTravel.Web.InputViewModels.SharedTravel;
    using ElectricTravel.Web.ViewModels.SharedTravels;

    public interface ISharedTravelsService
    {
        Task<string> CreateAsync(SharedTravelCreateInputViewModel input, string userId);

        Task<IEnumerable<T>> GetAllAsync<T>(int page, int itemsPerPage = 10);

        Task<IEnumerable<SharedTravelsViewModel>> GetRecentlyAddedAsync(int count = 0);

        Task<IEnumerable<T>> GetAllByAuthorId<T>(string userId, int page, int itemsPerPage);

        Task<T> GetViewModelByIdAsync<T>(string id);

        Task<int> GetAdvertsCountByUser(string userId);

        Task<int> GetAllAdvertsCount();

        Task<IEnumerable<T>> GetByDestinationAsync<T>(string search, int page, int itemsPerPage);

        Task<int> GetSearchedAdvertsCount(string search);

        Task<int> GetSearchedUserAdvertsCount(string search, string userId);

        Task<IEnumerable<T>> GetUserAdvertByDestination<T>(string search, string userId, int page, int itemsPerPage);
    }
}
