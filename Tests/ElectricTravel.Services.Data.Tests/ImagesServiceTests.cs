namespace ElectricTravel.Services.Data.Tests
{
    using System.Linq;
    using System.Reflection;
    using System.Threading.Tasks;

    using ElectricTravel.Data;
    using ElectricTravel.Data.Models.Multimedia;
    using ElectricTravel.Data.Repositories;
    using ElectricTravel.Services.Data.Contracts;
    using ElectricTravel.Services.Mapping;
    using ElectricTravel.Web.ViewModels.Images;
    using Microsoft.EntityFrameworkCore;
    using Xunit;

    public class ImagesServiceTests
    {
        private readonly ElectricTravelDbContext dbContext;
        private readonly EfDeletableEntityRepository<Image> imageRepo;
        private readonly EfDeletableEntityRepository<ImageType> imageTypeRepo;
        private readonly IImagesService imagesService;

        public ImagesServiceTests()
        {
            this.InitializeMapper();
            this.dbContext = InitializeDbContext();

            InitializeRepositories(this.dbContext, out this.imageRepo, out this.imageTypeRepo);

            this.imagesService = InitializeService(this.imageRepo, this.imageTypeRepo);
        }

        [Fact]
        public async Task ChecksIfThereIsSomethingInTheDbWithParticularId()
        {
            var imageToAdd = await SeedDb(this.imageRepo);

            var image = this.imageRepo.All().FirstOrDefault(x => x.Id == imageToAdd.Id);

            Assert.NotNull(image);
        }

        [Fact]
        public async Task ChecksIfDeleteAsyncReturnsFalseIfThereIsNothingToDelete()
        {
            var imageId = "Muppets";

            var isDeleted = await this.imagesService.DeleteAsync(imageId);

            Assert.False(isDeleted);
        }

        [Fact]
        public async Task ChecksIfDeleteAsyncReturnsTrueIfImageIsDeleted()
        {
            var imageToAdd = await SeedDb(this.imageRepo);
            var imageId = imageToAdd.Id;

            var isDeleted = await this.imagesService.DeleteAsync(imageId);

            Assert.True(isDeleted);
        }

        [Fact]
        public async Task GetImageTypeIdShouldReturnCorrectId()
        {
            var name = "Profile picture";

            var imageTypeToAdd = new ImageType
            {
                Name = name,
            };

            var actualResult = await this.imagesService.GetImageTypeId(name);
            var expectedResult = imageTypeToAdd.Id;

            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public async Task GetProfileImagesByUserIdShouldReturnCorrectResult()
        {
            var imageToAdd = await SeedDb(this.imageRepo);
            var userId = imageToAdd.UserId;
            var imageName = imageToAdd.Name;

            var images = await this.imageRepo.AllAsNoTracking()
                     .Where(x => x.UserId == userId)
                    .To<ProfileImageViewModel>()
                    .ToListAsync();

            Assert.Collection(images, item => Assert.Contains(imageName, item.Name));
        }

        [Fact]
        public async Task GetSingleProfileImagePathByUserIdShouldReturnCorrectResult()
        {
            var imageToAdd = await SeedDb(this.imageRepo);
            var imageName = imageToAdd.Name;
            var userId = imageToAdd.UserId;
            var relativePath = imageToAdd.Path;
            var imageTypeId = imageToAdd.TypeId;

            var image = await this.imageRepo.AllAsNoTracking()
                   .Where(x => x.UserId == userId)
                   .FirstOrDefaultAsync();

            if (image.TypeId != imageTypeId)
            {
                image.Name = "Error";
            }

            Assert.Equal(relativePath, image.Path);
        }

        private static IImagesService InitializeService(EfDeletableEntityRepository<Image> imageRepo, EfDeletableEntityRepository<ImageType> imageTypeRepo)
        {
            var service = new ImagesService(imageRepo, imageTypeRepo);
            return service;
        }

        private static void InitializeRepositories(ElectricTravelDbContext dbContext, out EfDeletableEntityRepository<Image> imageRepo, out EfDeletableEntityRepository<ImageType> imageTypeRepo)
        {
            imageRepo = new EfDeletableEntityRepository<Image>(dbContext);
            imageTypeRepo = new EfDeletableEntityRepository<ImageType>(dbContext);
        }

        private static ElectricTravelDbContext InitializeDbContext()
        {
            var options = new DbContextOptionsBuilder<ElectricTravelDbContext>()
                                 .UseInMemoryDatabase(databaseName: "ImagesTestDb").Options;
            var dbContext = new ElectricTravelDbContext(options);
            return dbContext;
        }

        private static async Task<Image> SeedDb(EfDeletableEntityRepository<Image> imageRepo)
        {
            var carId = 1;
            var userId = "qwerty";
            var extension = "jpg";
            var imageName = "qweasdzxc";
            var relativePath = $"../../images/{imageName}.{extension}";
            var imageTypeId = 1;

            var imageToAdd = new Image
            {
                ElectricCarId = carId,
                UserId = userId,
                Extension = extension,
                Name = imageName,
                Path = relativePath,
                TypeId = imageTypeId,
            };

            await imageRepo.AddAsync(imageToAdd);
            await imageRepo.SaveChangesAsync();
            return imageToAdd;
        }

        private void InitializeMapper() => AutoMapperConfig.
           RegisterMappings(Assembly.Load("ElectricTravel.Web.ViewModels"));
    }
}
