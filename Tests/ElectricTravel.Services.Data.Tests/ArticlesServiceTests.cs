namespace ElectricTravel.Services.Data.Tests
{
    using System.Linq;
    using System.Reflection;
    using System.Threading.Tasks;

    using ElectricTravel.Data;
    using ElectricTravel.Data.Models.News;
    using ElectricTravel.Data.Models.User;
    using ElectricTravel.Data.Repositories;
    using ElectricTravel.Services.Mapping;
    using ElectricTravel.Web.InputViewModels.News;
    using ElectricTravel.Web.ViewModels.Articles;
    using Microsoft.EntityFrameworkCore;
    using Xunit;

    public class ArticlesServiceTests
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

        public ArticlesServiceTests()
        {
            this.InitializeMapper();
        }

        ///var options = new DbContextOptionsBuilder<ElectricTravelDbContext>()
        ////    .UseInMemoryDatabase(databaseName: "SettingsTestDb").Options;
        ////using var dbContext = new ElectricTravelDbContext(options);
        ////    dbContext.Settings.Add(new Setting());
        ////        dbContext.Settings.Add(new Setting());
        ////        dbContext.Settings.Add(new Setting());
        ////        await dbContext.SaveChangesAsync();

        ////        using var repository = new EfDeletableEntityRepository<Setting>(dbContext);
        ////        var service = new SettingsService(repository);
        ////Assert.Equal(3, service.GetCount());

        [Fact]
        public async Task CheckIfCreateAsyncCreatesArticle()
        {
            var options = new DbContextOptionsBuilder<ElectricTravelDbContext>()
                             .UseInMemoryDatabase(databaseName: "ArticlesTestDb").Options;
            using var dbContext = new ElectricTravelDbContext(options);

            using var repo = new EfDeletableEntityRepository<Article>(dbContext);
            var service = new ArticlesService(repo);

            var article = new ArticleInputViewModel()
            {
                ShortDescription = "DDDDDSASDSASD",
                Content = "DDDDDSASDSASD",
                UserId = "goshoasd",
                Title = "DDDDDASDASDS",
            };

            var isCreated = await service.CreateAsync(article);

            Assert.True(isCreated);
        }

        [Fact]
        public async Task CheckIfCreateAsyncReturnsFalseIfCannotCreateArticle()
        {
            var options = new DbContextOptionsBuilder<ElectricTravelDbContext>()
                                 .UseInMemoryDatabase(databaseName: "ArticlesTestDb").Options;
            using var dbContext = new ElectricTravelDbContext(options);

            using var repo = new EfDeletableEntityRepository<Article>(dbContext);
            var service = new ArticlesService(repo);

            var article = new ArticleInputViewModel();
            article = null;

            var isCreated = await service.CreateAsync(article);

            Assert.True(!isCreated);
        }

        [Fact]
        public async Task CkeckIfDeleteAsyncFindsArticleObjectInDB()
        {
            var options = new DbContextOptionsBuilder<ElectricTravelDbContext>()
                                         .UseInMemoryDatabase(databaseName: "ArticlesTestDb").Options;
            using var dbContext = new ElectricTravelDbContext(options);

            dbContext.Articles.Add(new Article
            {
                ShortDescription = "asdasdasd",
                Content = "asdasdadasd",
                CreatedById = "stefkaasd",
                Title = "asdasasd",
            });

            dbContext.SaveChanges();

            using var repo = new EfDeletableEntityRepository<Article>(dbContext);
            var service = new ArticlesService(repo);

            var id = 2;
            var userId = "stefkaasd";

            var article = await dbContext.Articles
                .FirstOrDefaultAsync(x => x.Id == id && x.CreatedById == userId);

            Assert.NotNull(article);
        }

        [Fact]
        public async Task CheckIfDeleteAsyncDeletesData()
        {
            var options = new DbContextOptionsBuilder<ElectricTravelDbContext>()
                                     .UseInMemoryDatabase(databaseName: "ArticlesTestDb").Options;
            using var dbContext = new ElectricTravelDbContext(options);

            dbContext.Articles.Add(new Article
            {
                ShortDescription = "asdasd",
                Content = "asdasdad",
                CreatedById = "goshoasd",
                Title = "asdas",
            });

            dbContext.SaveChanges();

            using var repo = new EfDeletableEntityRepository<Article>(dbContext);
            var service = new ArticlesService(repo);

            var id = 1;
            var userId = "goshoasd";

            await service.DeleteAsync(id, userId);
            var article = await dbContext.Articles
                .FirstOrDefaultAsync(x => x.Id == id && x.CreatedById == userId);

            Assert.Null(article);
        }

        [Fact]
        public async Task ChecksIfGetAllArticlesReturnsCorrectCount()
        {
            var options = new DbContextOptionsBuilder<ElectricTravelDbContext>()
                                         .UseInMemoryDatabase(databaseName: "ArticlesTestDb").Options;
            using var dbContext = new ElectricTravelDbContext(options);

            var user = new ElectricTravelUser
            {
                Email = "emo@abv.bg",
                UserName = "username",
            };

            var article = new Article
            {
                ShortDescription = "asdffggasdasd",
                Content = "asdasdjnjad",
                CreatedBy = user,
                Title = "asdgggghasjkljkj",
            };

            dbContext.Users.Add(user);
            dbContext.Articles.Add(article);

            dbContext.SaveChanges();

            using var repo = new EfDeletableEntityRepository<Article>(dbContext);
            var service = new ArticlesService(repo);

            var articasdasle = await dbContext.Articles
                .FirstOrDefaultAsync(x => x.CreatedById == "goshkadsa");

            var articles = await service.GetAllArticles<ArticleViewModel>();
            var expectedResult = 2;
            var actualResult = articles.Count();

            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public async Task ChecksIfGetArticleByIdReturnsCorrectResult()
        {
            var options = new DbContextOptionsBuilder<ElectricTravelDbContext>()
                                         .UseInMemoryDatabase(databaseName: "ArticlesTestDb").Options;
            using var dbContext = new ElectricTravelDbContext(options);

            var user = new ElectricTravelUser
            {
                UserName = "samosval",
            };

            var articleToAdd = new Article
            {
                ShortDescription = "asdasd",
                Content = "asdasdad",
                CreatedBy = user,
                Title = "asdas",
            };

            dbContext.Users.Add(user);
            dbContext.Articles.Add(articleToAdd);
            dbContext.SaveChanges();

            using var repo = new EfDeletableEntityRepository<Article>(dbContext);
            var service = new ArticlesService(repo);

            var article = await service.GetArticleById<ArticleViewModel>(articleToAdd.Id);

            Assert.NotNull(article);
        }

        private void InitializeMapper() => AutoMapperConfig.
            RegisterMappings(Assembly.Load("ElectricTravel.Web.ViewModels"));
    }
}
