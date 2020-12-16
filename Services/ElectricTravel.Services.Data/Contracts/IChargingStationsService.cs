namespace ElectricTravel.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using ElectricTravel.Web.InputViewModels.ChargingStations;
    using ElectricTravel.Web.ViewModels.ChargingStations;

    public interface IChargingStationsService
    {
        public Task<IEnumerable<T>> GetAll<T>();

        Task<ChargingStationDetailsViewModel> GetById(int id);

        Task CreateAsync(ChargingStationInputViewModel chargingStation);

        Task<bool> DeleteAsync(int id);
    }
}
