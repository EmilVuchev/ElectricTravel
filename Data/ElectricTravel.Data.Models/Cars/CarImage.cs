namespace ElectricTravel.Data.Models.Cars
{
    using System.ComponentModel.DataAnnotations.Schema;

    using ElectricTravel.Data.Models.Images;

    public class CarImage
    {
        public string CarId { get; set; }

        public virtual Car Car { get; set; }

        [ForeignKey(nameof(Image))]
        public string ImageId { get; set; }

        public virtual Image Image { get; set; }
    }
}
