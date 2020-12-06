namespace ElectricTravel.Data.Models.Car
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using ElectricTravel.Data.Common.Models;
    using ElectricTravel.Data.Models.Multimedia;
    using ElectricTravel.Data.Models.User;

    public class ElectricCar : BaseDeletableModel<int>
    {
        public ElectricCar()
        {
            this.Images = new HashSet<Image>();
        }

        public double Range { get; set; }

        public int Kilometres { get; set; }

        [MaxLength(300)]
        public string Description { get; set; }

        [MaxLength(10)]
        public string Acceleration { get; set; }

        public double TopSpeed { get; set; }

        [Required]
        [MaxLength(10)]
        public string Battery { get; set; }

        [MaxLength(10)]
        public string ElectricityConsumption { get; set; }

        [MaxLength(10)]
        public string Drive { get; set; }

        public int Year { get; set; }

        public int HorsePower { get; set; }

        public int Seats { get; set; }

        public int Doors { get; set; }

        [MaxLength(20)]
        public string Color { get; set; }

        public int? LuggageCapacity { get; set; }

        [ForeignKey(nameof(CarType))]
        public int CarTypeId { get; set; }

        public virtual CarType CarType { get; set; }

        [ForeignKey(nameof(Make))]
        public int MakeId { get; set; }

        public virtual Make Make { get; set; }

        [ForeignKey(nameof(Model))]
        public int ModelId { get; set; }

        public virtual Model Model { get; set; }

        [Required]
        [ForeignKey(nameof(User))]
        public string UserId { get; set; }

        public virtual ElectricTravelUser User { get; set; }

        public virtual ICollection<Image> Images { get; set; }
    }
}
