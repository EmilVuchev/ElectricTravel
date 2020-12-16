namespace ElectricTravel.Services.Data.Tests
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using ElectricTravel.Data.Common.Repositories;
    using ElectricTravel.Data.Models.User;
    using Moq;
    using Xunit;

    public class RatingServiceTests
    {
        [Fact]
        public async Task CheckIfGetAverageRatingReturnsCorrectData()
        {
            var list = new List<TypeTravel>();

            var mockRepo = new Mock<IDeletableEntityRepository<TypeTravel>>();
            mockRepo.Setup(x => x.All()).Returns(list.AsQueryable());
            mockRepo.Setup(x => x.AddAsync(It.IsAny<TypeTravel>())).Callback(
                (TypeTravel rate) => list.Add(rate));

            var service = new RatingService(mockRepo.Object);

            await service.SetRateAsync("Gosho", "Pesho", 1);
            await service.SetRateAsync("Gosho", "Spas", 5);

            var expectedResult = 3;
            var averageRating = service.GetAverageRating("Gosho");

            Assert.Equal(expectedResult, averageRating);
        }

        [Fact]
        public async Task CheckIfUserRatesDriverTwoTimesThenShouldReturnOnlyOneRateValue()
        {
            var list = new List<TypeTravel>();

            var mockRepo = new Mock<IDeletableEntityRepository<TypeTravel>>();
            mockRepo.Setup(x => x.All()).Returns(list.AsQueryable());
            mockRepo.Setup(x => x.AddAsync(It.IsAny<TypeTravel>())).Callback(
                (TypeTravel rate) => list.Add(rate));

            var service = new RatingService(mockRepo.Object);

            await service.SetRateAsync("Gosho", "Pesho", 1);
            await service.SetRateAsync("Gosho", "Pesho", 5);
            await service.SetRateAsync("Gosho", "Pesho", 5);
            await service.SetRateAsync("Gosho", "Pesho", 5);
            await service.SetRateAsync("Gosho", "Pesho", 5);

            Assert.Single(list);
            Assert.Equal(5, list.First().Value);
        }

        [Fact]
        public async Task CheckIf2UsersVoteForTheSameDriverThenTheAverageRatingShouldBeCorrect()
        {
            var rates = new List<TypeTravel>();

            var mockRepo = new Mock<IDeletableEntityRepository<TypeTravel>>();
            mockRepo.Setup(x => x.All()).Returns(rates.AsQueryable());
            mockRepo.Setup(x => x.AddAsync(It.IsAny<TypeTravel>())).Callback(
                (TypeTravel rate) => rates.Add(rate));

            var service = new RatingService(mockRepo.Object);

            await service.SetRateAsync("Gosho", "Asd", 5);
            await service.SetRateAsync("Gosho", "Samuil", 1);
            await service.SetRateAsync("Gosho", "Asd", 2);

            mockRepo.Verify(x => x.AddAsync(It.IsAny<TypeTravel>()), Times.Exactly(2));

            Assert.Equal(2, rates.Count);
            Assert.Equal(1.5, service.GetAverageRating("Gosho"));
        }
    }
}
