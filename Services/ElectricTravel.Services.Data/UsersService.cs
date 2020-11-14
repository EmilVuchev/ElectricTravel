namespace ElectricTravel.Services.Data
{
    using System;
    using System.Threading.Tasks;

    using ElectricTravel.Common;
    using ElectricTravel.Data.Common.Repositories;
    using ElectricTravel.Data.Models.Advertisement;
    using ElectricTravel.Data.Models.User;
    using ElectricTravel.Services.Data.Contracts;
    using ElectricTravel.Web.ViewModels.Images;

    public class UsersService : IUsersService
    {
        private readonly IDeletableEntityRepository<ElectricTravelUser> userRepository;
        private readonly IDeletableEntityRepository<SharedTravelAdvert> sharedTravelRepository;

        public UsersService(IDeletableEntityRepository<ElectricTravelUser> userRepository, IDeletableEntityRepository<SharedTravelAdvert> sharedTravelRepository)
        {
            this.userRepository = userRepository;
            this.sharedTravelRepository = sharedTravelRepository;
        }

        public async Task<ImageViewModel> GetUserPictureByAdvertId(string id)
        {
            var advert = await this.sharedTravelRepository.GetByIdWithDeletedAsync(id);
            var user = await this.userRepository.GetByIdWithDeletedAsync(advert.CreatedById);
            var image = new ImageViewModel();

            if (user.Image == null)
            {
                return null;
                ////throw new NullReferenceException("TODOText");
            }

            var userImageType = user.Image.Type.Name;

            if (userImageType == GlobalConstants.UserImageType)
            {
                image.Description = user.Image.Description;
                image.Extension = user.Image.Extension;
                image.Name = user.Image.Name;
                image.Path = user.Image.Path;
            }

            return image;
        }
    }
}
