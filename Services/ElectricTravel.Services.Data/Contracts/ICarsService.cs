namespace ElectricTravel.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using ElectricTravel.Web.InputViewModels.ElectricCars;
    using ElectricTravel.Web.ViewModels.Cars;

    public interface ICarsService
    {
        Task<IEnumerable<T>> GetCarsByUserId<T>(string userId);

        public IEnumerable<KeyValuePair<string, string>> GetAllCarModelsAsKeyValuePairs();

        public IEnumerable<KeyValuePair<string, string>> GetAllCarMakesAsKeyValuePairs();

        IEnumerable<KeyValuePair<string, string>> GetAllCarTypesAsKeyValuePairs();

        Task<int> CreateCarAsync(ElectricCarInputViewModel input, string userId);

        Task<bool> DeleteCarAsync(int? carId);

        Task<T> GetCarById<T>(int? id);

        Task<ElectricCarEditInputViewModel> GetCarByIdForEdit(int? id);

        IEnumerable<VehicleMakeViewModel> GetMakes();

        List<VehicleModelViewModel> GetModelsByMakeId(int makeId);

        Task UpdateAsync(int id, ElectricCarEditInputViewModel input, string userId);
    }
}
