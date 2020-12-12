namespace ElectricTravel.Web.InputViewModels.News
{
    using System.ComponentModel.DataAnnotations;

    public class ArticleInputViewModel
    {
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        public string Path { get; set; }

        [Required]
        public string UserId { get; set; }
    }
}
