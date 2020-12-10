namespace ElectricTravel.Services.Data
{
    using System.Linq;
    using System.Threading.Tasks;

    using ElectricTravel.Data.Common.Repositories;
    using ElectricTravel.Data.Models.Advertisement;
    using ElectricTravel.Data.Models.Multimedia;
    using ElectricTravel.Data.Models.User;
    using ElectricTravel.Services.Data.Contracts;
    using ElectricTravel.Services.Mapping;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;

    public class UsersService : IUsersService
    {
        private readonly string[] allowedExtensions = new[] { "jpg", "png", "gif", "jpeg" };
        private readonly IDeletableEntityRepository<ElectricTravelUser> userRepository;
        private readonly IDeletableEntityRepository<SharedTravelAdvert> sharedTravelRepository;
        private readonly IDeletableEntityRepository<ImageType> imageTypeRepository;
        private readonly UserManager<ElectricTravelUser> userManager;

        ////private string userPicture = "User Picture";

        public UsersService(
            IDeletableEntityRepository<ElectricTravelUser> userRepository,
            IDeletableEntityRepository<SharedTravelAdvert> sharedTravelRepository,
            IDeletableEntityRepository<ImageType> imageTypeRepository,
            UserManager<ElectricTravelUser> userManager)
        {
            this.userRepository = userRepository;
            this.sharedTravelRepository = sharedTravelRepository;
            this.imageTypeRepository = imageTypeRepository;
            this.userManager = userManager;
        }

        ////public async Task<ImageViewModel> GetUserPictureByAdvertId(string id)
        ////{
        ////    var advert = await this.sharedTravelRepository.GetByIdWithDeletedAsync(id);
        ////    var user = await this.userRepository.GetByIdWithDeletedAsync(advert.CreatedById);
        ////    var image = new ImageViewModel();

        ////    if (user.Image == null)
        ////    {
        ////        return null;
        ////        ////throw new NullReferenceException("TODOText");
        ////    }

        ////    var userImageType = user.Image.Type.Name;

        ////    if (userImageType == GlobalConstants.UserImageType)
        ////    {
        ////        image.Description = user.Image.Description;
        ////        image.Extension = user.Image.Extension;
        ////        image.Name = user.Image.Name;
        ////        image.Path = user.Image.Path;
        ////    }

        ////    return image;
        ////}

        public async Task<T> GetDriverInfo<T>(string id)
        {
            var driver = await this.userRepository
                 .AllAsNoTracking()
                 .Where(x => x.Id == id)
                 .To<T>()
                 .FirstOrDefaultAsync();

            return driver;
        }

        public async Task UpdateUser(ElectricTravelUser user)
        {
            this.userRepository.Update(user);
            await this.userRepository.SaveChangesAsync();
        }
    }
}
