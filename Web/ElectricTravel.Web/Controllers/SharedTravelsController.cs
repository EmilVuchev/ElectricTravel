namespace ElectricTravel.Web.Controllers
{
    using System.Threading.Tasks;

    using ElectricTravel.Services.Data.Contracts;
    using ElectricTravel.Web.InputViewModels.SharedTravel;
    using Microsoft.AspNetCore.Mvc;

    public class SharedTravelsController : Controller
    {
        private readonly ISharedTravelsService sharedTravelsService;
        private readonly ICitiesService citiesService;
        private readonly ITypeOfTravelService typeOfTravelService;

        public SharedTravelsController(ISharedTravelsService sharedTravelsService, ICitiesService citiesService, ITypeOfTravelService typeOfTravelService)
        {
            this.sharedTravelsService = sharedTravelsService;
            this.citiesService = citiesService;
            this.typeOfTravelService = typeOfTravelService;
        }

        ////public async Task<IActionResult> Index()
        ////{
        ////    var adverts = await this.sharedTravelsService.GetAllAsync<SharedTravelsViewModel>();

        ////    return this.View(adverts);
        ////}

        public IActionResult Create()
        {
            var inputModel = new SharedTravelCreateInputViewModel();
            inputModel.Cities = this.citiesService.GetAllAsKeyValuePairs();
            inputModel.TypesOfTravel = this.typeOfTravelService.GetAllAsKeyValuePairs();

            return this.View(inputModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(SharedTravelCreateInputViewModel input)
        {
            if (!this.ModelState.IsValid)
            {
                var inputModel = new SharedTravelCreateInputViewModel();
                inputModel.Cities = this.citiesService.GetAllAsKeyValuePairs();
                inputModel.TypesOfTravel = this.typeOfTravelService.GetAllAsKeyValuePairs();

                return this.View(inputModel);
            }

            await this.sharedTravelsService.CreateAsync(input);
            return this.Redirect("/");
        }

        ////public async Task<IActionResult> Details()
        ////{

        ////}
    }
}
