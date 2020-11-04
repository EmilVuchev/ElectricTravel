namespace ElectricTravel.Data.Models.User
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    using ElectricTravel.Data.Common.Models;
    using ElectricTravel.Data.Models.Car;

    public class UserCar : IDeletableEntity
    {
        [ForeignKey(nameof(User))]
        public string UserId { get; set; }

        public virtual ElectricTravelUser User { get; set; }

        [ForeignKey(nameof(Car))]
        public int CarId { get; set; }

        public virtual ElectricCar Car { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
