namespace ElectricTravel.Web.Controllers
{
    using System.Diagnostics;

    using ElectricTravel.Services.Data.Contracts;
    using ElectricTravel.Web.ViewModels;

    using Microsoft.AspNetCore.Mvc;

    public class HomeController : BaseController
    {
        private readonly ISharedTravelsService sharedTravelsService;

        public HomeController(ISharedTravelsService sharedTravelsService)
        {
            this.sharedTravelsService = sharedTravelsService;
        }

        public IActionResult Index()
        {
            // var adverts = this.sharedTravelsService.GetRecentlyAddedAsync(5);
            return this.View();
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
