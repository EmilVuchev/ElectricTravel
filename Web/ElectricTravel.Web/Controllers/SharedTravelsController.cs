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
        private readonly AspNetUserManager<ElectricTravelUser> userManager;
        private readonly IUsersService usersService;

        public SharedTravelsController(ISharedTravelsService sharedTravelsService, ICitiesService citiesService, ITypeOfTravelService typeOfTravelService, AspNetUserManager<ElectricTravelUser> userManager, IUsersService usersService)
        {
            this.sharedTravelsService = sharedTravelsService;
            this.citiesService = citiesService;
            this.typeOfTravelService = typeOfTravelService;
            this.userManager = userManager;
            this.usersService = usersService;
        }

        public async Task<IActionResult> All()
        {
            var adverts = await this.sharedTravelsService.GetAllAsync<SharedTravelsViewModel>();

            return this.View(adverts);
        }

        [Authorize]
        public async Task<IActionResult> AllByAuthor(string id)
        {
            var adverts = await this.sharedTravelsService.GetAllByAuthorId<SharedTravelsViewModel>(id);

            if (adverts == null)
            {
                return this.View("Error");
            }

            return this.View(adverts);
        }

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

            var userId = this.userManager.GetUserId(this.User);
            input.CreatedById = userId;

            var outputViewModel = await this.sharedTravelsService.CreateAsync(input);
            return this.View("ThankYou", outputViewModel);
        }

        public IActionResult ThankYou()
        {
            return this.View();
        }

        public async Task<IActionResult> Detail(string id)
        {
            var advert = await this.sharedTravelsService.GetViewModelByIdAsync<SharedTravelDetailsViewModel>(id);
            var profilePic = await this.usersService.GetUserPictureByAdvertId(advert.Id);

            if (advert == null)
            {
                return this.BadRequest();
            }

            var advertUserImage = new AdvertUserImageViewModel
            {
                AdvertInfo = advert,
                Image = profilePic,
            };

            return this.View(advertUserImage);
        }
    }
}
