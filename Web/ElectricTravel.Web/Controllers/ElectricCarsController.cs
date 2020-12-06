namespace ElectricTravel.Web.Controllers
{
    using System.Threading.Tasks;

    using ElectricTravel.Common;
    using ElectricTravel.Data.Models.User;
    using ElectricTravel.Services.Data.Contracts;
    using ElectricTravel.Web.InputViewModels.ElectricCars;
    using ElectricTravel.Web.ViewModels.Cars;
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

        public async Task<IActionResult> Index()
        {
            var userId = this.userManager.GetUserId(this.User);
            var cars = await this.carsService.GetCarsByUserId<AllCarsViewModel>(userId);

            if (cars == null)
            {
                return this.NotFound();
            }

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
        public async Task<IActionResult> Create(ElectricCarInputViewModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.Redirect("/ElectricCars/Create");
            }

            var userId = this.userManager.GetUserId(this.User);
            var count = await this.carsService.CreateCarAsync(input, userId);
            return this.RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var car = await this.carsService.EditAsync<CarViewModel>(id);

            if (car == null)
            {
                return this.NotFound();
            }

            return this.View(car);
        }

        ////[HttpPost]
        ////public async Task<IActionResult> Edit(int id, ElectricCarInputViewModel car)
        ////{
        ////    if (id != car.Id)
        ////    {
        ////        return this.NotFound();
        ////    }

        ////    if (this.ModelState.IsValid)
        ////    {
        ////        try
        ////        {
        ////            this.dataRepository.Update(category);
        ////            await this.dataRepository.SaveChangesAsync();
        ////        }
        ////        catch (DbUpdateConcurrencyException)
        ////        {
        ////            if (!this.CategoryExists(category.Id))
        ////            {
        ////                return this.NotFound();
        ////            }
        ////            else
        ////            {
        ////                throw;
        ////            }
        ////        }

        ////        return this.RedirectToAction(nameof(this.Index));
        ////    }

        ////    return this.View(category);
        ////}

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var carModel = await this.carsService.GetCarById<CarViewModel>(id);

            if (carModel == null)
            {
                return this.NotFound();
            }

            return this.View(carModel);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var isSuccessfullyDeleted = await this.carsService.DeleteCarAsync(id);

            if (isSuccessfullyDeleted)
            {
                this.TempData["Deleted"] = "Successfully deleted!";
            }
            else
            {
                this.TempData["Deleted"] = "Something is wrong - unsuccessfull delete! Try again later!";
            }

            return this.RedirectToAction("Index");
        }
    }
}
