namespace ElectricTravel.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using ElectricTravel.Data.Common.Repositories;
    using ElectricTravel.Data.Models.Advertisement;
    using ElectricTravel.Services.Data.Contracts;
    using ElectricTravel.Services.Mapping;
    using ElectricTravel.Web.InputViewModels.SharedTravel;
    using ElectricTravel.Web.ViewModels.SharedTravels;
    using Microsoft.EntityFrameworkCore;

    public class SharedTravelsService : ISharedTravelsService
    {
        private readonly IDeletableEntityRepository<SharedTravelAdvert> sharedTravelsRepository;

        public SharedTravelsService(IDeletableEntityRepository<SharedTravelAdvert> sharedTravelsRepository)
        {
            this.sharedTravelsRepository = sharedTravelsRepository;
        }

        public async Task<SharedTravelDetailsViewModel> CreateAsync(SharedTravelCreateInputViewModel input)
        {
            var sharedTravelAdvert = new SharedTravelAdvert
            {
                Seats = input.Seats,
                SmokeRestriction = input.SmokeRestriction,
                StartDateAndTime = input.StartDateAndTime,
                Status = input.Status,
                CreatedById = input.CreatedById,
                StartDestinationId = input.StartDestinationId,
                EndDestinationId = input.EndDestinationId,
                PlaceForLuggage = input.PlaceForLuggage,
                WithReturnTrip = input.WithReturnTrip,
                TypeOfTravel = input.TypeOfTravel,
            };

            var viewModel = await this.GetViewModelByIdAsync<SharedTravelDetailsViewModel>(sharedTravelAdvert.Id);

            await this.sharedTravelsRepository.AddAsync(sharedTravelAdvert);
            await this.sharedTravelsRepository.SaveChangesAsync();
            return viewModel;
        }

        public Task DeleteByIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<TViewModel>> GetAllAsync<TViewModel>()
        {
            var adverts = await this.sharedTravelsRepository
                   .All()
                   .Where(x => x.Status.ToString() == "Active")
                   .OrderBy(x => x.StartDateAndTime)
                   .To<TViewModel>()
                   .ToListAsync();

            return adverts;
        }

        public async Task<IEnumerable<SharedTravelsViewModel>> GetRecentlyAddedAsync(int count = 0)
        {
            var recentlyAddedAdvert = await this.sharedTravelsRepository
               .All()
               .OrderByDescending(x => x.CreatedOn)
               .Take(count)
               .To<SharedTravelsViewModel>()
               .ToListAsync();

            return recentlyAddedAdvert;
        }

        public async Task<TViewModel> GetViewModelByIdAsync<TViewModel>(int id)
        {
            var advert = await this.sharedTravelsRepository
                .All()
                .Where(m => m.Id == id)
                .To<TViewModel>()
                .FirstOrDefaultAsync();

            if (advert == null)
            {
                throw new NullReferenceException("string.Format(ExceptionMessages.MovieNotFound, id)");
            }

            return advert;
        }
    }
}
