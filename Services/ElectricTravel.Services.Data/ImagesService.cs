namespace ElectricTravel.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using ElectricTravel.Common;
    using ElectricTravel.Data.Common.Repositories;
    using ElectricTravel.Data.Models.Multimedia;
    using ElectricTravel.Services.Data.Contracts;
    using ElectricTravel.Services.Mapping;
    using ElectricTravel.Web.ViewModels.Images;
    using Microsoft.AspNetCore.Http;
    using Microsoft.EntityFrameworkCore;
    using SixLabors.ImageSharp;
    using SixLabors.ImageSharp.Processing;

    public class ImagesService : IImagesService
    {
        private readonly string[] allowedExtensions = new[] { "jpg", "png", "gif", "jpeg" };
        private readonly IDeletableEntityRepository<ElectricTravel.Data.Models.Multimedia.Image> imageRepository;
        private readonly IDeletableEntityRepository<ImageType> imageTypeRepository;

        public ImagesService(
            IDeletableEntityRepository<ElectricTravel.Data.Models.Multimedia.Image> imageRepository,
            IDeletableEntityRepository<ImageType> imageTypeRepository)
        {
            this.imageRepository = imageRepository;
            this.imageTypeRepository = imageTypeRepository;
        }

        public async Task DeleteAsync(string id)
        {
            var image = this.imageRepository.All()
                .FirstOrDefault(x => x.Id == id);

            this.imageRepository.Delete(image);
            await this.imageRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<ProfileImageViewModel>> GetProfileImagesByUserId(string userId)
        {
            return await this.imageRepository.AllAsNoTracking()
                 .Where(x => x.UserId == userId && x.Type.Name == GlobalConstants.UserImageType)
                .To<ProfileImageViewModel>()
                .ToListAsync();
        }

        public async Task UploadImages(string userId, IEnumerable<IFormFile> images, string imagePath)
        {
            Directory.CreateDirectory($"{imagePath}/userImages/");

            var imageType = this.imageTypeRepository
                .AllAsNoTracking()
                .FirstOrDefault(x => x.Name == GlobalConstants.UserImageType);

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
                    UserId = userId,
                    Extension = extension,
                    Name = imageName,
                    Path = $"../../img/userImages/{imageName}.{extension}",
                    Type = imageType,
                };

                await this.imageRepository.AddAsync(dbImage);

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

            await this.imageRepository.SaveChangesAsync();
        }
    }
}
