﻿namespace ElectricTravel.Data.Models.News
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using ElectricTravel.Data.Common.Models;
    using ElectricTravel.Data.Models.User;

    public class Article : BaseModel<int>
    {
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required]
        [MaxLength(5000)]
        public string Content { get; set; }

        [Required]
        public string Path { get; set; }

        [ForeignKey(nameof(Source))]
        public int SourceId { get; set; }

        public virtual Source Source { get; set; }

        [Required]
        [ForeignKey(nameof(User))]
        public string UserId { get; set; }

        public virtual ElectricTravelUser User { get; set; }
    }
}
