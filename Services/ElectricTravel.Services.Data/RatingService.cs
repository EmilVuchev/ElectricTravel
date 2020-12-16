namespace ElectricTravel.Services.Data
{
    using System.Linq;
    using System.Threading.Tasks;

    using ElectricTravel.Data.Common.Repositories;
    using ElectricTravel.Data.Models.User;
    using ElectricTravel.Services.Data.Contracts;

    public class RatingService : IRatingService
    {
        private readonly IDeletableEntityRepository<TypeTravel> userRatingRepository;

        public RatingService(IDeletableEntityRepository<TypeTravel> userRatingRepository)
        {
            this.userRatingRepository = userRatingRepository;
        }

        public double GetAverageRating(string userId)
        {
            var rate = this.userRatingRepository.All()
                .Where(x => x.UserId == userId)
                .Average(x => x.Value);
            return rate;
        }

        public async Task SetRateAsync(string userId, string assessorId, double value)
        {
            var userRate = this.userRatingRepository.All().FirstOrDefault(x => x.AssessorId == assessorId && x.UserId == userId);

            if (userRate == null)
            {
                userRate = new TypeTravel
                {
                    AssessorId = assessorId,
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
