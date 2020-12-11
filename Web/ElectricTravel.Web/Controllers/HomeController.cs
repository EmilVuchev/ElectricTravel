namespace ElectricTravel.Web.Controllers
{
    using System.Diagnostics;
    using System.Threading.Tasks;

    using ElectricTravel.Services.Data.Contracts;
    using ElectricTravel.Web.ViewModels;
    using ElectricTravel.Web.ViewModels.Home;
    using Microsoft.AspNetCore.Mvc;

    public class HomeController : BaseController
    {
        private readonly ISharedTravelsService sharedTravelsService;

        public HomeController(ISharedTravelsService sharedTravelsService)
        {
            this.sharedTravelsService = sharedTravelsService;
        }

        public async Task<IActionResult> Index()
        {
            var adverts = await this.sharedTravelsService.GetRecentlyAddedAsync(5);

            var model = new SharedTravelHomeListingViewModel
            {
                SharedTravels = adverts,
            };

            return this.View(model);
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
