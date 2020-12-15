namespace ElectricTravel.Web.Areas.Administration.Controllers
{
    using System.Threading.Tasks;

    using ElectricTravel.Services.Data.Contracts;
    using ElectricTravel.Web.InputViewModels.Cities;
    using ElectricTravel.Web.ViewModels.Cities;
    using Microsoft.AspNetCore.Mvc;

    public class CitiesController : AdministrationController
    {
        private readonly ICitiesService citiesService;
        private readonly ICastCollectionsService castCollectionsService;

        public CitiesController(
            ICitiesService citiesService,
            ICastCollectionsService castCollectionsService)
        {
            this.citiesService = citiesService;
            this.castCollectionsService = castCollectionsService;
        }

        public async Task<IActionResult> Index()
        {
            var cities = await this.citiesService.GetAll<CityViewModel>();

            return this.View(cities);
        }

        public async Task<IActionResult> Create()
        {
            var input = new CreateCityInputViewModel();
            input.Regions = await this.castCollectionsService.GetRegionsAsKeyValuePairs();
            return this.View(input);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCityInputViewModel input)
        {
            if (this.ModelState.IsValid)
            {
                var isCreated = await this.citiesService.CreateAsync(input);

                if (!isCreated)
                {
                    this.TempData["Message"] = $"Already have city with {input.Name} name.";
                }

                return this.RedirectToAction(nameof(this.Index));
            }

            var inputModel = new CreateCityInputViewModel();
            inputModel.Regions = await this.castCollectionsService.GetRegionsAsKeyValuePairs();
            return this.View(inputModel);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var city = await this.citiesService.GetCityByIdAsync<CityViewModel>(id);

            if (city == null)
            {
                return this.NotFound();
            }

            return this.View(city);
        }

        [HttpPost]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await this.citiesService.DeleteAsync(id);

            return this.RedirectToAction(nameof(this.Index));
        }
    }
}
