namespace ElectricTravel.Web.Areas.Administration.Controllers
{
    using System.Threading.Tasks;

    using ElectricTravel.Data.Models.User;
    using ElectricTravel.Services.Data.Contracts;
    using ElectricTravel.Web.InputViewModels.SharedTravel;
    using ElectricTravel.Web.ViewModels.Administration.SharedTravelAdverts;
    using ElectricTravel.Web.ViewModels.SharedTravels;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class SharedTravelAdvertsController : AdministrationController
    {
        private const int ItemsPerPage = 10;
        private readonly ISharedTravelsService sharedTravelsService;
        private readonly ICastCollectionsService castCollectionsService;
        private readonly UserManager<ElectricTravelUser> userManager;

        public SharedTravelAdvertsController(
            ISharedTravelsService sharedTravelsService,
            ICastCollectionsService castCollectionsService,
            UserManager<ElectricTravelUser> userManager)
        {
            this.sharedTravelsService = sharedTravelsService;
            this.castCollectionsService = castCollectionsService;
            this.userManager = userManager;
        }

        [Route("/Administration/SharedTravelAdverts/{id?}")]
        public async Task<IActionResult> Index(int id = 1)
        {
            var adverts = await this.sharedTravelsService.GetAllAsync<SharedTravelsViewModel>(id);

            if (adverts == null)
            {
                return this.NoContent();
            }

            var viewModel = new AdvertsListViewModel
            {
                ItemsPerPage = ItemsPerPage,
                PageNumber = id,
                AdvertsCount = await this.sharedTravelsService.GetAllAdvertsCount(),
                Adverts = adverts,
            };

            return this.View(viewModel);
        }

        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var advert = await this.sharedTravelsService.GetViewModelByIdAsync<SharedTravelAdvertViewModel>(id);

            if (advert == null)
            {
                return this.NotFound();
            }

            return this.View(advert);
        }

        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var citiesAsKVP = await this.castCollectionsService.GetCitiesAsKeyValuePairs();
            var typesAsKVP = await this.castCollectionsService.GetTravelTypesAsKeyValuePairs();

            var sharedTravelAdvert = await this.sharedTravelsService.GetViewModelByIdAsync(id);
            sharedTravelAdvert.Id = id;
            sharedTravelAdvert.Cities = citiesAsKVP;
            sharedTravelAdvert.TypesOfTravel = typesAsKVP;

            if (sharedTravelAdvert == null)
            {
                return this.NotFound();
            }

            return this.View(sharedTravelAdvert);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, SharedTravelEditInputViewModel input)
        {
            if (id != input.Id)
            {
                return this.NotFound();
            }

            var userId = this.userManager.GetUserId(this.User);

            if (this.ModelState.IsValid)
            {
                var isEdited = await this.sharedTravelsService.UpdateAsync(id, input, userId);

                if (!isEdited)
                {
                    return this.NotFound();
                }

                return this.RedirectToAction(nameof(this.Index));
            }

            var citiesAsKVP = await this.castCollectionsService.GetCitiesAsKeyValuePairs();
            var typesAsKVP = await this.castCollectionsService.GetTravelTypesAsKeyValuePairs();

            var advert = await this.sharedTravelsService.GetViewModelByIdAsync(id);
            advert.Id = id;
            advert.Cities = citiesAsKVP;
            advert.TypesOfTravel = typesAsKVP;

            return this.View(advert);
        }

        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var advert = await this.sharedTravelsService.GetViewModelByIdAsync<SharedTravelAdvertViewModel>(id);

            if (advert == null)
            {
                return this.NotFound();
            }

            return this.View(advert);
        }

        [HttpPost]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var userId = this.userManager.GetUserId(this.User);

            var isDeleted = await this.sharedTravelsService.DeleteAsync(id, userId);

            if (!isDeleted)
            {
                return this.NotFound();
            }

            return this.RedirectToAction(nameof(this.Index));
        }
    }
}
