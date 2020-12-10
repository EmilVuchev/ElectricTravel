namespace ElectricTravel.Web.Controllers
{
    using System.Threading.Tasks;

    using ElectricTravel.Services.Data.Contracts;
    using Microsoft.AspNetCore.Mvc;

    public class ImagesController : Controller
    {
        private readonly IImagesService imagesService;

        public ImagesController(IImagesService imagesService)
        {
            this.imagesService = imagesService;
        }

        public async Task<IActionResult> DeleteUserPicture(string id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            this.TempData["Message"] = await this.Delete(id);

            return this.Redirect("/Galleries/Index");
        }

        public async Task<IActionResult> DeleteCarPicture(string id, int carId)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            this.TempData["Message"] = await this.Delete(id);

            return this.Redirect($"/ElectricCars/Details/{carId}");
        }

        private async Task<string> Delete(string imageId)
        {
            var isDeleted = await this.imagesService.DeleteAsync(imageId);
            var message = string.Empty;

            if (isDeleted)
            {
                message = "Successfully deleted";
            }
            else
            {
                message = "Ooops....Sorry i can not delete that.";
            }

            return message;
        }
    }
}
