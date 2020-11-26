namespace ElectricTravel.Data.Models.Multimedia
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using ElectricTravel.Data.Common.Models;
    using ElectricTravel.Data.Models.User;

    public class Image : BaseDeletableModel<string>
    {
        public Image()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public string Extension { get; set; }

        [Required]
        public string Path { get; set; }

        [MaxLength(100)]
        public string Description { get; set; }

        [ForeignKey(nameof(Type))]
        public int TypeId { get; set; }

        public virtual ImageType Type { get; set; }

        [ForeignKey(nameof(User))]
        public string UserId { get; set; }

        public virtual ElectricTravelUser User { get; set; }
    }
}
