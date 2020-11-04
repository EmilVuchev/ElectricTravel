namespace ElectricTravel.Data.Models.Car
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using ElectricTravel.Data.Common.Models;

    public class ElectricCar : BaseModel<int>
    {
        public ElectricCar()
        {
            this.Images = new HashSet<CarImage>();
        }

        public double Range { get; set; }

        public int Kilometres { get; set; }

        public string Acceleration { get; set; }

        public double TopSpeed { get; set; }

        [Required]
        public string Battery { get; set; }

        public string ElectricityConsumption { get; set; }

        public string Drive { get; set; }

        public int Year { get; set; }

        public int HorsePower { get; set; }

        public int Seats { get; set; }

        public int Doors { get; set; }

        public string Color { get; set; }

        public int? LuggageCapacity { get; set; }

        [Required]
        [ForeignKey(nameof(CarType))]
        public int CarTypeId { get; set; }

        public CarType CarType { get; set; }

        [Required]
        [ForeignKey(nameof(Make))]
        public int MakeId { get; set; }

        public virtual Make Make { get; set; }

        [Required]
        [ForeignKey(nameof(Model))]
        public int ModelId { get; set; }

        public virtual Model Model { get; set; }

        public virtual ICollection<CarImage> Images { get; set; }
    }
}
