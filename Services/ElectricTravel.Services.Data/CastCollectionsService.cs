namespace ElectricTravel.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using ElectricTravel.Services.Data.Contracts;
    using ElectricTravel.Web.ViewModels.Cities;
    using ElectricTravel.Web.ViewModels.Regions;
    using ElectricTravel.Web.ViewModels.TypeTravels;

    public class CastCollectionsService : ICastCollectionsService
    {
        private readonly ITypeOfTravelService typeOfTravelService;
        private readonly ICitiesService citiesService;

        public CastCollectionsService(
            ITypeOfTravelService typeOfTravelService,
            ICitiesService citiesService)
        {
            this.typeOfTravelService = typeOfTravelService;
            this.citiesService = citiesService;
        }

        public async Task<IEnumerable<KeyValuePair<string, string>>> GetTravelTypesAsKeyValuePairs()
        {
            var travelTypes = await this.typeOfTravelService.GetAll<TypeTravelViewModel>();
            var typesAsKVP = travelTypes.Select(x => new KeyValuePair<string, string>(x.Id.ToString(), x.Name));
            return typesAsKVP;
        }

        public async Task<IEnumerable<KeyValuePair<string, string>>> GetCitiesAsKeyValuePairs()
        {
            var cities = await this.citiesService.GetAll<CityForKeyValuePairViewModel>();
            cities = cities.OrderBy(x => x.Name);
            var citiesAsKVP = cities.Select(x => new KeyValuePair<string, string>(x.Id.ToString(), x.Name));
            return citiesAsKVP;
        }

        public async Task<IEnumerable<KeyValuePair<string, string>>> GetRegionsAsKeyValuePairs()
        {
            var cities = await this.citiesService.GetAllRegions<RegionViewModel>();
            cities = cities.OrderBy(x => x.Name);
            var citiesAsKVP = cities.Select(x => new KeyValuePair<string, string>(x.Id.ToString(), x.Name));
            return citiesAsKVP;
        }
    }
}
