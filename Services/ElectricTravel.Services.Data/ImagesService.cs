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
    using ElectricTravel.Web.InputViewModels.Images;
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

        public async Task<bool> DeleteAsync(string imageId)
        {
            var image = this.imageRepository.All()
                .FirstOrDefault(x => x.Id == imageId);

            this.imageRepository.Delete(image);

            var countChanges = await this.imageRepository.SaveChangesAsync();

            if (countChanges == 0)
            {
                return false;
            }

            return true;
        }

        public async Task<int> GetImageTypeId(string userImageType)
        {
            return await this.imageTypeRepository
           .AllAsNoTracking()
           .Where(x => x.Name == userImageType)
           .Select(x => x.Id)
           .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<T>> GetProfileImagesByUserId<T>(string userId)
        {
            return await this.imageRepository.AllAsNoTracking()
                 .Where(x => x.UserId == userId && x.Type.Name == GlobalConstants.UserImageType)
                .To<T>()
                .ToListAsync();
        }

        public async Task<string> GetSingleProfileImagePathByUserId(string userId)
        {
            var imagePath = await this.imageRepository.AllAsNoTracking()
                .Where(x => x.UserId == userId && x.Type.Name == GlobalConstants.UserImageType)
                .Select(x => x.Path)
                .FirstOrDefaultAsync();

            return imagePath;
        }

        public async Task UploadImages(ImageUploadViewModel imageUploadModel)
        {
            Directory.CreateDirectory($"{imageUploadModel.Path}/userImages/");
            Directory.CreateDirectory($"{imageUploadModel.Path}/carImages/");

            var imageTypeId = await this.GetImageTypeId(imageUploadModel.ImageTypeName);

            foreach (var imageFile in imageUploadModel.Images)
            {
                var extension = Path.GetExtension(imageFile.FileName).TrimStart('.');

                if (!this.allowedExtensions.Any(x => extension.EndsWith(x)))
                {
                    throw new Exception($"Invalid image extension {extension}");
                }

                var imageName = Guid.NewGuid().ToString();

                var physicalPath = string.Empty;
                var relativePath = string.Empty;
                int? carId = imageUploadModel.CarId;

                if (imageUploadModel.ImageTypeName == GlobalConstants.CarExternalImage)
                {
                    physicalPath = $"{imageUploadModel.Path}/carImages/{imageName}.{extension}";
                    relativePath = $"../../img/carImages/{imageName}.{extension}";
                }
                else if (imageUploadModel.ImageTypeName == GlobalConstants.UserImageType)
                {
                    physicalPath = $"{imageUploadModel.Path}/userImages/{imageName}.{extension}";
                    relativePath = $"../../img/userImages/{imageName}.{extension}";
                }

                var dbImage = new ElectricTravel.Data.Models.Multimedia.Image
                {
                    ElectricCarId = carId,
                    UserId = imageUploadModel.UserId,
                    Extension = extension,
                    Name = imageName,
                    Path = relativePath,
                    TypeId = imageTypeId,
                };

                await this.imageRepository.AddAsync(dbImage);
                await this.imageRepository.SaveChangesAsync();

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
        }
    }
}
