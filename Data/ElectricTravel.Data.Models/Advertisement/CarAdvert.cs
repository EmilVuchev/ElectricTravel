namespace ElectricTravel.Data.Models.Advertisement
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using ElectricTravel.Data.Common.Models;
    using ElectricTravel.Data.Models.Location;
    using ElectricTravel.Data.Models.User;

    public class CarAdvert : BaseDeletableModel<string>
    {
        [Required]
        [MaxLength(50)]
        public string Title { get; set; }

        public double Price { get; set; }

        [MaxLength(3500)]
        public string Description { get; set; }

        [ForeignKey(nameof(City))]
        public int CityId { get; set; }

        public City City { get; set; }

        [ForeignKey(nameof(Currency))]
        public int CurrencyId { get; set; }

        public virtual Currency Currency { get; set; }

        [ForeignKey(nameof(Status))]
        public int StatusId { get; set; }

        public virtual CarAdvertStatus Status { get; set; }

        [Required]
        [ForeignKey(nameof(CreatedBy))]
        public string CreatedById { get; set; }

        public virtual ElectricTravelUser CreatedBy { get; set; }

        [ForeignKey(nameof(LikedBy))]
        public string LikedById { get; set; }

        public virtual ElectricTravelUser LikedBy { get; set; }
    }
}
