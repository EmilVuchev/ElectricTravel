namespace ElectricTravel.Web.ViewModels.Articles
{
    using System.ComponentModel.DataAnnotations;

    using ElectricTravel.Data.Models.News;
    using ElectricTravel.Services.Mapping;

    public class DetailArticleVIewModel : IMapFrom<Article>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        [Display(Name = "Created By")]
        public string CreatedByUserName { get; set; }

        public string CreatedById { get; set; }
    }
}
