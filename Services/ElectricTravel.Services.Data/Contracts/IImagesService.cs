namespace ElectricTravel.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using ElectricTravel.Web.InputViewModels.Images;

    public interface IImagesService
    {
        Task UploadImages(ImageUploadViewModel imageUpload);

        Task<string> GetSingleProfileImagePathByUserId(string userId);

        Task<IEnumerable<T>> GetProfileImagesByUserId<T>(string userId);

        Task<bool> DeleteAsync(string imageId);

        Task<int> GetImageTypeId(string userImageType);
    }
}
