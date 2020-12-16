namespace ElectricTravel.Web.Controllers
{
    using System.Diagnostics;
    using System.Threading.Tasks;

    using ElectricTravel.Services.Data.Contracts;
    using ElectricTravel.Web.ViewModels;
    using ElectricTravel.Web.ViewModels.Home;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Hosting;

    public class HomeController : BaseController
    {
        private readonly ISharedTravelsService sharedTravelsService;
        private readonly IWebHostEnvironment env;

        public HomeController(ISharedTravelsService sharedTravelsService, IWebHostEnvironment env)
        {
            this.sharedTravelsService = sharedTravelsService;
            this.env = env;
        }

        public async Task<IActionResult> Index()
        {
            var asd = this.env.EnvironmentName;
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
