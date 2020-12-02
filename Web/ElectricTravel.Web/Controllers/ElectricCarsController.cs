namespace ElectricTravel.Web.Controllers
{
    using System.Threading.Tasks;

    using ElectricTravel.Services.Data.Contracts;
    using ElectricTravel.Web.InputViewModels.ElectricCars;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class ElectricCarsController : Controller
    {
        private readonly ICarsService carsService;

        public ElectricCarsController(ICarsService carsService)
        {
            this.carsService = carsService;
        }

        [Authorize]
        public async Task<IActionResult> Index(string id)
        {
            var cars = await this.carsService.GetCarsByUserId(id);
            return this.View(cars);
        }

        [Authorize]
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
            return null;
        }
    }
}
