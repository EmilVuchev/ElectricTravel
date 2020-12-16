namespace ElectricTravel.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using ElectricTravel.Data.Common.Repositories;
    using ElectricTravel.Data.Models.Charging;
    using ElectricTravel.Services.Data.Contracts;
    using ElectricTravel.Services.Mapping;
    using ElectricTravel.Web.InputViewModels.ChargingStations;
    using ElectricTravel.Web.ViewModels.ChargingStations;
    using Microsoft.EntityFrameworkCore;

    public class ChargingStationsService : IChargingStationsService
    {
        private readonly IDeletableEntityRepository<ChargingStation> chargingStationsRepository;

        public ChargingStationsService(
            IDeletableEntityRepository<ChargingStation> chargingStationsRepository)
        {
            this.chargingStationsRepository = chargingStationsRepository;
        }

        public async Task CreateAsync(ChargingStationInputViewModel chargingStation)
        {
            var chargingStationToAdd = new ChargingStation
            {
                Description = chargingStation.Description,
                IsFreeOfCharge = chargingStation.IsFreeOfCharge,
                Name = chargingStation.Name,
                WorkTime = chargingStation.WorkTime,
                Address = chargingStation.Address,
                CityId = chargingStation.CityId,
            };

            await this.chargingStationsRepository.AddAsync(chargingStationToAdd);
            await this.chargingStationsRepository.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var chargingStationToDelete = await this.chargingStationsRepository.All()
                .FirstOrDefaultAsync(x => x.Id == id);

            if (chargingStationToDelete == null)
            {
                return false;
            }

            this.chargingStationsRepository.Delete(chargingStationToDelete);
            await this.chargingStationsRepository.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<T>> GetAll<T>()
        {
            return await this.chargingStationsRepository.All()
                 .To<T>()
                 .ToListAsync();
        }

        public async Task<ChargingStationDetailsViewModel> GetById(int id)
        {
            var chargingStation = await this.chargingStationsRepository.All()
                .Where(x => x.Id == id)
                .To<ChargingStationDetailsViewModel>()
                .FirstOrDefaultAsync();

            return chargingStation;
        }
    }
}
