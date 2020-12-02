namespace ElectricTravel.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using ElectricTravel.Web.InputViewModels.ElectricCars;
    using ElectricTravel.Web.ViewModels.Cars;
    using Microsoft.AspNetCore.Http;

    public interface ICarsService
    {
        Task<IEnumerable<CarViewModel>> GetCarsByUserId(string userId);

        public IEnumerable<KeyValuePair<string, string>> GetAllCarModelsAsKeyValuePairs();

        public IEnumerable<KeyValuePair<string, string>> GetAllCarMakesAsKeyValuePairs();

        IEnumerable<KeyValuePair<string, string>> GetAllCarTypesAsKeyValuePairs();

        Task CreateCarAsync(ElectricCarInputViewModel input, string userId);

        ////Task UploadVideosAndImages(int carId, IEnumerable<IFormFile> videos, string videoDescription, IEnumerable<IFormFile> images, string imageType, string path);
    }
}
