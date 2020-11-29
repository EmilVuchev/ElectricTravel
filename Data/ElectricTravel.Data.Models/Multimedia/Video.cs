namespace ElectricTravel.Data.Models.Multimedia
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using ElectricTravel.Data.Common.Models;
    using ElectricTravel.Data.Models.Car;

    public class Video : BaseDeletableModel<string>
    {
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        [Required]
        public string Path { get; set; }

        [Required]
        [MaxLength(20)]
        public string Extension { get; set; }

        [MaxLength(200)]
        public string Description { get; set; }

        [ForeignKey(nameof(Car))]
        public int ElectricCarId { get; set; }

        public virtual ElectricCar Car { get; set; }
    }
}
