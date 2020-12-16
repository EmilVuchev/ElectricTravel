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
        private readonly IDeletableEntityRepository<ElectricTravelUser> userRepository;
        private readonly IDeletableEntityRepository<SharedTravelAdvert> sharedTravelRepository;
        private readonly IDeletableEntityRepository<ImageType> imageTypeRepository;
        private readonly UserManager<ElectricTravelUser> userManager;

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

        public async Task<T> GetDriverInfo<T>(string id)
        {
            var driver = await this.userRepository
                 .AllAsNoTracking()
                 .Where(x => x.Id == id)
                 .To<T>()
                 .FirstOrDefaultAsync();

            return driver;
        }

        public async Task<ElectricTravelUser> GetUserByUserName(string username)
        {
           return await this.userRepository.All()
                .Where(x => x.UserName == username)
                .FirstOrDefaultAsync();
        }

        public async Task UpdateUser(ElectricTravelUser user)
        {
            this.userRepository.Update(user);
            await this.userRepository.SaveChangesAsync();
        }
    }
}
