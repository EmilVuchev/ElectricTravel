namespace ElectricTravel.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using ElectricTravel.Common;
    using ElectricTravel.Data.Common.Repositories;
    using ElectricTravel.Data.Models.Advertisement;
    using ElectricTravel.Services.Data.Common;
    using ElectricTravel.Services.Data.Contracts;
    using ElectricTravel.Services.Mapping;
    using ElectricTravel.Web.InputViewModels.SharedTravel;
    using ElectricTravel.Web.ViewModels.SharedTravels;
    using Microsoft.EntityFrameworkCore;

    public class SharedTravelsService : ISharedTravelsService
    {
        private readonly IDeletableEntityRepository<SharedTravelAdvert> sharedTravelsRepository;
        private readonly IDeletableEntityRepository<SharedTravelStatus> sharedTravelStatusRepository;

        public SharedTravelsService(
            IDeletableEntityRepository<SharedTravelAdvert> sharedTravelsRepository,
            IDeletableEntityRepository<SharedTravelStatus> sharedTravelStatusRepository)
        {
            this.sharedTravelsRepository = sharedTravelsRepository;
            this.sharedTravelStatusRepository = sharedTravelStatusRepository;
        }

        public async Task<string> CreateAsync(SharedTravelCreateInputViewModel input, string userId)
        {
            var statusId = this.sharedTravelStatusRepository
                .AllAsNoTracking()
                .Where(x => x.Name == ServicesConstants.AdvertDefaultStatus)
                .Select(x => x.Id)
                .FirstOrDefault();

            var sharedTravelAdvert = new SharedTravelAdvert
            {
                StatusId = statusId,
                Seats = input.Seats,
                StartDateAndTime = input.StartDateAndTime,
                CreatedById = userId,
                StartDestinationId = input.StartDestinationId,
                EndDestinationId = input.EndDestinationId,
                SmokeRestriction = IsTrue(input.SmokeRestriction),
                PlaceForLuggage = IsTrue(input.PlaceForLuggage),
                WithReturnTrip = IsTrue(input.WithReturnTrip),
                TypeOfTravelId = input.TypeOfTravelId,
                Description = input.Description,
            };

            await this.sharedTravelsRepository.AddAsync(sharedTravelAdvert);
            await this.sharedTravelsRepository.SaveChangesAsync();

            var sharedTravelId = sharedTravelAdvert.Id;

            return sharedTravelId;
        }

        public Task DeleteByIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<T>> GetAllAsync<T>(int page, int itemsPerPage = 10)
        {
            var adverts = await this.sharedTravelsRepository
                   .AllAsNoTracking()
                   .Where(x => x.Status.Name == ServicesConstants.AdvertDefaultStatus)
                   .Skip(PageFormula(page, itemsPerPage))
                   .Take(itemsPerPage)
                   .OrderBy(x => x.StartDateAndTime)
                   .To<T>()
                   .ToListAsync();

            return adverts;
        }

        public async Task<IEnumerable<T>> GetAllByAuthorId<T>(string id, int page, int itemsPerPage)
        {
            var adverts = await this.sharedTravelsRepository
                .All()
                .Where(a => a.CreatedById == id)
                .Skip(PageFormula(page, itemsPerPage))
                .Take(itemsPerPage)
                .To<T>()
                .ToListAsync();

            return adverts;
        }

        public async Task<IEnumerable<T>> GetByDestinationAsync<T>(string search, int page, int itemsPerPage)
        {
            var destination = search.ToLower();

            return await this.sharedTravelsRepository
                 .AllAsNoTracking()
                 .Where(x => x.StartDestination.Name.ToLower() == destination || x.EndDestination.Name.ToLower() == destination)
                 .Skip(PageFormula(page, itemsPerPage))
                 .Take(itemsPerPage)
                 .To<T>()
                 .ToListAsync();
        }

        public async Task<IEnumerable<T>> GetUserAdvertByDestination<T>(string search, string userId, int page, int itemsPerPage)
        {
            var destination = search.ToLower();

            return await this.sharedTravelsRepository
                .AllAsNoTracking()
                .Where(x =>
                    x.CreatedById == userId &&
                    (x.StartDestination.Name.ToLower() == destination || x.EndDestination.Name.ToLower() == destination))
                .Skip(PageFormula(page, itemsPerPage))
                .Take(itemsPerPage)
                .To<T>()
                .ToListAsync();
        }

        public async Task<int> GetAdvertsCountByUser(string userId)
        {
            return await this.sharedTravelsRepository
                .All()
                .Where(x => x.CreatedById == userId)
                .CountAsync();
        }

        public async Task<int> GetAllAdvertsCount()
        {
            return await this.sharedTravelsRepository
                .All()
                .CountAsync();
        }

        public async Task<int> GetSearchedUserAdvertsCount(string search, string userId)
        {
            var destination = search.ToLower();

            return await this.sharedTravelsRepository
                .AllAsNoTracking()
                .Where(x =>
                    x.CreatedById == userId &&
                    (x.StartDestination.Name.ToLower() == destination || x.EndDestination.Name.ToLower() == destination))
                .CountAsync();
        }

        public async Task<int> GetSearchedAdvertsCount(string search)
        {
            var destination = search.ToLower();

            return await this.sharedTravelsRepository
                    .AllAsNoTracking()
                    .Where(x => x.StartDestination.Name.ToLower() == destination || x.EndDestination.Name.ToLower() == destination)
                    .CountAsync();
        }

        public async Task<T> GetViewModelByIdAsync<T>(string id)
        {
            var advert = await this.sharedTravelsRepository
                .All()
                .Where(a => a.Id == id)
                .To<T>()
                .FirstOrDefaultAsync();

            if (advert == null)
            {
                ////TODO Exception Messages
                throw new NullReferenceException("string.Format(ExceptionMessages.MovieNotFound, id)");
            }

            return advert;
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

        private static bool IsTrue(string input)
        {
            return input == GlobalConstants.TrueState ? true : false;
        }

        private static int PageFormula(int page, int itemsPerPage)
        {
            return (page - 1) * itemsPerPage;
        }
    }
}
