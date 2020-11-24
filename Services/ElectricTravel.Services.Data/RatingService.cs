namespace ElectricTravel.Services.Data
{
    using System.Linq;
    using System.Threading.Tasks;
    using ElectricTravel.Data.Common.Repositories;
    using ElectricTravel.Data.Models.User;
    using ElectricTravel.Services.Data.Contracts;

    public class RatingService : IRatingService
    {
        private readonly IDeletableEntityRepository<ElectricTravelUser> userRepository;
        private readonly IDeletableEntityRepository<UserRating> userRatingRepository;

        public RatingService(IDeletableEntityRepository<UserRating> userRatingRepository)
        {
            this.userRatingRepository = userRatingRepository;
        }

        public double GetAverageRating(string userId)
        {
            var rate = this.userRatingRepository.All().Where(x => x.UserId == userId).Average(x => x.Value);
            return rate;
        }

        public async Task SetRateAsync(string userId, string assessorId, double value)
        {
            var userRate = this.userRatingRepository.All().FirstOrDefault(x => x.UserId == assessorId);

            if (userRate == null)
            {
                userRate = new UserRating
                {
                    UserId = userId,
                    Value = value,
                };

                await this.userRatingRepository.AddAsync(userRate);
            }

            userRate.Value = value;

            await this.userRatingRepository.SaveChangesAsync();
        }
    }
}
