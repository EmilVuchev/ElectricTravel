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
    using SixLabors.ImageSharp;
    using SixLabors.ImageSharp.Processing;

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

            foreach (var imageFile in images)
            {
                var extension = Path.GetExtension(imageFile.FileName).TrimStart('.');

                if (!this.allowedExtensions.Any(x => extension.EndsWith(x)))
                {
                    throw new Exception($"Invalid image extension {extension}");
                }

                var imageName = Guid.NewGuid().ToString();

                var physicalPath = $"{imagePath}/userImages/{imageName}.{extension}";

                var dbImage = new ElectricTravel.Data.Models.Multimedia.Image
                {
                    UserId = user.Id,
                    Extension = extension,
                    Name = imageName,
                    Path = $"../../img/userImages/{imageName}.{extension}",
                    Type = imageType,
                };

                user.Images.Add(dbImage);

                using var image = SixLabors.ImageSharp.Image.Load(imageFile.OpenReadStream());

                var maxWidth = 640;
                var maxHeight = 640;
                var ratio = (float)image.Width / image.Height;
                var width = maxWidth;
                var height = (int)Math.Floor(maxWidth / ratio);

                if (height > maxHeight)
                {
                    height = maxHeight;
                    width = (int)Math.Floor(maxHeight * ratio);
                }

                image.Mutate(x => x.Resize(width, height));
                image.Save(physicalPath);
            }

            this.userRepository.Update(user);
            await this.userRepository.SaveChangesAsync();
        }
    }
}
