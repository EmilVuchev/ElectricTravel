namespace ElectricTravel.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using ElectricTravel.Data.Models.User;
    using ElectricTravel.Web.ViewModels.SharedTravels;
    using Microsoft.AspNetCore.Http;

    public interface IUsersService
    {
        ////Task<ImageViewModel> GetUserPictureByAdvertId(string id);
        Task<DriverInfoViewModel> GetDriverInfo(string id);

        Task UpdateUser(ElectricTravelUser user);

        Task UploadImages(string userId, IEnumerable<IFormFile> images, string imagePath);
    }
}
