namespace ElectricTravel.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IArticlesService
    {
        public Task<IEnumerable<T>> GetAllArticles<T>();

        Task<T> GetArticleById<T>(int? id);
    }
}
