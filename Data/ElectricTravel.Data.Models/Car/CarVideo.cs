namespace ElectricTravel.Data.Models.Car
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    using ElectricTravel.Data.Common.Models;
    using ElectricTravel.Data.Models.Multimedia;

    public class CarVideo : IDeletableEntity
    {
        [ForeignKey(nameof(Car))]
        public int CarId { get; set; }

        public virtual ElectricCar Car { get; set; }

        [ForeignKey(nameof(Video))]
        public int VideoId { get; set; }

        public virtual Video Video { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
