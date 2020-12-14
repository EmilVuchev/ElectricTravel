namespace ElectricTravel.Data.Models.News
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using ElectricTravel.Data.Common.Models;
    using ElectricTravel.Data.Models.User;

    public class Article : BaseDeletableModel<int>
    {
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        [MaxLength(300)]
        public string ShortDescription { get; set; }

        public string Path { get; set; }

        [ForeignKey(nameof(Source))]
        public int? SourceId { get; set; }

        public virtual Source Source { get; set; }

        [Required]
        [ForeignKey(nameof(CreatedBy))]
        public string CreatedById { get; set; }

        public virtual ElectricTravelUser CreatedBy { get; set; }
    }
}
