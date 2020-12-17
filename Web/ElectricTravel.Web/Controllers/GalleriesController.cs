namespace ElectricTravel.Web.Controllers
{
    using System.Threading.Tasks;

    using ElectricTravel.Data.Models.User;
    using ElectricTravel.Services.Data.Contracts;
    using ElectricTravel.Web.ViewModels.Images;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class GalleriesController : Controller
    {
        private readonly IImagesService imagesService;
        private readonly IWebHostEnvironment environment;
        private readonly UserManager<ElectricTravelUser> userManager;

        public GalleriesController(
            IImagesService imagesService,
            IWebHostEnvironment environment,
            UserManager<ElectricTravelUser> userManager)
        {
            this.imagesService = imagesService;
            this.environment = environment;
            this.userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var userId = this.userManager.GetUserId(this.User);
            var images = await this.imagesService.GetProfileImagesByUserId<ProfileImageViewModel>(userId);

            return this.View(images);
        }

        [HttpPost]
        public async Task<IActionResult> DeletePicture(string id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            await this.imagesService.DeleteAsync(id);

            return this.Redirect("/Galleries/Index");
        }
    }
}
