namespace ElectricTravel.Web.ViewModels.Articles
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using ElectricTravel.Data.Models.News;
    using ElectricTravel.Services.Mapping;

    public class ArticleViewModel : IMapFrom<Article>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        [Display(Name = "Short Description")]
        public string ShortDescription { get; set; }

        [Display(Name = "Created By")]
        public string CreatedByUserName { get; set; }

        [Display(Name = "Created On")]
        public DateTime CreatedOn { get; set; }
    }
}
