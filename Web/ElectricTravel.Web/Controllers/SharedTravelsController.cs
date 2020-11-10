namespace ElectricTravel.Web.Controllers
{
    using System.Threading.Tasks;

    using ElectricTravel.Services.Data.Contracts;
    using ElectricTravel.Web.InputViewModels.SharedTravel;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class SharedTravelsController : Controller
    {
        private readonly ISharedTravelsService sharedTravelsService;

        public SharedTravelsController(ISharedTravelsService sharedTravelsService)
        {
            this.sharedTravelsService = sharedTravelsService;
        }

        [Authorize]
        public async Task<IActionResult> CreateAsync(SharedTravelCreateInputViewModel input)
        {
            var advertDetails = await this.sharedTravelsService.CreateAsync(input);
            return this.View(advertDetails);
        }
    }
}
