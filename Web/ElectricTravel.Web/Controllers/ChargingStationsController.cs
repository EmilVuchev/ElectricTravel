namespace ElectricTravel.Web.Controllers
{
    using System.Threading.Tasks;

    using ElectricTravel.Common;
    using ElectricTravel.Services.Data.Contracts;
    using ElectricTravel.Web.InputViewModels.ChargingStations;
    using ElectricTravel.Web.ViewModels.ChargingStations;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class ChargingStationsController : BaseController
    {
        private readonly IChargingStationsService chargingStationsService;
        private readonly ICastCollectionsService castCollectionsService;

        public ChargingStationsController(
            IChargingStationsService chargingStationsService,
            ICastCollectionsService castCollectionsService)
        {
            this.chargingStationsService = chargingStationsService;
            this.castCollectionsService = castCollectionsService;
        }

        public async Task<IActionResult> Index()
        {
            var chargingStations = await this.chargingStationsService.GetAll<ChargingStationViewModel>();

            return this.View(chargingStations);
        }

        public async Task<IActionResult> Details(int id)
        {
            if (id == 0)
            {
                return this.NotFound();
            }

            var chargingStation =
                await this.chargingStationsService.GetById(id);

            if (chargingStation == null)
            {
                return this.NotFound();
            }

            return this.View(chargingStation);
        }

        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        public async Task<IActionResult> Create()
        {
            var input = new ChargingStationInputViewModel();
            input.Cities = await this.castCollectionsService.GetCitiesAsKeyValuePairs();

            return this.View(input);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        public async Task<IActionResult> Create(ChargingStationInputViewModel chargingStation)
        {
            if (this.ModelState.IsValid)
            {
                await this.chargingStationsService.CreateAsync(chargingStation);

                return this.RedirectToAction(nameof(this.Index));
            }

            var input = new ChargingStationInputViewModel();
            input.Cities = await this.castCollectionsService.GetCitiesAsKeyValuePairs();

            return this.View(input);
        }

        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0)
            {
                return this.NotFound();
            }

            var chargingStation =
                await this.chargingStationsService.GetById(id);

            if (chargingStation == null)
            {
                return this.NotFound();
            }

            return this.View(chargingStation);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var isDeleted = await this.chargingStationsService.DeleteAsync(id);

            if (!isDeleted)
            {
                return this.NotFound();
            }

            return this.RedirectToAction(nameof(this.Index));
        }
    }
}
