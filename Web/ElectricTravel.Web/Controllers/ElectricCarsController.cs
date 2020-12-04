namespace ElectricTravel.Web.Controllers
{
    using System.Threading.Tasks;

    using ElectricTravel.Common;
    using ElectricTravel.Data.Models.User;
    using ElectricTravel.Services.Data.Contracts;
    using ElectricTravel.Web.InputViewModels.ElectricCars;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = GlobalConstants.DriverRoleName)]
    public class ElectricCarsController : Controller
    {
        private readonly ICarsService carsService;
        private readonly IImagesService imagesService;
        private readonly UserManager<ElectricTravelUser> userManager;

        public ElectricCarsController(
            ICarsService carsService,
            IImagesService imagesService,
            UserManager<ElectricTravelUser> userManager)
        {
            this.carsService = carsService;
            this.imagesService = imagesService;
            this.userManager = userManager;
        }

        public async Task<IActionResult> Index(string id)
        {
            var cars = await this.carsService.GetCarsByUserId(id);
            return this.View(cars);
        }

        public IActionResult Create()
        {
            var inputModel = new ElectricCarInputViewModel();
            inputModel.CarMakes = this.carsService.GetAllCarMakesAsKeyValuePairs();
            inputModel.CarModels = this.carsService.GetAllCarModelsAsKeyValuePairs();
            inputModel.CarTypes = this.carsService.GetAllCarTypesAsKeyValuePairs();

            return this.View(inputModel);
        }

        [HttpPost]
        public IActionResult Create(ElectricCarInputViewModel input)
        {
            var userId = this.userManager.GetUserId(this.User);
            this.carsService.CreateCarAsync(input, userId);
            return this.RedirectToAction("Index");
        }
    }
}
