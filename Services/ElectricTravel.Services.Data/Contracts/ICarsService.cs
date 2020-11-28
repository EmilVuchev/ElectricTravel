namespace ElectricTravel.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using ElectricTravel.Web.ViewModels.Cars;

    public interface ICarsService
    {
        Task<IEnumerable<CarViewModel>> GetCarsByUserId(string userId);

        public IEnumerable<KeyValuePair<string, string>> GetAllCarModelsAsKeyValuePairs();

        public IEnumerable<KeyValuePair<string, string>> GetAllCarMakesAsKeyValuePairs();
        IEnumerable<KeyValuePair<string, string>> GetAllCarTypesAsKeyValuePairs();
    }
}
