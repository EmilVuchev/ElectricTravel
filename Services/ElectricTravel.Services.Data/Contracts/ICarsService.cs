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

        Task<T> EditAsync<T>(int? id);

        Task<T> GetCarById<T>(int? id);

        IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePairsById(int id);

        IEnumerable<VehicleMakeViewModel> GetMakes();

        List<VehicleModelViewModel> GetModelsByMakeId(int makeId);
        ////Task UploadVideosAndImages(int carId, IEnumerable<IFormFile> videos, string videoDescription, IEnumerable<IFormFile> images, string imageType, string path);
    }
}
