namespace ElectricTravel.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    using ElectricTravel.Data.Common.Repositories;
    using ElectricTravel.Data.Models.Advertisement;
    using ElectricTravel.Data.Models.Multimedia;
    using ElectricTravel.Data.Models.User;
    using ElectricTravel.Services.Data.Contracts;
    using ElectricTravel.Services.Mapping;
    using ElectricTravel.Web.ViewModels.SharedTravels;
    using Microsoft.AspNetCore.Http;
    using Microsoft.EntityFrameworkCore;

    public class UsersService : IUsersService
    {
        private readonly string[] allowedExtensions = new[] { "jpg", "png", "gif", "jpeg" };
        private readonly IDeletableEntityRepository<ElectricTravelUser> userRepository;
        private readonly IDeletableEntityRepository<SharedTravelAdvert> sharedTravelRepository;
        private readonly IDeletableEntityRepository<ImageType> imageTypeRepository;
        private string userPicture = "User Picture";

        public UsersService(
            IDeletableEntityRepository<ElectricTravelUser> userRepository,
            IDeletableEntityRepository<SharedTravelAdvert> sharedTravelRepository,
            IDeletableEntityRepository<ImageType> imageTypeRepository)
        {
            this.userRepository = userRepository;
            this.sharedTravelRepository = sharedTravelRepository;
            this.imageTypeRepository = imageTypeRepository;
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

        public async Task<DriverInfoViewModel> GetDriverInfo(string id)
        {
            var driver = await this.userRepository
                 .AllAsNoTracking()
                 .Where(x => x.Id == id)
                 .To<DriverInfoViewModel>()
                 .FirstOrDefaultAsync();

            return driver;
        }

        public async Task UpdateUser(ElectricTravelUser user)
        {
            this.userRepository.Update(user);
            await this.userRepository.SaveChangesAsync();
        }

        public async Task UploadImages(string userId, IEnumerable<IFormFile> images, string imagePath)
        {
            Directory.CreateDirectory($"{imagePath}/userImages/");

            var imageType = this.imageTypeRepository
                .AllAsNoTracking()
                .FirstOrDefault(x => x.Name == this.userPicture);

            var user = this.userRepository.All().FirstOrDefault(x => x.Id == userId);

            foreach (var image in images)
            {
                var extension = Path.GetExtension(image.FileName).TrimStart('.');

                if (!this.allowedExtensions.Any(x => extension.EndsWith(x)))
                {
                    throw new Exception($"Invalid image extension {extension}");
                }

                var imageName = Guid.NewGuid().ToString();

                var physicalPath = $"{imagePath}/userImages/{imageName}.{extension}";

                var dbImage = new Image
                {
                    UserId = user.Id,
                    Extension = extension,
                    Name = imageName,
                    Path = $"../../img/userImages/{imageName}.{extension}",
                    Type = imageType,
                };

                user.Images.Add(dbImage);

                using Stream fileStream = new FileStream(physicalPath, FileMode.Create);
                await image.CopyToAsync(fileStream);
            }

            this.userRepository.Update(user);
            await this.userRepository.SaveChangesAsync();
        }
    }
}
