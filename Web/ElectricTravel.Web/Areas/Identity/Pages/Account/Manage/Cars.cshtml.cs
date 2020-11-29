namespace ElectricTravel.Web.Areas.Identity.Pages.Account.Manage
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using ElectricTravel.Data.Models.User;
    using ElectricTravel.Services.Data.Contracts;
    using ElectricTravel.Web.InputViewModels.ElectricCars;
    using ElectricTravel.Web.ViewModels.Cars;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using MyFirstAspNetCoreApplication.ValidationAttributes;

    public class CarProfileModel : PageModel
    {
        private readonly UserManager<ElectricTravelUser> userManager;
        private readonly ICarsService carsService;

        public CarProfileModel(
            UserManager<ElectricTravelUser> userManager,
            ICarsService carsService)
        {
            this.userManager = userManager;
            this.carsService = carsService;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        [BindProperty]
        public ICollection<InputModel> Inputs { get; set; }

        public class InputModel
        {
            [Range(50.0, 2000.0)]
            public double Range { get; set; }

            [Display(Name = "Kilometrage")]
            [Range(0, 2000000)]
            public int Kilometres { get; set; }

            [MaxLength(10)]
            public string Acceleration { get; set; }

            [Display(Name = "Top speed")]
            [Range(100.0, 700.0)]
            public double TopSpeed { get; set; }

            [Required]
            [MaxLength(10)]
            public string Battery { get; set; }

            [Display(Name = "Consumtion")]
            [MaxLength(10)]
            public string ElectricityConsumption { get; set; }

            [MaxLength(10)]
            public string Drive { get; set; }

            [CurrentYearMaxValue(1900)]
            public int Year { get; set; }

            [Display(Name = "Horse power")]
            [Range(50, 2000)]
            public int HorsePower { get; set; }

            [Range(3, 20)]
            public int Seats { get; set; }

            [Range(3, 5)]
            public int Doors { get; set; }

            [MaxLength(20)]
            public string Color { get; set; }

            [Display(Name = "Luggage capacity")]
            [Range(50, 5000)]
            public int? LuggageCapacity { get; set; }

            [Display(Name = "Car type")]
            public int CarTypeId { get; set; }

            [Display(Name = "Car make")]
            public int CarMakeId { get; set; }

            public string CarMakeName { get; set; }

            [Display(Name = "Car model")]
            public int CarModelId { get; set; }

            public string CarModelName { get; set; }

            public IEnumerable<IFormFile> Images { get; set; }

            public IEnumerable<string> ImagesVideosPaths { get; set; }

            public IEnumerable<IFormFile> Videos { get; set; }

            public IEnumerable<KeyValuePair<string, string>> CarTypes { get; set; }

            public IEnumerable<KeyValuePair<string, string>> CarMakes { get; set; }

            public IEnumerable<KeyValuePair<string, string>> CarModels { get; set; }
        }

        private async Task LoadAsync()
        {
            var cars = await this.carsService.GetCarsByUserId(this.User.FindFirstValue(ClaimTypes.NameIdentifier));
            var carMakes = this.carsService.GetAllCarMakesAsKeyValuePairs();
            var carModels = this.carsService.GetAllCarModelsAsKeyValuePairs();
            var carTypes = this.carsService.GetAllCarTypesAsKeyValuePairs();

            this.Input = new InputModel();
            this.Input.CarTypes = carTypes;
            this.Input.CarMakes = carMakes;
            this.Input.CarModels = carModels;

            var imagesAndVideosPaths = new List<string>();

            this.Inputs = new List<InputModel>();

            foreach (var car in cars)
            {
                foreach (var video in car.Videos)
                {
                    imagesAndVideosPaths.Add(video.Path);
                }

                foreach (var image in car.Images)
                {
                    imagesAndVideosPaths.Add(image.Path);
                }

                this.Inputs.Add(new InputModel
                {
                    CarMakeName = car.CarMakeName,
                    CarModelName = car.CarModelName,
                    Seats = car.Seats,
                    TopSpeed = car.TopSpeed,
                    Acceleration = car.Acceleration,
                    Battery = car.Battery,
                    Color = car.Color,
                    Doors = car.Doors,
                    Drive = car.Drive,
                    ElectricityConsumption = car.ElectricityConsumption,
                    HorsePower = car.HorsePower,
                    Kilometres = car.Kilometres,
                    LuggageCapacity = car.LuggageCapacity,
                    Range = car.Range,
                    Year = car.Year,
                    CarModels = carModels,
                    CarMakes = carMakes,
                    CarTypes = carTypes,
                    ImagesVideosPaths = imagesAndVideosPaths,
                });
            }
        }

        public async Task<IActionResult> OnGetAsync()
        {
            await this.LoadAsync();
            return this.Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!this.ModelState.IsValid)
            {
                await this.LoadAsync();
                return this.Page();
            }

            var input = new ElectricCarsInputViewModel
            {
                Seats = this.Input.Seats,
                TopSpeed = this.Input.TopSpeed,
                Acceleration = this.Input.Acceleration,
                Battery = this.Input.Battery,
                Color = this.Input.Color,
                Doors = this.Input.Doors,
                Drive = this.Input.Drive,
                ElectricityConsumption = this.Input.ElectricityConsumption,
                HorsePower = this.Input.HorsePower,
                Kilometres = this.Input.Kilometres,
                LuggageCapacity = this.Input.LuggageCapacity,
                Range = this.Input.Range,
                Year = this.Input.Year,
                CarMakeId = this.Input.CarMakeId,
                CarModelId = this.Input.CarModelId,
                CarTypeId = this.Input.CarTypeId,
            };

            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            await this.carsService.CreateCarAsync(input, userId);

            return this.RedirectToPage();
        }
    }
}
