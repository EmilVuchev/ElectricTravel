namespace ElectricTravel.Data.Models.Advertisement
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using ElectricTravel.Data.Common.Models;
    using ElectricTravel.Data.Models.Advertisement.Enumerations;
    using ElectricTravel.Data.Models.Location;
    using ElectricTravel.Data.Models.User;

    public class CarAdvert : BaseDeletableModel<int>
    {
        [Required]
        [MaxLength(50)]
        public string Title { get; set; }

        public decimal Price { get; set; }

        public AdvertCurrency Currency { get; set; }

        [MaxLength(3500)]
        public string Description { get; set; }

        [ForeignKey(nameof(City))]
        public int CityId { get; set; }

        public virtual City City { get; set; }

        public AdvertStatus Status { get; set; }

        [Required]
        [ForeignKey(nameof(CreatedBy))]
        public string CreatedById { get; set; }

        public virtual ElectricTravelUser CreatedBy { get; set; }

        [ForeignKey(nameof(LikedBy))]
        public string LikedById { get; set; }

        public virtual ElectricTravelUser LikedBy { get; set; }
    }
}
