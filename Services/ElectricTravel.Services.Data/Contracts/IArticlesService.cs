namespace ElectricTravel.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using ElectricTravel.Web.InputViewModels.News;

    public interface IArticlesService
    {
        public Task<IEnumerable<T>> GetAllArticles<T>();

        Task<T> GetArticleById<T>(int? id);

        Task<bool> CreateAsync(ArticleInputViewModel article);

        Task DeleteAsync(int? id, string userId);
    }
}
