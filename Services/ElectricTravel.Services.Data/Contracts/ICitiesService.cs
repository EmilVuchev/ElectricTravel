namespace ElectricTravel.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using ElectricTravel.Web.InputViewModels.Cities;

    public interface ICitiesService
    {
        IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePairs();

        Task<IEnumerable<T>> GetAllCities<T>();

        IEnumerable<KeyValuePair<string, string>> GetAllRegionsAsKeyValuePairs();

        Task<bool> CreateAsync(CreateCityInputViewModel input);

        Task<T> GetCityByIdAsync<T>(int? id);

        Task DeleteAsync(int id);
    }
}
