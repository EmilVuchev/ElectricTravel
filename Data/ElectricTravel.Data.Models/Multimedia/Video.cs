namespace ElectricTravel.Data.Models.Multimedia
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using ElectricTravel.Data.Common.Models;
    using ElectricTravel.Data.Models.Car;

    public class Video : BaseDeletableModel<string>
    {
        public Video()
        {
            this.Cars = new HashSet<CarVideo>();
        }

        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        [Required]
        public string Path { get; set; }

        [MaxLength(200)]
        public string Description { get; set; }

        public virtual ICollection<CarVideo> Cars { get; set; }
    }
}
