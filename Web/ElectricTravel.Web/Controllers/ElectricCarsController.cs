﻿namespace ElectricTravel.Web.Controllers
{
    using System.Threading.Tasks;

    using ElectricTravel.Common;
    using ElectricTravel.Data.Models.User;
    using ElectricTravel.Services.Data.Contracts;
    using ElectricTravel.Web.InputViewModels.ElectricCars;
    using ElectricTravel.Web.InputViewModels.Images;
    using ElectricTravel.Web.ViewModels.Cars;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Routing;

    [Authorize(Roles = GlobalConstants.DriverRoleName)]
    public class ElectricCarsController : Controller
    {
        private readonly ICarsService carsService;
        private readonly IImagesService imagesService;
        private readonly UserManager<ElectricTravelUser> userManager;
        private readonly IWebHostEnvironment environment;

        public ElectricCarsController(
            ICarsService carsService,
            IImagesService imagesService,
            UserManager<ElectricTravelUser> userManager,
            IWebHostEnvironment environment)
        {
            this.carsService = carsService;
            this.imagesService = imagesService;
            this.userManager = userManager;
            this.environment = environment;
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

        [HttpGet]
        public JsonResult GetModelsList(int makeId)
        {
            var modelsList = new SelectList(this.carsService.GetModelsByMakeId(makeId), "Id", "Name");
            return this.Json(modelsList);
        }

        public IActionResult Create()
        {
            this.ViewBag.Makes = new SelectList(this.carsService.GetMakes(), nameof(VehicleMakeViewModel.Id), nameof(VehicleMakeViewModel.Name));

            var inputModel = new ElectricCarInputViewModel();
            inputModel.CarTypes = this.carsService.GetAllCarTypesAsKeyValuePairs();

            return this.View(inputModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ElectricCarInputViewModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.RedirectToAction(nameof(this.Create));
            }

            var userId = this.userManager.GetUserId(this.User);
            var carId = await this.carsService.CreateCarAsync(input, userId);

            if (input.Images != null)
            {
                var imagePath = $"{this.environment.WebRootPath}/img";

                var imageUploadModel = new ImageUploadViewModel();
                imageUploadModel.Images = input.Images;
                imageUploadModel.Path = imagePath;
                imageUploadModel.UserId = userId;
                imageUploadModel.ImageTypeName = GlobalConstants.CarExternalImage;
                imageUploadModel.CarId = carId;

                await this.imagesService.UploadImages(imageUploadModel);
            }

            this.TempData["Message"] = "You can drive now. Your car is created successufully";

            return this.RedirectToAction(nameof(this.Index));
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            this.ViewBag.Makes = new SelectList(this.carsService.GetMakes(), nameof(VehicleMakeViewModel.Id), nameof(VehicleMakeViewModel.Name));
            var inputModel = await this.carsService.GetCarByIdForEdit(id);
            inputModel.CarTypes = this.carsService.GetAllCarTypesAsKeyValuePairs();

            if (inputModel == null)
            {
                return this.NotFound();
            }

            return this.View(inputModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, ElectricCarEditInputViewModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View("Error");
            }

            var userId = this.userManager.GetUserId(this.User);

            await this.carsService.UpdateAsync(id, input, userId);
            return this.RedirectToAction(
                nameof(this.Details),
                new RouteValueDictionary(new { controller = "ElectricCars", action = "Details", Id = id }));
        }

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

            return this.RedirectToAction(nameof(this.Index));
        }
    }
}
