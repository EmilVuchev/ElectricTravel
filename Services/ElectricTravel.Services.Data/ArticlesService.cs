namespace ElectricTravel.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using ElectricTravel.Data.Common.Repositories;
    using ElectricTravel.Data.Models.News;
    using ElectricTravel.Services.Data.Contracts;
    using ElectricTravel.Services.Mapping;
    using ElectricTravel.Web.InputViewModels.News;
    using Microsoft.EntityFrameworkCore;

    public class ArticlesService : IArticlesService
    {
        private readonly IDeletableEntityRepository<Article> articleRepository;

        public ArticlesService(IDeletableEntityRepository<Article> articleRepository)
        {
            this.articleRepository = articleRepository;
        }

        public async Task<bool> CreateAsync(ArticleInputViewModel input)
        {
            if (input == null)
            {
                return false;
            }

            var article = new Article()
            {
                ShortDescription = input.ShortDescription,
                Content = input.Content,
                CreatedById = input.UserId,
                Title = input.Title,
                Path = input.Path,
            };

            await this.articleRepository.AddAsync(article);
            await this.articleRepository.SaveChangesAsync();

            return true;
        }

        public async Task DeleteAsync(int? id, string userId)
        {
            var article = await this.articleRepository.All()
                .Where(x => x.Id == id && x.CreatedById == userId)
                .FirstOrDefaultAsync();

            this.articleRepository.Delete(article);
            await this.articleRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllArticles<T>()
        {
            return await this.articleRepository.All()
                 .To<T>()
                 .ToListAsync();
        }

        public async Task<T> GetArticleById<T>(int? id)
        {
            return await this.articleRepository.All()
                .Where(x => x.Id == id)
                .To<T>()
                .FirstOrDefaultAsync();
        }

        public async Task<int> GetArticlesCount()
        {
            return await this.articleRepository.All()
                .CountAsync();
        }

        ////public async Task<IEnumerable<SharedTravelsViewModel>> GetRecentlyAddedAsync(int count = 0)
        ////{
        ////    var recentlyAdded = await this.articleRepository
        ////       .All()
        ////       .OrderByDescending(x => x.CreatedOn)
        ////       .Take(count)
        ////       .To<SharedTravelsViewModel>()
        ////       .ToListAsync();

        ////    return recentlyAdded;
        ////}
    }
}
