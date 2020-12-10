namespace ElectricTravel.Web.Controllers
{
    using System.Security.Claims;
    using System.Threading.Tasks;
    using ElectricTravel.Common;
    using ElectricTravel.Data.Models.User;
    using ElectricTravel.Services.Data.Contracts;
    using ElectricTravel.Web.Controllers.Common;
    using ElectricTravel.Web.InputViewModels.SharedTravel;
    using ElectricTravel.Web.ViewModels.Cars;
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
        private readonly ICarsService carsService;
        private readonly AspNetUserManager<ElectricTravelUser> userManager;
        private readonly IUsersService usersService;

        public SharedTravelsController(
            ISharedTravelsService sharedTravelsService,
            IUsersService usersService,
            ICitiesService citiesService,
            ITypeOfTravelService typeOfTravelService,
            IRatingService ratingService,
            ICarsService carsService,
            AspNetUserManager<ElectricTravelUser> userManager)
        {
            this.sharedTravelsService = sharedTravelsService;
            this.citiesService = citiesService;
            this.typeOfTravelService = typeOfTravelService;
            this.ratingService = ratingService;
            this.carsService = carsService;
            this.userManager = userManager;
            this.usersService = usersService;
        }

        public async Task<IActionResult> All(int id = 1)
        {
            if (id <= 0)
            {
                return this.NotFound();
            }

            var adverts = await this.sharedTravelsService.GetAllAsync<SharedTravelsViewModel>(id, ControllersConstants.ItemsPerPage);

            if (adverts == null)
            {
                return this.NoContent();
            }

            var viewModel = new AdvertsListViewModel
            {
                IsUserAdverts = false,
                ItemsPerPage = ControllersConstants.ItemsPerPage,
                PageNumber = id,
                AdvertsCount = await this.sharedTravelsService.GetAllAdvertsCount(),
                Adverts = adverts,
            };

            return this.View(viewModel);
        }

        [Authorize]
        public async Task<IActionResult> AllByAuthor(int id = 1)
        {
            if (id <= 0)
            {
                return this.NotFound();
            }

            const int itemsPerPage = 10;
            var userId = this.userManager.GetUserId(this.User);
            var adverts = await this.sharedTravelsService.GetAllByAuthorId<SharedTravelsViewModel>(userId, id, itemsPerPage);

            if (adverts == null)
            {
                return this.NoContent();
            }

            var viewModel = new AdvertsListViewModel
            {
                IsUserAdverts = true,
                ItemsPerPage = itemsPerPage,
                PageNumber = id,
                AdvertsCount = await this.sharedTravelsService.GetAdvertsCountByUser(userId),
                Adverts = adverts,
            };

            return this.View(viewModel);
        }

        [Authorize(Roles = GlobalConstants.DriverRoleName)]
        public IActionResult Create()
        {
            var inputModel = new SharedTravelCreateInputViewModel();
            inputModel.Cities = this.citiesService.GetAllAsKeyValuePairs();
            inputModel.TypesOfTravel = this.typeOfTravelService.GetAllAsKeyValuePairs();

            return this.View(inputModel);
        }

        [HttpPost]
        [Authorize(Roles = GlobalConstants.DriverRoleName + ", " + GlobalConstants.AdministratorRoleName)]
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

        public async Task<IActionResult> TripDetails(string id)
        {
            var advertInfo = await this.sharedTravelsService.GetViewModelByIdAsync<SharedTravelDetailsViewModel>(id);

            if (advertInfo == null)
            {
                return this.BadRequest();
            }

            return this.View(advertInfo);
        }

        public async Task<IActionResult> DriverDetails(string id)
        {
            var user = await this.userManager.FindByIdAsync(id);
            var isInRole = await this.userManager.IsInRoleAsync(user, GlobalConstants.DriverRoleName);

            if (!isInRole)
            {
                return this.NotFound();
            }

            var model = new DriverCarListViewModel();
            model.Driver = await this.usersService.GetDriverInfo<DriverInfoViewModel>(id);
            model.Cars = await this.carsService.GetCarsByUserId<DriverCarViewModel>(id);

            return this.View(model);
        }
    }
}
