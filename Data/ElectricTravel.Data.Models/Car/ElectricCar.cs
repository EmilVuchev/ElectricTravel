namespace ElectricTravel.Data.Models.Car
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using ElectricTravel.Data.Common.Models;
    using ElectricTravel.Data.Models.Multimedia;
    using ElectricTravel.Data.Models.User;
    using MyFirstAspNetCoreApplication.ValidationAttributes;

    public class ElectricCar : BaseDeletableModel<int>
    {
        public ElectricCar()
        {
            this.Images = new HashSet<Image>();
            this.Videos = new HashSet<Video>();
        }

        [Range(50.0, 2000.0)]
        public double Range { get; set; }

        [Range(0, 2000000)]
        public int Kilometres { get; set; }

        [MaxLength(10)]
        public string Acceleration { get; set; }

        [Range(100.0, 700.0)]
        public double TopSpeed { get; set; }

        [Required]
        [MaxLength(10)]
        public string Battery { get; set; }

        [MaxLength(10)]
        public string ElectricityConsumption { get; set; }

        [MaxLength(10)]
        public string Drive { get; set; }

        [CurrentYearMaxValue(1900)]
        public int Year { get; set; }

        [Range(50, 2000)]
        public int HorsePower { get; set; }

        [Range(3, 20)]
        public int Seats { get; set; }

        [Range(3, 5)]
        public int Doors { get; set; }

        [MaxLength(20)]
        public string Color { get; set; }

        [Range(50, 5000)]
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

        [ForeignKey(nameof(User))]
        public string UserId { get; set; }

        public virtual ElectricTravelUser User { get; set; }

        public virtual ICollection<Image> Images { get; set; }

        public virtual ICollection<Video> Videos { get; set; }

    }
}
