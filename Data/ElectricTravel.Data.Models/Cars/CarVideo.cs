namespace ElectricTravel.Data.Models.Cars
{
    using System.ComponentModel.DataAnnotations.Schema;

    using ElectricTravel.Data.Models.Videos;

    public class CarVideo
    {
        [ForeignKey(nameof(Car))]
        public string CarId { get; set; }

        public virtual Car Car { get; set; }

        [ForeignKey(nameof(Video))]
        public string VideoId { get; set; }

        public virtual Video Video { get; set; }
    }
}
