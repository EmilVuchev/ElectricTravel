namespace ElectricTravel.Data.Models.Car
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    using ElectricTravel.Data.Common.Models;

    public class CarTypeMake : IDeletableEntity
    {
        [ForeignKey(nameof(Make))]
        public int MakeId { get; set; }

        public virtual Make Make { get; set; }

        [ForeignKey(nameof(CarType))]
        public int CarTypeId { get; set; }

        public virtual CarType CarType { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
