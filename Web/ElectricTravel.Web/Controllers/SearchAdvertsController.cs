
namespace ElectricTravel.Web.Controllers
{
    using System.Threading.Tasks;

    using ElectricTravel.Data.Models.User;
    using ElectricTravel.Services.Data.Contracts;
    using ElectricTravel.Web.Controllers.Common;
    using ElectricTravel.Web.ViewModels.SharedTravels;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class SearchAdvertsController : Controller
    {
        private readonly ISharedTravelsService sharedTravelsService;
        private readonly UserManager<ElectricTravelUser> userManager;

        public SearchAdvertsController(
            ISharedTravelsService sharedTravelsService,
            UserManager<ElectricTravelUser> userManager)
        {
            this.sharedTravelsService = sharedTravelsService;
            this.userManager = userManager;
        }

        public async Task<IActionResult> SearchForUserAdvertsDestination(string search, int id = 1)
        {
            if (search == null)
            {
                return this.NoContent();
            }

            this.ViewData["Getadvertsdetails"] = search;

            var userId = this.userManager.GetUserId(this.User);

            var adverts = await this.sharedTravelsService
                .GetUserAdvertByDestination<SharedTravelsViewModel>(search, userId, id, ControllersConstants.ItemsPerPage);

            if (adverts == null)
            {
                return this.NoContent();
            }

            var viewModel = new AdvertsListViewModel
            {
                IsUserAdverts = true,
                ItemsPerPage = ControllersConstants.ItemsPerPage,
                PageNumber = id,
                AdvertsCount = await this.sharedTravelsService.GetSearchedUserAdvertsCount(search, userId),
                Adverts = adverts,
            };

            return this.View("../SharedTravels/AllByAuthor", viewModel);
        }

        public async Task<IActionResult> SearchByDestinations(string search, int id = 1)
        {
            if (search == null)
            {
                return this.NoContent();
            }

            this.ViewData["Getadvertsdetails"] = search;

            var adverts = await this.sharedTravelsService
                .GetByDestinationAsync<SharedTravelsViewModel>(search, id, ControllersConstants.ItemsPerPage);

            if (adverts == null)
            {
                return this.NoContent();
            }

            var viewModel = new AdvertsListViewModel
            {
                IsUserAdverts = false,
                ItemsPerPage = ControllersConstants.ItemsPerPage,
                PageNumber = id,
                AdvertsCount = await this.sharedTravelsService.GetSearchedAdvertsCount(search),
                Adverts = adverts,
            };

            return this.View("../SharedTravels/All", viewModel);
        }
    }
}

namespace ElectricTravel.Web.Controllers
{
    using System.Threading.Tasks;

    using ElectricTravel.Data.Models.User;
    using ElectricTravel.Services.Data.Contracts;
    using ElectricTravel.Web.Controllers.Common;
    using ElectricTravel.Web.ViewModels.SharedTravels;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class SearchAdvertsController : Controller
    {
        private readonly ISharedTravelsService sharedTravelsService;
        private readonly UserManager<ElectricTravelUser> userManager;

        public SearchAdvertsController(
            ISharedTravelsService sharedTravelsService,
            UserManager<ElectricTravelUser> userManager)
        {
            this.sharedTravelsService = sharedTravelsService;
            this.userManager = userManager;
        }

        public async Task<IActionResult> SearchForUserAdvertsDestination(string search, int id = 1)
        {
            if (search == null)
            {
                return this.NoContent();
            }

            this.ViewData["Getadvertsdetails"] = search;

            var userId = this.userManager.GetUserId(this.User);

            var adverts = await this.sharedTravelsService
                .GetUserAdvertByDestination<SharedTravelsViewModel>(search, userId, id, ControllersConstants.ItemsPerPage);

            if (adverts == null)
            {
                return this.NoContent();
            }

            var viewModel = new AdvertsListViewModel
            {
                IsUserAdverts = true,
                ItemsPerPage = ControllersConstants.ItemsPerPage,
                PageNumber = id,
                AdvertsCount = await this.sharedTravelsService.GetSearchedUserAdvertsCount(search, userId),
                Adverts = adverts,
            };

            return this.View("../SharedTravels/AllByAuthor", viewModel);
        }

        public async Task<IActionResult> SearchByDestinations(string search, int id = 1)
        {
            if (search == null)
            {
                return this.NoContent();
            }

            this.ViewData["Getadvertsdetails"] = search;

            var adverts = await this.sharedTravelsService
                .GetByDestinationAsync<SharedTravelsViewModel>(search, id, ControllersConstants.ItemsPerPage);

            if (adverts == null)
            {
                return this.NoContent();
            }

            var viewModel = new AdvertsListViewModel
            {
                IsUserAdverts = false,
                ItemsPerPage = ControllersConstants.ItemsPerPage,
                PageNumber = id,
                AdvertsCount = await this.sharedTravelsService.GetSearchedAdvertsCount(search),
                Adverts = adverts,
            };

            return this.View("../SharedTravels/All", viewModel);
        }
    }
}

