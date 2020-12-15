namespace ElectricTravel.Services.Data.Tests
{
    using ElectricTravel.Data.Common.Repositories;
    using ElectricTravel.Data.Models.News;
    using Moq;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Xunit;

    public class ArticlesServiceTest
    {
        ////public void GetCountShouldReturnCorrectNumber()
        ////{
        ////    var repository = new Mock<IDeletableEntityRepository<Setting>>();
        ////    repository.Setup(r => r.All()).Returns(new List<Setting>
        ////                                                {
        ////                                                    new Setting(),
        ////                                                    new Setting(),
        ////                                                    new Setting(),
        ////                                                }.AsQueryable());
        ////    var service = new SettingsService(repository.Object);
        ////    Assert.Equal(3, service.GetCount());
        ////    repository.Verify(x => x.All(), Times.Once);
        ////}

        //[Fact]
        //public void CheckIfCreateAsyncCreatesArticle()
        //{
        //     var article = new Article()
        //    {
        //        ShortDescription = "DDDDDSASDSASD",
        //        Content = "DDDDDSASDSASD",
        //        CreatedById = "asdasd",
        //        Title = "DDDDDASDASDS",
        //    };

        //    var repo = new Mock<IDeletableEntityRepository<Article>>();
        //    await repo.Setup(r => r.AddAsync(article)).Returns(new List<Article>().AsQueryable());

        //    var service = new ArticlesService(repo.Object);
        //}
    }
}
