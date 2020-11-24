namespace ElectricTravel.Web.Controllers
{
    using System.Threading.Tasks;

    using ElectricTravel.Data.Models.User;
    using ElectricTravel.Services.Data.Contracts;
    using ElectricTravel.Web.InputViewModels.SharedTravel;
    using ElectricTravel.Web.ViewModels.SharedTravels;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class SharedTravelsController : Controller
    {
        private readonly ISharedTravelsService sharedTravelsService;
        private readonly ICitiesService citiesService;
        private readonly ITypeOfTravelService typeOfTravelService;
        private readonly IRatingService ratingService;
        private readonly AspNetUserManager<ElectricTravelUser> userManager;
        private readonly IUsersService usersService;

        public SharedTravelsController(
            ISharedTravelsService sharedTravelsService,
            IUsersService usersService,
            ICitiesService citiesService,
            ITypeOfTravelService typeOfTravelService,
            IRatingService ratingService,
            AspNetUserManager<ElectricTravelUser> userManager)
        {
            this.sharedTravelsService = sharedTravelsService;
            this.citiesService = citiesService;
            this.typeOfTravelService = typeOfTravelService;
            this.ratingService = ratingService;
            this.userManager = userManager;
            this.usersService = usersService;
        }

        public async Task<IActionResult> All()
        {
            var adverts = await this.sharedTravelsService.GetAllAsync<SharedTravelsViewModel>();

            if (adverts == null)
            {
                return this.NoContent();
            }

            return this.View(adverts);
        }

        [Authorize]
        public async Task<IActionResult> AllByAuthor()
        {
            var userId = this.userManager.GetUserId(this.User);
            var adverts = await this.sharedTravelsService.GetAllByAuthorId<SharedTravelsViewModel>(userId);

            if (adverts == null)
            {
                return this.View("Error");
            }

            return this.View(adverts);
        }

        [Authorize]
        public IActionResult Create()
        {
            var inputModel = new SharedTravelCreateInputViewModel();
            inputModel.Cities = this.citiesService.GetAllAsKeyValuePairs();
            inputModel.TypesOfTravel = this.typeOfTravelService.GetAllAsKeyValuePairs();

            return this.View(inputModel);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(SharedTravelCreateInputViewModel input)
        {
            if (!this.ModelState.IsValid)
            {
                var inputModel = new SharedTravelCreateInputViewModel();
                inputModel.Cities = this.citiesService.GetAllAsKeyValuePairs();
                inputModel.TypesOfTravel = this.typeOfTravelService.GetAllAsKeyValuePairs();

                return this.View(inputModel);
            }

            var userId = this.userManager.GetUserId(this.User);

            var outputViewModel = await this.sharedTravelsService.CreateAsync(input, userId);
            return this.View("ThankYou", outputViewModel);
        }

        public IActionResult ThankYou()
        {
            return this.View();
        }

        public async Task<IActionResult> Details(string id)
        {
            var advertUserInfo = await this.sharedTravelsService.GetViewModelByIdAsync<SharedTravelDetailsViewModel>(id);

            if (advertUserInfo == null)
            {
                return this.BadRequest();
            }

            return this.View(advertUserInfo);
        }
    }
}
