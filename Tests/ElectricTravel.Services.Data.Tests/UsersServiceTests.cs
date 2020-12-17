namespace ElectricTravel.Services.Data.Tests
{
    using System.Reflection;
    using System.Threading.Tasks;

    using ElectricTravel.Data;
    using ElectricTravel.Data.Models.Advertisement;
    using ElectricTravel.Data.Models.Multimedia;
    using ElectricTravel.Data.Models.User;
    using ElectricTravel.Data.Repositories;
    using ElectricTravel.Services.Mapping;
    using ElectricTravel.Web.ViewModels.SharedTravels;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using Xunit;

    public class UsersServiceTests
    {
        public UsersServiceTests()
        {
            this.InitializeMapper();
        }

        [Fact]
        public async Task ChecksIfGetDriverInfoFindsDriverById()
        {
            var options = new DbContextOptionsBuilder<ElectricTravelDbContext>()
                             .UseInMemoryDatabase(databaseName: "DriversTestDb").Options;
            using var dbContext = new ElectricTravelDbContext(options);

            UserStore<ElectricTravelUser> userStore = new UserStore<ElectricTravelUser>(dbContext, null);
            UserManager<ElectricTravelUser> userManager =
                new UserManager<ElectricTravelUser>(userStore, null, null, null, null, null, null, null, null);

            using var userRepo = new EfDeletableEntityRepository<ElectricTravelUser>(dbContext);
            using var travelRepo = new EfDeletableEntityRepository<SharedTravelAdvert>(dbContext);
            using var imageTypeRepo = new EfDeletableEntityRepository<ImageType>(dbContext);
            var service = new UsersService(userRepo, travelRepo, imageTypeRepo, userManager);

            var user = new ElectricTravelUser
            {
                Email = "Elmo@abv.bg",
                UserName = "Elmo",
                FirstName = "Elmo",
                LastName = "Elmos",
            };

            await userRepo.AddAsync(user);
            await userRepo.SaveChangesAsync();

            var result = service.GetDriverInfo<DriverInfoViewModel>(user.Id);

            Assert.NotNull(result);
        }

        [Fact]
        public async Task CheckIfGetUserByUserNameFindsUser()
        {
            var options = new DbContextOptionsBuilder<ElectricTravelDbContext>()
                                .UseInMemoryDatabase(databaseName: "DriversTestDb").Options;
            using var dbContext = new ElectricTravelDbContext(options);

            UserStore<ElectricTravelUser> userStore = new UserStore<ElectricTravelUser>(dbContext, null);
            UserManager<ElectricTravelUser> userManager =
                new UserManager<ElectricTravelUser>(userStore, null, null, null, null, null, null, null, null);

            using var userRepo = new EfDeletableEntityRepository<ElectricTravelUser>(dbContext);
            using var travelRepo = new EfDeletableEntityRepository<SharedTravelAdvert>(dbContext);
            using var imageTypeRepo = new EfDeletableEntityRepository<ImageType>(dbContext);
            var service = new UsersService(userRepo, travelRepo, imageTypeRepo, userManager);

            var userName = "Piggy";
            var email = "MissPiggy@abv.bg";

            var user = new ElectricTravelUser
            {
                Email = email,
                UserName = userName,
            };

            await userRepo.AddAsync(user);
            await userRepo.SaveChangesAsync();

            var result = await service.GetUserByUserName(userName);

            Assert.NotNull(result);
        }

        private void InitializeMapper() => AutoMapperConfig.
            RegisterMappings(Assembly.Load("ElectricTravel.Web.ViewModels"));
    }
}
