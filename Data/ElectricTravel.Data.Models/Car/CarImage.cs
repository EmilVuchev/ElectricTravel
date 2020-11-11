namespace ElectricTravel.Data.Models.Car
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    using ElectricTravel.Data.Common.Models;
    using ElectricTravel.Data.Models.Multimedia;

    public class CarImage : IDeletableEntity
    {
        [ForeignKey(nameof(Car))]
        public int CarId { get; set; }

        public virtual ElectricCar Car { get; set; }

        [ForeignKey(nameof(Image))]
        public int ImageId { get; set; }

        public virtual Image Image { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
