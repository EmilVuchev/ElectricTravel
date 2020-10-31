namespace ElectricTravel.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    using ElectricTravel.Data.Common.Models;
    using ElectricTravel.Data.Models.Cars;
    using ElectricTravel.Data.Models.Images;

    public class Car : IDeletableEntity
    {
        public Car()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Images = new HashSet<Image>();
        }

        public string Id { get; set; }

        public double Range { get; set; }

        public double RangeAsMiles => this.Range * 0.62;

        public string Acceleration { get; set; }

        public double TopSpeed { get; set; }

        public double TopSpeedAsMiles => this.TopSpeed * 0.62;

        public string Battery { get; set; }

        public string ElectricityConsumption { get; set; }

        public string Drive { get; set; }

        public int Year { get; set; }

        public int HorsePower { get; set; }

        public int Seats { get; set; }

        public int Doors { get; set; }

        public string Color { get; set; }

        public int LuggageCapacity { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        [ForeignKey(nameof(CarType))]
        public string CarTypeId { get; set; }

        public CarType CarType { get; set; }

        [ForeignKey(nameof(Make))]
        public string MakeId { get; set; }

        public virtual Make Make { get; set; }

        [ForeignKey(nameof(Model))]
        public string ModelId { get; set; }

        public virtual Model Model { get; set; }

        public virtual ICollection<Image> Images { get; set; }
    }
}
