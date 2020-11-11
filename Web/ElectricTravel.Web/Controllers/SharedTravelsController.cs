namespace ElectricTravel.Web.Controllers
{
    using System.Threading.Tasks;

    using ElectricTravel.Services.Data.Contracts;
    using ElectricTravel.Web.InputViewModels.SharedTravel;
    using ElectricTravel.Web.ViewModels.SharedTravels;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class SharedTravelsController : Controller
    {
        private readonly ISharedTravelsService sharedTravelsService;

        public SharedTravelsController(ISharedTravelsService sharedTravelsService)
        {
            this.sharedTravelsService = sharedTravelsService;
        }

        ////public async Task<IActionResult> Index()
        ////{
        ////    var adverts = await this.sharedTravelsService.GetAllAsync<SharedTravelsViewModel>();

        ////    return this.View(adverts);
        ////}

        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(SharedTravelCreateInputViewModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            await this.sharedTravelsService.CreateAsync(input);
            return this.Redirect("/");
        }

        ////public async Task<IActionResult> Details()
        ////{

        ////}
    }
}
