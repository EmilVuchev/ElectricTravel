namespace ElectricTravel.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using ElectricTravel.Web.InputViewModels.Cities;

    public interface ICitiesService
    {
        Task<IEnumerable<T>> GetAllRegions<T>();

        Task<IEnumerable<T>> GetAll<T>();

        Task<bool> CreateAsync(CreateCityInputViewModel input);

        Task<T> GetCityByIdAsync<T>(int? id);

        Task DeleteAsync(int id);
    }
}
