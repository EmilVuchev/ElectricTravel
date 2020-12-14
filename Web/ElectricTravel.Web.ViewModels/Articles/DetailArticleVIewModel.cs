namespace ElectricTravel.Web.ViewModels.Articles
{
    using ElectricTravel.Data.Models.News;
    using ElectricTravel.Services.Mapping;

    public class DetailArticleVIewModel : IMapFrom<Article>
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public string CreatedByUserName { get; set; }
    }
}
