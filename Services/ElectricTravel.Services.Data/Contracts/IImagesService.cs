namespace ElectricTravel.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using ElectricTravel.Web.ViewModels.Images;
    using Microsoft.AspNetCore.Http;

    public interface IImagesService
    {
        Task UploadImages(string userId, IEnumerable<IFormFile> images, string imagePath);

        Task<IEnumerable<ProfileImageViewModel>> GetProfileImagesByUserId(string userId);

        Task DeleteAsync(string id);
    }
}
