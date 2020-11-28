namespace ElectricTravel.Web.Areas.Identity.Pages.Account.Manage
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using ElectricTravel.Data.Models.User;
    using ElectricTravel.Services.Data.Contracts;
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

            [Range(50, 5000)]
            public int? LuggageCapacity { get; set; }

            public IEnumerable<KeyValuePair<string, string>> CarTypes { get; set; }

            public IEnumerable<KeyValuePair<string, string>> Makes { get; set; }

            public IEnumerable<KeyValuePair<string, string>> Models { get; set; }
        }

        private async Task LoadAsync()
        {
            var cars = await this.carsService.GetCarsByUserId(this.User.FindFirstValue(ClaimTypes.NameIdentifier));
            var carModels = this.carsService.GetAllCarModelsAsKeyValuePairs();
            var carMakes = this.carsService.GetAllCarMakesAsKeyValuePairs();
            var carTypes = this.carsService.GetAllCarTypesAsKeyValuePairs();

            foreach (var car in cars)
            {
                this.Inputs.Add(new InputModel
                {
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
                    Models = carModels,
                    Makes = carMakes,
                    CarTypes = carTypes,
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

            return this.RedirectToPage();
        }
    }
}
