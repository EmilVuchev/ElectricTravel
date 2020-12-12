namespace ElectricTravel.Web.Controllers
{
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
    using Microsoft.AspNetCore.Routing;

    public class SharedTravelsController : Controller
    {
        private readonly ISharedTravelsService sharedTravelsService;
        private readonly ICitiesService citiesService;
        private readonly ITypeOfTravelService typeOfTravelService;
        private readonly IRatingService ratingService;
        private readonly ICarsService carsService;
        private readonly IImagesService imagesService;
        private readonly AspNetUserManager<ElectricTravelUser> userManager;
        private readonly IUsersService usersService;

        public SharedTravelsController(
            ISharedTravelsService sharedTravelsService,
            IUsersService usersService,
            ICitiesService citiesService,
            ITypeOfTravelService typeOfTravelService,
            IRatingService ratingService,
            ICarsService carsService,
            IImagesService imagesService,
            AspNetUserManager<ElectricTravelUser> userManager)
        {
            this.sharedTravelsService = sharedTravelsService;
            this.citiesService = citiesService;
            this.typeOfTravelService = typeOfTravelService;
            this.ratingService = ratingService;
            this.carsService = carsService;
            this.imagesService = imagesService;
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

        [Authorize(Roles = GlobalConstants.DriverRoleName + ", " + GlobalConstants.AdministratorRoleName)]
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
            var createdBy = await this.userManager.FindByIdAsync(userId);

            var advertId = await this.sharedTravelsService.CreateAsync(input, userId);

            var model = new ThankYouVIewModel()
            {
                AdvertId = advertId,
                UserName = createdBy.UserName,
            };

            return this.View("ThankYou", model);
        }

        public IActionResult ThankYou(ThankYouVIewModel model)
        {
            if (model.AdvertId == null || model.UserName == null)
            {
                return this.NotFound();
            }

            return this.View(model);
        }

        public async Task<IActionResult> TripDetails(string id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

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
            var isDriver = await this.userManager.IsInRoleAsync(user, GlobalConstants.DriverRoleName);
            var isAdmin = await this.userManager.IsInRoleAsync(user, GlobalConstants.AdministratorRoleName);

            if (isAdmin)
            {
                return this.RedirectToAction(nameof(this.All));
            }
            else if (!isDriver)
            {
                return this.NoContent();
            }

            var model = new DriverCarListViewModel();
            model.Driver = await this.usersService.GetDriverInfo<DriverInfoViewModel>(id);
            model.Driver.ImagePath = await this.imagesService.GetSingleProfileImagePathByUserId(id);
            model.Cars = await this.carsService.GetCarsByUserId<DriverCarViewModel>(id);

            return this.View(model);
        }

        [Authorize(Roles = GlobalConstants.DriverRoleName + ", " + GlobalConstants.AdministratorRoleName)]
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var userId = this.userManager.GetUserId(this.User);

            var isDeleted = await this.sharedTravelsService.DeleteAsync(id, userId);

            if (isDeleted)
            {
                this.TempData["Message"] = "Your advert has been deleted";
            }

            return this.RedirectToAction("All");
        }

        [Authorize(Roles = GlobalConstants.DriverRoleName + ", " + GlobalConstants.AdministratorRoleName)]
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var inputModel = await this.sharedTravelsService.GetViewModelByIdAsync(id);
            inputModel.Id = id;
            inputModel.Cities = this.citiesService.GetAllAsKeyValuePairs();
            inputModel.TypesOfTravel = this.typeOfTravelService.GetAllAsKeyValuePairs();

            if (inputModel == null)
            {
                return this.NotFound();
            }

            return this.View(inputModel);
        }

        [HttpPost]
        [Authorize(Roles = GlobalConstants.DriverRoleName + ", " + GlobalConstants.AdministratorRoleName)]
        public async Task<IActionResult> Edit(string id, SharedTravelEditInputViewModel input)
        {
            if (!this.ModelState.IsValid)
            {
                ////??????
                return this.View("Error");
            }

            var userId = this.userManager.GetUserId(this.User);

            var hasEdited = await this.sharedTravelsService.UpdateAsync(id, input, userId);

            if (hasEdited)
            {
                this.TempData["Message"] = "Your advert has been edited";
            }

            return this.RedirectToAction(
                nameof(this.TripDetails),
                new RouteValueDictionary(new { controller = "SharedTravels", action = "TripDetails", Id = id }));
        }
    }
}
